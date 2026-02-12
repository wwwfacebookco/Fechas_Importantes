using System.Net.Http;
using System.Collections.Generic;

namespace Fechas_Importantes.Services
{
    public class TelegramService
    {
        private readonly string _botToken = "7695728398:AAGOOZ7D-3SC_1zdY1iXAz2R8e3E5hqQe-U";
        private readonly string _chatId = "7774319855";

        public async Task EnviarMensaje(string mensaje)
        {
            using var client = new HttpClient();
            var url = $"https://api.telegram.org/bot{_botToken}/sendMessage";
            var data = new Dictionary<string, string>
        {
            { "chat_id", _chatId },
            { "text", mensaje }
        };
            await client.PostAsync(url, new FormUrlEncodedContent(data));
        }
    }
}
