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
        public void PositionedStringBuilder_ToString_Extra()
        {
            // Arrange
            var mov = new Mov
            {
                AcaoASerExecutada = 'A',
                AnoMesReferencia = "201702",
                CodigoConsignataria = 1,
                CodigoEmpresa = 1,
                CodigoRetorno = "00",
                CodigoRubrica = "SER",
                ContadorLinha = 1,
                DataContratacao = "201703",
                Descontado = 'S',
                DescricaoRetorno = "Descasecreasc",
                DocumentoFederal = "0589879456",
                EspecieRubrica = "Compl",
                FinalDesconto = "202002",
                IdentificadorUnicoSistema = 2,
                InicioDesconto = "201302",
                Matricula = "2156132",
                NumeroContratoConsignatario = "1215648as",
                ParcelaADescontar = 1,
                PrevisaoFimDesconto = "202002",
                QuantidadeParcelas = 12,
                SequenciaColaborador = 1,
                SequenciaLancamento = 1,
                ValorDescontado = 200,
                ValorParcela = 200,
                ValorTotalEmprestimo = 5000
            };

            // Act
            var sb = PositionedStringBuilder.ToString(mov);

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
            var objects = PositionedStringBuilder.ReadAllLines<Mov>(lines);

            // Assert
            Assert.IsTrue(objects.Count() == 2);
        }
    }
}
