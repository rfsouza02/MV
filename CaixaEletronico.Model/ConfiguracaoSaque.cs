using CaixaEletronico.Model.Enums;

namespace CaixaEletronico.Model
{
    public class ConfiguracaoSaque
    {
        public decimal ValorLimiteSaque { get; set; }

        public TipoNota NotasDisponiveis { get; set; }
    }
}
