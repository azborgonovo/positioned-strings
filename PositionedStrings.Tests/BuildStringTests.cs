using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PositionedStrings.Tests.Classes;
using System.Collections.Generic;

namespace PositionedStrings.Tests
{
    [TestClass]
    public class BuildStringTests
    {
        [TestMethod]
        public void PositionedStrings_BuildString_ArrayAsParameter()
        {
            // Arrange
            var headerLine = new HeaderLine();
            headerLine.Registro = 'A';
            headerLine.Codigo = 12312312;
            headerLine.Nome = "Joaquim Barbosa da Silve Siqueira Neto";
            headerLine.CodigoRetorno = 12312312;

            var headerLine2 = new HeaderLine();
            headerLine2.Registro = 'B';
            headerLine2.Codigo = 1231809;
            headerLine2.Nome = "Amélia Soares";
            headerLine2.CodigoRetorno = 12312312;

            // Act
            var sb = PositionedStrings.BuildString(headerLine, headerLine2);

            // Assert
            Console.Write(sb.ToString());
        }

        [TestMethod]
        public void PositionedStrings_BuildString_ListAsParameter()
        {
            // Arrange
            var headerLine = new HeaderLine();
            headerLine.Registro = 'A';
            headerLine.Codigo = 12312312;
            headerLine.Nome = "Joaquim Barbosa da Silve Siqueira Neto";
            headerLine.CodigoRetorno = 12312312;

            var headerLine2 = new HeaderLine();
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
            var sb = PositionedStrings.BuildString(list);

            // Assert
            Console.Write(sb.ToString());
        }

        [TestMethod]
        public void PositionedStrings_BuildString_Extra()
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
            var sb = PositionedStrings.BuildString(mov);

            // Assert
            Console.Write(sb.ToString());
        }
    }
}
