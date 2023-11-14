using AutoMapper;
using ProyectoMVC.ViewModel;
using ProyectoMVC.ViewModel.Modelo;

namespace ProyectoMVC
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PersonaViewModel, Personas>();
                config.CreateMap<Personas, PersonaViewModel>();
            });
            return mappingConfig;
        }
    }
}
