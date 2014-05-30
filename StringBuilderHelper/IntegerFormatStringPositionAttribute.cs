namespace PositionedStrings
{
    public class IntegerFormatStringPositionAttribute : StringPositionAttribute
    {
        public IntegerFormatStringPositionAttribute(int startIndex, int count)
            : base(startIndex, count, '0', true)
        {
        }
    }
}
