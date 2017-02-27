using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PositionedStrings
{
    public static class PositionedStringBuilder
    {
        /// <summary>
        /// Build a string line with each object passed as parameter using
        /// what is defined on StringPositionAttribute
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static string ToString(params object[] objs)
        {
            if (objs == null) throw new ArgumentNullException("obj");

            var sb = new StringBuilder();
            foreach (var obj in objs)
                sb.AppendLine(ToString(obj));

            return sb.ToString();
        }

        /// <summary>
        /// Build a string line with the list of objects passed as parameter using
        /// what is defined on StringPositionAttribute
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static string ToString(IEnumerable<object> objs)
        {
            if (objs == null) throw new ArgumentNullException("obj");
            
            return ToString(objs.ToArray());
        }

        public static IEnumerable<T> ReadAllLines<T>(params string[] lines) where T : new()
        {
            if (lines == null) throw new ArgumentNullException("lines");

            var type = typeof(T);
            var properties = type.GetProperties();

            ValidatePositions(type, properties);

            var list = new List<T>();
            var validationErrors = new List<StringPositionValidationResult>();

            int lineNumber = 1;
            foreach (var line in lines)
            {
                var validationResult = new StringPositionValidationResult();
                var obj = ReadLine<T>(line, lineNumber, properties, out validationResult);
                if (validationResult.IsValid)
                    list.Add(obj);
                else
                    validationErrors.Add(validationResult);
                lineNumber++;
            }

            if (validationErrors.Any())
                throw new StringPositionFormatException("Format validation failed for one or more lines. See 'FormatValidationErrors' property for more details.", validationErrors);

            return list;
        }

        private static string ToString(object obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();

            ValidatePositions(type, properties);

            string lineValue = string.Empty;
            foreach (var property in properties)
            {
                if (property.GetIndexParameters().Any())
                    continue;

                var attribute = (StringPositionAttribute)Attribute.GetCustomAttribute(property, typeof(StringPositionAttribute), false);

                var value = property.GetValue(obj, null);

                if (value == null)
                    continue;

                string stringValue = value.ToString();

                if (stringValue.Length < attribute.Count)
                {
                    if (attribute.AlignRight)
                        stringValue = stringValue.PadLeft(attribute.Count, attribute.PaddingChar);
                    else
                        stringValue = stringValue.PadRight(attribute.Count, attribute.PaddingChar);
                }
                else if (stringValue.Length > attribute.Count)
                {
                    stringValue = stringValue.Substring(0, attribute.Count);
                }

                if (attribute.StartIndex > lineValue.Length)
                    lineValue = lineValue.PadRight(attribute.StartIndex - lineValue.Length, ' ');

                lineValue += stringValue;
            }

            return lineValue;
        }

        private static T ReadLine<T>(string line, int lineIndex, PropertyInfo[] properties, out StringPositionValidationResult validationResult) where T : new()
        {
            var obj = new T();
            validationResult = new StringPositionValidationResult(lineIndex);
            foreach (var property in properties)
            {
                if (property.GetIndexParameters().Any())
                    continue;

                var attribute = (StringPositionAttribute)Attribute.GetCustomAttribute(property, typeof(StringPositionAttribute), false);

                string value;
                try
                {
                    value = line.Substring(attribute.StartIndex, attribute.Count);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    validationResult.Exception = ex;
                    validationResult.ValidationError = string.Format("Could not find the property {0} in line {1}", property.Name, lineIndex);
                    break;
                }

                try
                {
                    property.SetValue(obj, Convert.ChangeType(value, property.PropertyType, null), null);
                }
                catch (Exception ex)
                {
                    validationResult.Exception = ex;
                    validationResult.ValidationError = string.Format("Could not convert property {0} to its original type in line {1}", property.Name, lineIndex);
                    break;
                }
            }
            return obj;
        }

        private static void ValidatePositions(Type type, PropertyInfo[] properties)
        {
            var positions = new List<KeyValuePair<int, int>>();

            foreach (var property in properties)
            {
                if (property.GetIndexParameters().Any())
                    continue;

                var attribute = (StringPositionAttribute)Attribute.GetCustomAttribute(property, typeof(StringPositionAttribute), false);
                positions.Add(new KeyValuePair<int, int>(attribute.StartIndex, attribute.StartIndex + attribute.Count));
            }

            foreach (var position in positions)
            {
                int startIndex = position.Key;
                int endIndex = position.Value;

                foreach (var comparingPosition in positions)
                {
                    if ((startIndex > comparingPosition.Key && startIndex < comparingPosition.Value)
                        || (endIndex > comparingPosition.Key && endIndex < comparingPosition.Value)
                        || (startIndex < comparingPosition.Key && endIndex > comparingPosition.Key))
                        throw new IndexOutOfRangeException(string.Format("There is more than one member occupying the same string position in \"{0}\" type.", type.FullName));
                }
            }
        }
    }
}
