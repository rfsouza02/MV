using System;

namespace CaixaEletronico.Model
{
    [Flags]
    public enum TipoNota
    {
        Dois = 2,
        Cinco = 5,
        Dez = 10,
        Vinte = 20,
        Cinquenta = 50,
        Cem = 100
    }
}
