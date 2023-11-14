using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoMVC.Data;
using ProyectoMVC.ViewModel;
using ProyectoMVC.ViewModel.Modelo;

namespace ProyectoMVC.Repositorios
{
    public class PersonasRepositorio : IPersonaRepositorio
        {
            private readonly DataContext _context;
            private IMapper _mapper;
            public PersonasRepositorio(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<PersonaViewModel> CrearOActualizar(PersonaViewModel personaDto, int id = 0)
            {
                var persona = personaDto;
                if (id == 0)
                {

                    await _context.Personas.AddAsync(persona);
                }
                else
                {
                    persona.Id = id;
                }

                await _context.SaveChangesAsync();
                return persona;
            }

            public async Task<bool> DeletePersonas(int id)
            {
                try
                {
                    var persona = await _context.Personas.FindAsync(id);
                    if (persona != null)
                    {
                        _context.Personas.Remove(persona);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            public async Task<List<PersonaViewModel>> GetPersonas()
            {
                var personas = await _context.Personas.ToListAsync();
                //List<PersonasDto> personasDto = new List<PersonasDto>();
                //foreach(var persona in personas)
                //{
                //    var personaDto = new PersonasDto();
                //    personaDto.Nombre = persona.Nombre;
                //    personaDto.Apellido = persona.Apellido;
                //    personasDto.Add(personaDto);

                //}
                return personas;
            }

            public async Task<PersonaViewModel> GetPersonasById(int id)
            {
                var persona = await _context.Personas.FindAsync(id);
                return persona; ;
            }        
       
    }
}
