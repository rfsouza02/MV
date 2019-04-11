using CaixaEletronico.Model;
using CaixaEletronico.Model.DTO;
using System.Collections.Generic;

namespace CaixaEletronico.Services.Interfaces
{
    public interface ISaqueService
    {
        bool EstaNoLimite(SaqueDTO saqueDTO);

        bool ValorRequisitadoValido(SaqueDTO saqueDTO);

        Dictionary<TipoNota, int> RealizaSaque(SaqueDTO saqueDTO);
    }
}
