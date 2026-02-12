using Fechas_Importantes.Data;
using Microsoft.EntityFrameworkCore;

namespace Fechas_Importantes.Services
{
    public class HappyBirthday : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly TelegramService _telegramService;

        public HappyBirthday(IServiceProvider serviceProvider, TelegramService telegramService)
        {
            _serviceProvider = serviceProvider;
            _telegramService = telegramService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    var hoy = DateTime.Now;
                    var cumpleañosHoy = await db.FechasEspeciales
                        .Where(f => f.Fecha.Day == hoy.Day && f.Fecha.Month == hoy.Month)
                        .ToListAsync();

                    foreach (var fecha in cumpleañosHoy)
                    {
                        await _telegramService.EnviarMensaje(
                            $"🎉 {fecha.Nota} de {fecha.Nombre} ({hoy.Year - fecha.Fecha.Year})"
                        );
                    }
                }
                //await Task.Delay(TimeSpan.FromHours(2), stoppingToken);
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }
    }
}
