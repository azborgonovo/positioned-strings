using System;

namespace PositionedStrings
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class StringPositionAttribute : Attribute
    {
        int startIndex;
        int count;
        char paddingChar;
        bool alignRight;

        public int StartIndex { get { return startIndex; } }
        public int Count { get { return count; } }
        public char PaddingChar { get { return paddingChar; } }
        public bool AlignRight { get { return alignRight; } }
        public int Order { get; set; }
        
        public StringPositionAttribute(int startIndex, int count, char paddingChar, bool alignRight)
        {
            this.startIndex = startIndex;
            this.count = count;
            this.paddingChar = paddingChar;
            this.alignRight = alignRight;
        }

        public StringPositionAttribute(int startIndex, int count, char paddingChar)
            : this(startIndex, count, paddingChar, false)
        {
        }

        public StringPositionAttribute(int startIndex, int count)
            : this(startIndex, count, ' ')
        {
        }
    }
}
