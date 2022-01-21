using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MqqtProtocol
{
    public static class RestHelp
    {
        //private static readonly string url = "https://api.openweathermap.org/data/2.5/weather?q=bangalore&appid=477bd9fe27fc8496a836e3d59bc3986a";
        public static async Task<string> Tempera()
        {
            string appId= ConfigurationManager.AppSettings.Get("appId");
            string city = "Paderborn";
            double tmp;
            string url = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=" + appId;
            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)

            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<dynamic>(body);
                var tmpDegreesF = Math.Round((float)obj.main.temp * 9 / 5 - 459.67, 2);
                tmp = Math.Round((((Math.Round((float)obj.main.temp * 9 / 5 - 459.67, 2)) - 32) * 5) / 9, 0);
                Console.WriteLine($"Current temperature is {tmpDegreesF}°F");
                Console.WriteLine($"Current temperature is {tmp}°C");
                //Console.ReadKey();
                String timeStamp = GetTimestamp(DateTime.Now);
                string tmp2 = "Temprature is " + tmp.ToString("00") + "°C at the time " + timeStamp;
                return tmp2;
            }
            return string.Empty;
        }

        private static string GetTimestamp(DateTime value)
        {
            return value.ToString("MM/dd/yy H:mm:ss zzz");
        }
    }
}
