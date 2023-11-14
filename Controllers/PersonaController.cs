using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProyectoMVC.Data;
using ProyectoMVC.Repositorios;
using ProyectoMVC.ViewModel;
using ProyectoMVC.ViewModel.Modelo.DTOs;
using System.Text.Json;

namespace ProyectoMVC.Controllers
{
    public class PersonaController : Controller
	{
        private readonly IPersonaRepositorio _repositorio;
        private readonly DataContext _context;

        public PersonaController(IPersonaRepositorio repositorio, DataContext context)
        {
            _repositorio = repositorio;
            _context = context;
        }
        public async Task<IActionResult> Index()
		{
            try
            {
                var personas = await _context.Personas.ToListAsync();
                var personas2 = await _repositorio.GetPersonas();
                //var url = "https://localhost:7042/api/Personas";
                //JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                //using (var httpClient = new HttpClient())
                //{
                //    var response = await httpClient.GetAsync(url);
                //    if (response.IsSuccessStatusCode)
                //    {
                //        var content = await response.Content.ReadAsStringAsync();
                //        var contenido = System.Text.Json.JsonSerializer.Deserialize<ResponseDto>(content, options);
                //        var personas = JsonConvert.DeserializeObject<List<PersonaViewModel>>(contenido.Result.ToString());
                        return View(personas);
                  //      Console.WriteLine(content);
                  //  }
               // }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return View();
        }
	}
}
