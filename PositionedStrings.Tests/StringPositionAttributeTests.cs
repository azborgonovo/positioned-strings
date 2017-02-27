using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PositionedStrings.Tests.Classes;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace PositionedStrings.Tests
{
    [TestClass]
    public class StringPositionAttributeTests
    {
        [TestMethod]
        public void PositionedStringBuilder_ToString_ArrayAsParameter()
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
            var sb = PositionedStringBuilder.ToString(headerLine, headerLine2);

            // Assert
            Console.Write(sb.ToString());
        }

        [TestMethod]
        public void PositionedStringBuilder_ToString_ListAsParameter()
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

            var list = new List<HeaderLine>()
            {
                headerLine,
                headerLine2
            };

            // Act
            var sb = PositionedStringBuilder.ToString(list);

            // Assert
            Console.Write(sb.ToString());
        }

        [TestMethod]
        public void PositionedStringBuilder_ReadAllLines()
        {
            // Arrange
            string[] lines = new[]
            {
                "A00000000000012312312Joaquim Barbosa0012312312",
                "B00000000000001231809Amélia Soares  0012312312"
            };

            // Act
            var objects = PositionedStringBuilder.ReadAllLines<HeaderLine>(lines);

            // Assert
            Assert.IsTrue(objects.Count() == 2);
        }

        [TestMethod]
        public void PositionedStringBuilder_ReadAllLines_ShouldThrowIfMissingData()
        {
            // Arrange
            string[] lines = new[]
            {
                "A00000000000012312312Joaquim Barbosa0012312312",
                "B00000000000001231809Amélia Soares  00123"
            };

            // Act
            try
            {
                var objects = PositionedStringBuilder.ReadAllLines<HeaderLine>(lines);
            }
            catch (StringPositionFormatException ex)
            {
                Assert.IsTrue(ex.FormatValidationErrors.Count() == 1);
                Assert.IsTrue(ex.FormatValidationErrors.First().Line == 2);
            }
        }

        [TestMethod]
        public void PositionedStringBuilder_ReadAllLines_ShouldThrowIfCouldNotConvertData()
        {
            // Arrange
            string[] lines = new[]
            {
                "A00000000000012312X12Joaquim Barbosa0012312312",
                "B00000000000001231809Amélia Soares  0012312312"
            };

            // Act
            try
            {
                var objects = PositionedStringBuilder.ReadAllLines<HeaderLine>(lines);
            }
            catch (StringPositionFormatException ex)
            {
                Assert.IsTrue(ex.FormatValidationErrors.Count() == 1);
                Assert.IsTrue(ex.FormatValidationErrors.First().Line == 1);
            }
        }
    }
}
