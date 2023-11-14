using ProyectoMVC.ViewModel;

namespace ProyectoMVC.Repositorios
{
    public interface IPersonaRepositorio
    {
        Task<List<PersonaViewModel>> GetPersonas();
        Task<PersonaViewModel> GetPersonasById(int id);
        Task<PersonaViewModel> CrearOActualizar(PersonaViewModel persona, int id = 0);
        Task<bool> DeletePersonas(int id);
    }
}
