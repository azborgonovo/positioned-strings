using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PositionedStrings
{
    public class StringPositionValidationResult
    {
        public StringPositionValidationResult()
        {
        }

        public StringPositionValidationResult(int line) : this()
        {
            Line = line;
        }

        public int Line { get; set; }
        public string ValidationError { get; set; }
        public Exception Exception { get; set; }
        public bool IsValid { get { return ValidationError == null && Exception == null; } }
    }
}