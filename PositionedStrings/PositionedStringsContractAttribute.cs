using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PositionedStrings
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = true, AllowMultiple = false)]
    public class PositionedStringsContractAttribute : Attribute
    {
        /// <summary>
        /// Define if this contract should consider either zero or one based index.
        /// Default value is true.
        /// </summary>
        public bool ZeroBasedIndex { get; set; }

        public PositionedStringsContractAttribute()
        {
            ZeroBasedIndex = true;
        }

        public PositionedStringsContractAttribute(bool zeroBasedIndex)
        {
            ZeroBasedIndex = zeroBasedIndex;
        }
    }
}
