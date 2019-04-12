using CaixaEletronico.Model.DTO;
using CaixaEletronico.Models;
using CaixaEletronico.Services;
using Microsoft.AspNetCore.Mvc;

namespace CaixaEletronico.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View(new SaqueViewModel());
        }

        [HttpPost]
        public IActionResult Index(SaqueViewModel saqueViewModel)
        {
            SaqueService saqueService = new SaqueService();

            SaqueDTO saqueDTO = new SaqueDTO { ValorRequisitado = saqueViewModel.ValorRequisitado };

            if (!saqueService.EstaNoLimite(saqueDTO))
            {
                saqueViewModel.Erro = @"O valor informado passou do limite de R$ 1.500,00.";
                return View(saqueViewModel);
            }

            if (!saqueService.ValorRequisitadoValido(saqueDTO))
            {
                saqueViewModel.Erro = @"O valor informado é inválido. Favor informar um valor múltiplo de 2, 5, 10, 20, 50 ou 100.";
                return View(saqueViewModel);
            }            

            saqueViewModel.ValoresSaque = saqueService.RealizaSaque(saqueDTO);

            return View(saqueViewModel);
        }
    }
}
