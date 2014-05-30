using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionedStrings.Tests.Classes
{
    public class HeaderLine
    {
        [StringPosition(0, 1)]
        public char Registro { get; set; }

        [IntegerFormatStringPositionAttribute(1, 20)]
        public int Codigo { get; set; }

        [StringPosition(21, 15)]
        public string Nome { get; set; }

        [IntegerFormatStringPositionAttribute(36, 10)]
        public int CodigoRetorno { get; set; }
    }
}
