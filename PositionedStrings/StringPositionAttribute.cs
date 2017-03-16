using System;

namespace PositionedStrings
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class StringPositionAttribute : Attribute
    {
        int startIndex;
        int length;
        char paddingChar;
        bool alignRight;

        public int StartIndex { get { return startIndex; } }
        public int Length { get { return length; } }
        public char PaddingChar { get { return paddingChar; } }
        public bool AlignRight { get { return alignRight; } }
        public int Order { get; set; }
        
        public StringPositionAttribute(int startIndex, int length, char paddingChar, bool alignRight)
        {
            this.startIndex = startIndex;
            this.length = length;
            this.paddingChar = paddingChar;
            this.alignRight = alignRight;
        }

        public StringPositionAttribute(int startIndex, int length, char paddingChar)
            : this(startIndex, length, paddingChar, false)
        {
        }

        public StringPositionAttribute(int startIndex, int length)
            : this(startIndex, length, ' ')
        {
        }
    }
}
