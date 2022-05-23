using Microsoft.AspNetCore.Mvc;
using MyMusic.Models;
using MyMusic.Repository;
using System.Diagnostics;

namespace MyMusic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ArtistaDBManager artistaDBManager;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            artistaDBManager = new ArtistaDBManager();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ArtistaIndex() 
        {
            return View(artistaDBManager.GetAllArtisti());
        }

        //[HttpGet]
        //public IActionResult EditArtista(int id)
        //{
        //    var artista = artistaDBManager.GetAllArtisti().Where(x => x.IdArtista == id).FirstOrDefault();
        //    return View(artista);
        //}

        //[HttpPost]
        //public IActionResult EditArtista(ArtistaViewModel artista)
        //{
        //    var res = artistaDBManager.GetAllArtisti().Where(x => x.IdArtista == artista.IdArtista).FirstOrDefault();
        //    if (res != null)
        //        artistaDBManager.EditArtista(artista);
        //    return RedirectToAction("ArtistaIndex");
        //}

        //[HttpGet]
        //public IActionResult ArtistaAdd()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult ArtistaAdd(ArtistaViewModel artista)
        //{
        //    artistaDBManager.AddArtista(artista);
        //    return RedirectToAction("ArtistaIndex");
        //}

        //[HttpGet]
        //public IActionResult DetailsArtista(int id)
        //{
        //    var artista = artistaDBManager.GetAllArtisti().Where(x => x.IdArtista == id).FirstOrDefault();
        //    return View(artista);
        //}

        //[HttpPost]
        //public IActionResult DetailsArtista(ArtistaViewModel artista)
        //{
        //    var res = artistaDBManager.GetAllArtisti().Where(x => x.IdArtista == artista.IdArtista).FirstOrDefault();
        //    if (res != null)
        //        artistaDBManager.DetailsArtista(artista);
        //    return RedirectToAction("ArtistaIndex");
        //}

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