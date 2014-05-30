using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PositionedStrings.Tests.Classes;
using System.Diagnostics;
using System.Collections;

namespace PositionedStrings.Tests
{
    [TestClass]
    public class StringPositionAttributeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            HeaderLine headerLine = new HeaderLine();
            headerLine.Registro = 'A';
            headerLine.Codigo = 12312312;
            headerLine.Nome = "Joaquim Barbosa da Silve Siqueira Neto";
            headerLine.CodigoRetorno = 12312312;

            HeaderLine headerLine2 = new HeaderLine();
            headerLine2.Registro = 'B';
            headerLine2.Codigo = 1231809;
            headerLine2.Nome = "Amélia Soares";
            headerLine2.CodigoRetorno = 12312312;

            // Act
            var sb = PositionedStringBuilder.ToPositionedString(headerLine, headerLine2);

            // Assert
            Console.Write(sb.ToString());
        }
    }
}
