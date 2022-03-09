using FireAndForgetDemo.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace FireAndForgetDemo.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonasController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PersonasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Persona persona)
        {
            context.Add(persona);
            await context.SaveChangesAsync();

            var log = new Log { Mensaje = $"Ha sido insertado el registro Persona con Id {persona.Id} y nombre = {persona.Nombre} " };
            context.Add(log);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
