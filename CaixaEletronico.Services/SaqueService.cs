using CaixaEletronico.Model;
using CaixaEletronico.Model.DTO;
using CaixaEletronico.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace CaixaEletronico.Services
{
    public class SaqueService : ISaqueService
    {
        private readonly IConfiguracaoSaqueService _configuracaoSaqueService = new ConfiguracaoSaqueService();

        private ConfiguracaoSaque ConfiguracaoSaque { get; set;}


        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public SaqueService()
        {
            this.ConfiguracaoSaque = this._configuracaoSaqueService.IniciaCaixaEletronico();
        }

        /// <summary>
        /// Construtor para permitir que seja passado um objeto mockado para testes.
        /// </summary>
        /// <param name="configuracaoSaqueService">Objeto mockado.</param>
        public SaqueService(IConfiguracaoSaqueService configuracaoSaqueService) : this()
        {
            this._configuracaoSaqueService = configuracaoSaqueService;            
        }

        /// <summary>
        /// Realiza o saque do valor requisitado.
        /// </summary>
        /// <param name="saqueDTO">Objeto com o valor do saque requisitado.</param>
        /// <returns></returns>
        public Dictionary<TipoNota, int> RealizaSaque(SaqueDTO saqueDTO)
        {
            var resultado = new Dictionary<TipoNota, int>();
            var resto = saqueDTO.ValorRequisitado;

            if ((this.ConfiguracaoSaque.NotasDisponiveis & TipoNota.Cem) != 0)
            {
                var quantidadeNotas = (int)Math.Truncate(resto / (int)TipoNota.Cem);
                resultado.Add(TipoNota.Cem, quantidadeNotas);
                resto -= quantidadeNotas * (int)TipoNota.Cem;
            }

            if ((this.ConfiguracaoSaque.NotasDisponiveis & TipoNota.Cinquenta) != 0)
            {
                var quantidadeNotas = (int)Math.Truncate(resto / (int)TipoNota.Cinquenta);
                resultado.Add(TipoNota.Cinquenta, quantidadeNotas);
                resto -= quantidadeNotas * (int)TipoNota.Cinquenta;
            }

            if ((this.ConfiguracaoSaque.NotasDisponiveis & TipoNota.Vinte) != 0)
            {
                var quantidadeNotas = (int)Math.Truncate(resto / (int)TipoNota.Vinte);
                resultado.Add(TipoNota.Vinte, quantidadeNotas);
                resto -= quantidadeNotas * (int)TipoNota.Vinte;
            }

            if ((this.ConfiguracaoSaque.NotasDisponiveis & TipoNota.Dez) != 0)
            {
                var quantidadeNotas = (int)Math.Truncate(resto / (int)TipoNota.Dez);
                resultado.Add(TipoNota.Dez, quantidadeNotas);
                resto -= quantidadeNotas * (int)TipoNota.Dez;
            }            

            if ((this.ConfiguracaoSaque.NotasDisponiveis & TipoNota.Cinco) != 0)
            {
                var quantidadeNotas = (int)Math.Truncate(resto / (int)TipoNota.Cinco);
                resultado.Add(TipoNota.Cinco, quantidadeNotas);
                resto -= quantidadeNotas * (int)TipoNota.Cinco;
            }

            if ((this.ConfiguracaoSaque.NotasDisponiveis & TipoNota.Dois) != 0)
            {
                var quantidadeNotas = (int)Math.Truncate(resto / (int)TipoNota.Dois);
                resultado.Add(TipoNota.Dois, quantidadeNotas);
                resto -= quantidadeNotas * (int)TipoNota.Dois;
            }

            return resultado;
        }

        /// <summary>
        /// Faz a validação se o valor 
        /// requisitado do saque está dentro do limite permitido.
        /// </summary>
        /// <param name="saqueDTO">Objeto com o valor do saque requisitado.</param>
        /// <returns></returns>
        public bool EstaNoLimite(SaqueDTO saqueDTO)
        {
            return saqueDTO.ValorRequisitado <= this.ConfiguracaoSaque.ValorLimiteSaque;
        }

        /// <summary>
        /// Verifica se o valor pode ser sacado com as notas disponíveis.
        /// </summary>
        /// <param name="saqueDTO">Objeto com o valor do saque requisitado.</param>
        /// <returns></returns>
        public bool ValorRequisitadoValido(SaqueDTO saqueDTO)
        {
            var resto = saqueDTO.ValorRequisitado;

            if (resto == 0m)
            {
                return false;
            }

            if ((this.ConfiguracaoSaque.NotasDisponiveis & TipoNota.Cem) != 0)
            {
                resto = resto % (int)TipoNota.Cem;
            }

            if ((this.ConfiguracaoSaque.NotasDisponiveis & TipoNota.Cinquenta) != 0)
            {
                resto = resto % (int)TipoNota.Cinquenta;
            }

            if ((this.ConfiguracaoSaque.NotasDisponiveis & TipoNota.Vinte) != 0)
            {
                resto = resto % (int)TipoNota.Vinte;
            }

            if ((this.ConfiguracaoSaque.NotasDisponiveis & TipoNota.Dez) != 0)
            {
                resto = resto % (int)TipoNota.Dez;
            }            

            if ((this.ConfiguracaoSaque.NotasDisponiveis & TipoNota.Cinco) != 0)
            {
                resto = resto % (int)TipoNota.Cinco;
            }

            if ((this.ConfiguracaoSaque.NotasDisponiveis & TipoNota.Dois) != 0)
            {
                resto = resto % (int)TipoNota.Dois;
            }

            return resto == 0;
        }
    }
}
