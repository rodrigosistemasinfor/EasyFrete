using System;
using System.Net.Http;

namespace EasyFreteApp.Infra.CrossCutting.Helpers
{
    public static class DataContext
    {
        private static string UrlDataEquipe = Environment.GetEnvironmentVariable("SERVICE_DATA_EQUIPES");
        
        private static string GetEquipe()
        {
            var jsonEquipe = "{}";

            using (var client = new HttpClient())
            {
                HttpResponseMessage responseEquipe = client.GetAsync(UrlDataEquipe).Result;

                if (responseEquipe.IsSuccessStatusCode)
                    jsonEquipe = responseEquipe.Content.ReadAsStringAsync().Result;
            }

            return jsonEquipe;
        }

        public static string Get()
        {
            var json = "{" +
                            $"Equipe : {GetEquipe()}" +
                       "}";

            return json;
        }
    }
}
