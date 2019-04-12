using CaixaEletronico.Model;
using CaixaEletronico.Model.Enums;
using CaixaEletronico.Services.Interfaces;

namespace CaixaEletronico.Services
{
    public class ConfiguracaoSaqueService : IConfiguracaoSaqueService
    {
        /// <summary>
        /// Método criado para iniciar o caixa eletrônico com as configurações 
        /// básicas para permitir o saque.
        /// </summary>
        /// <returns>Entidade DTO com a configuração.</returns>
        public ConfiguracaoSaque IniciaCaixaEletronico()
        {
            return new ConfiguracaoSaque()
            {
                ValorLimiteSaque = 1500,
                NotasDisponiveis = TipoNota.Dois | TipoNota.Cinco | TipoNota.Dez | TipoNota.Vinte | TipoNota.Cinquenta | TipoNota.Cem,
            };
        }
    }
}
