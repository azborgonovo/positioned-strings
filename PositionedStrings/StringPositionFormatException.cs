using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PositionedStrings
{
    public class StringPositionFormatException : FormatException
    {
        public IEnumerable<StringPositionValidationResult> FormatValidationErrors { get; set; }

        public StringPositionFormatException(string message, IEnumerable<StringPositionValidationResult> formatValidationErrors) : base(message)
        {
            FormatValidationErrors = formatValidationErrors;
        }
    }
}
