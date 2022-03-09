using FireAndForgetDemo.Entidades;
using FireAndForgetDemo.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace FireAndForgetDemo.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IRepositorioLogs repositorioLogs;

        public PersonasController(ApplicationDbContext context, 
            IRepositorioLogs repositorioLogs)
        {
            this.context = context;
            this.repositorioLogs = repositorioLogs;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Persona persona)
        {
            context.Add(persona);
            await context.SaveChangesAsync();

            _ = Task.Run(async () =>
            {
               await repositorioLogs.GuardarLogBackground($"Ha sido insertado el registro Persona con Id {persona.Id} y nombre = {persona.Nombre}");
            });

            return Ok();
        }
    }
}
