using System.Data;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.ViewModel;
namespace ProyectoMVC.Controllers
{
    public class AppController : Controller{
        private static List<PeliculaViewModel> _peliculas = new List<PeliculaViewModel>();
        public IActionResult Index(){          
            return View(_peliculas); 
        }
        public IActionResult Edit(Guid id){
            var pelicula = _peliculas.FirstOrDefault(x => x.Id == id);      
            return View(pelicula);
        }
        [HttpGet("about")]
        public IActionResult About(){
            return View();
        }
        [HttpPost]
        public IActionResult Edit(PeliculaViewModel modelo){
            var pelicula = _peliculas.FirstOrDefault(x => x.Id == modelo.Id);
            if(ModelState.IsValid){
                if(pelicula == null){
                    modelo.Id = Guid.NewGuid();
                    _peliculas.Add(modelo);
                }
                else {
                    pelicula.Nombre = modelo.Nombre;
                    pelicula.Genero = modelo.Genero;
                }                
                return RedirectToAction(nameof(Index));
                // codigo para insertar en BD
            }
            return View();
        }

        public IActionResult Delete(Guid id){
            var pelicula = _peliculas.FirstOrDefault(x => x.Id == id);
	        if(pelicula != null){
		        _peliculas.Remove(pelicula);		
	        }
	        return RedirectToAction(nameof(Index));
        }
    }
}
