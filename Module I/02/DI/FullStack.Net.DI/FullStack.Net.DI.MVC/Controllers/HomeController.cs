using FullStack.Net.DI.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FullStack.Net.DI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;        
        private readonly IGuidServiceTransient _guidServiceTransient;
        private readonly IGuidServiceScoped _guidServiceScoped;
        private readonly IGuidServiceSingleton _guidServiceSingleton;

        private readonly ClientGuid _clientGuid;

        public HomeController(ILogger<HomeController> logger,
            IGuidServiceTransient guidServiceTransient,
            IGuidServiceScoped guidServiceScoped,
            IGuidServiceSingleton guidServiceSingleton,
            ClientGuid clientGuid
        )
        {
            _logger = logger;
            _guidServiceTransient = guidServiceTransient;
            _guidServiceScoped = guidServiceScoped;
            _guidServiceSingleton = guidServiceSingleton;
            _clientGuid = clientGuid;
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.ControllerData.GuidTrasient = _guidServiceTransient.GetGuid();
            model.ControllerData.GuidScoped = _guidServiceScoped.GetGuid();
            model.ControllerData.GuidSingleton = _guidServiceSingleton.GetGuid();

            model.ClientData.GuidTrasient = _clientGuid.GetGuidTransient();
            model.ClientData.GuidScoped = _clientGuid.GetGuidScoped();
            model.ClientData.GuidSingleton = _clientGuid.GetGuidSingleton();

            return View(model);
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