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
    public class ReadAllLinesTests
    {
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
            var objects = PositionedStrings.ReadAllLines<HeaderLine>(lines);

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
                var objects = PositionedStrings.ReadAllLines<HeaderLine>(lines);
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
                var objects = PositionedStrings.ReadAllLines<HeaderLine>(lines);
            }
            catch (StringPositionFormatException ex)
            {
                Assert.IsTrue(ex.FormatValidationErrors.Count() == 1);
                Assert.IsTrue(ex.FormatValidationErrors.First().Line == 1);
            }
        }

        [TestMethod]
        public void PositionedStringBuilder_ReadAllLinesExtra()
        {
            // Arrange
            string[] lines = new[]
            {
                "0000000000000120171155       223726817700011   SER1      Ser12               000000000016982036001201703202002000000201703010000000000000010000000000000000000000000000000000000000000XA0001500000000050000025022017IS0000000000Descontado com SUCESSO!                                                                             0000000000169820",
                "0000000001000120171155       223726817700021   SER1      Ser13               000000000012076018001201703201808000000201703020000000000000370000000000000000000000000000000000000000000AS8446400000000020000025022017IS0000000000Descontado com SUCESSO!                                                                             0000000000120760"
            };

            // Act
            var objects = PositionedStrings.ReadAllLines<Mov>(lines);

            // Assert
            Assert.IsTrue(objects.Count() == 2);
        }
    }
}
