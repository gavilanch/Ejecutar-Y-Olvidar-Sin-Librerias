using FireAndForgetDemo.Entidades;

namespace FireAndForgetDemo.Repositorios
{
    public interface IRepositorioLogs
    {
        Task GuardarLogBackground(string mensaje);
    }

    public class RepositorioLogs: IRepositorioLogs
    {
        private readonly IServiceProvider serviceProvider;

        public RepositorioLogs(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task GuardarLogBackground(string mensaje)
        {
            try
            {
                await using (var scope = serviceProvider.CreateAsyncScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var log = new Log
                    {
                        Mensaje = mensaje
                    };
                    context.Add(log);
                    await Task.Delay(5000);
                    Console.WriteLine("El try");
                    //log.Id = 1; // error
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("El catch");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
