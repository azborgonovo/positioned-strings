using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionedStrings.Tests.Classes
{
    public class Mov
    {
        /// <summary>
        /// Identificador da Linha no Arquivo. Ex: 0000000001
        /// </summary>
        [IntegerFormatStringPosition(0, 10)]
        public int ContadorLinha { get; set; }

        /// <summary>
        /// Informar o CODIGO da EMPRESA o mesmo utilizado pelo sistema de folha de pagamento  Exp:"0001" alinhado a ESQUERDA com espaços a DIREITA
        /// </summary>
        [IntegerFormatStringPosition(10, 4)]
        public int CodigoEmpresa { get; set; }

        /// <summary>
        /// Matrícula do Colaborador
        /// </summary>
        [StringPosition(14, 15)]
        public string Matricula { get; set; }

        /// <summary>
        /// Somente Números. Ex: 00123456789
        /// </summary>
        [IntegerFormatStringPosition(29, 11)]
        public string DocumentoFederal { get; set; }

        /// <summary>
        /// Sequencial de Inclusão/Lançamento por Colaborador
        /// </summary>
        [IntegerFormatStringPosition(40, 3)]
        public int SequenciaColaborador { get; set; }

        /// <summary>
        /// Código da Consignatária na Entidade.
        /// </summary>
        [StringPosition(43, 4)]
        public int CodigoConsignataria { get; set; }

        /// <summary>
        /// Código da Rubrica/ Evento do Consignatário na Folha de Pagamento do CONVÊNIO.
        /// </summary>
        [StringPosition(47, 10)]
        public string CodigoRubrica { get; set; }

        /// <summary>
        /// Espécie/ Complemento do Código da Rubrica/Evento. Ex: EMPRESTIMO_01, EMPRESTIMO_02, CARTAO CREDITO.
        /// </summary>
        [StringPosition(57, 20)]
        public string EspecieRubrica { get; set; }

        /// <summary>
        /// Valor ou Percentual da Parcela, a ser descontado na Folha de Pagamento do Servidor. Ex: 0000000000010000
        /// Serão consideradas casas decimais, as duas últimas posições do campo. Ex: 0000000000010000 = 100,00
        /// </summary>
        [IntegerFormatStringPosition(77, 15)]
        public double ValorParcela { get; set; }

        /// <summary>
        /// Quantidade TOTAL de Parcelas Contratadas. Ex: 012
        /// </summary>
        [IntegerFormatStringPosition(92, 3)]
        public int QuantidadeParcelas { get; set; }

        /// <summary>
        /// Numero da Parcela a ser descontada. Ex: 001
        /// </summary>
        [IntegerFormatStringPosition(95, 3)]
        public int ParcelaADescontar { get; set; }

        /// <summary>
        /// Formato AAAAMM Ex: 201001
        /// </summary>
        [IntegerFormatStringPosition(98, 6)]
        public string InicioDesconto { get; set; }

        /// <summary>
        /// Formato AAAAMM Ex: 201012
        /// </summary>
        [IntegerFormatStringPosition(104, 6)]
        public string PrevisaoFimDesconto { get; set; }

        /// <summary>
        /// Formato AAAAMM Ex: 201001
        /// </summary>
        [IntegerFormatStringPosition(110, 6)]
        public string FinalDesconto { get; set; }

        /// <summary>
        /// Formato AAAAMM Ex: 201001
        /// O Ano/Mês refere-se a competência da Folha gerada
        /// </summary>
        [IntegerFormatStringPosition(116, 6)]
        public string AnoMesReferencia { get; set; }

        /// <summary>
        /// Sequencial de Inclusão/Lançamento de uma mesma RUBRICA para um DETERMINADO SERVIDOR. Ex: Rubrica 555 Colaborador 777 Sequencial 01
        /// </summary>
        [IntegerFormatStringPosition(122, 2)]
        public int SequenciaLancamento { get; set; }

        /// <summary>
        /// Identificador  único  do contrato no sistema. Ex:000001234567890
        /// </summary>
        [IntegerFormatStringPosition(124, 15)]
        public int IdentificadorUnicoSistema { get; set; }

        /// <summary>
        /// Identificador de uso do Consignatário
        /// </summary>
        [IntegerFormatStringPosition(139, 50)]
        public string NumeroContratoConsignatario { get; set; }

        /// <summary>
        /// Valor financiado. Ex:0000000000012345
        /// </summary>
        [IntegerFormatStringPosition(189, 15)]
        public double ValorTotalEmprestimo { get; set; }

        /// <summary>
        /// Data de assinatura do contrato. Ex: DDMMAAAA
        /// </summary>
        [IntegerFormatStringPosition(204, 8)]
        public string DataContratacao { get; set; }

        /// <summary>
        /// I - Inclusão , E - Exclusão
        /// </summary>
        [StringPosition(212, 1)]
        public char AcaoASerExecutada { get; set; }

        /// <summary>
        /// Sim = S - Não = N
        /// </summary>
        [StringPosition(213, 1)]
        public char Descontado { get; set; }

        /// <summary>
        /// **Código do Retorno do Desconto.
        /// </summary>
        [StringPosition(214, 10)]
        public string CodigoRetorno { get; set; }

        /// <summary>
        /// **Descrição do Retorno do Desconto.
        /// </summary>
        [StringPosition(224, 100)]
        public string DescricaoRetorno { get; set; }

        /// <summary>
        /// Valor efetivamente descontado
        /// </summary>
        [StringPosition(324, 15)]
        public double ValorDescontado { get; set; }
    }
}
