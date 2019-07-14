using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JBD.ProjetoTesteEveris.WebAdmin.Models;
using AutoMapper;
using JBD.ProjetoTesteEveris.WebAdmin.Services;

namespace JBD.ProjetoTesteEveris.WebAdmin.Controllers
{
    public class HomeController : Controller
    {
        //private readonly EmpresaServiceWeb _empresaService;
        //private readonly IMapper _mapper;

        //public HomeController(IMapper mapper)
        //{
        //    _mapper = mapper;
        //    _empresaService = new EmpresaServiceWeb(_mapper);
        //}

        public IActionResult Index()
        {
            //var teste = _empresaService.ListarEmpresas();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
