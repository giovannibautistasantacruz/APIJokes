using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Utilities.Entities;

namespace Utilities.Services
{
    public class ServiceJoke
    {
        private HttpClient _httpClient;

        public async Task<ResponseJokes> GetJokes()
        {
            ResponseJokes result = null;
            List<Jokes> jokes = new List<Jokes>();
            string lastStatusCode = "";

            _httpClient = new HttpClient();
            string url = "https://api.chucknorris.io/jokes/random";
            while (jokes.Count<25)
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    using (HttpResponseMessage response = await _httpClient.SendAsync(request))
                    {
                        using (HttpContent content = response.Content)
                        {
                            lastStatusCode = response.StatusCode.ToString();
                            if (response.IsSuccessStatusCode)
                            {
                                string json = await content.ReadAsStringAsync();

                                Jokes joke = JsonSerializer.Deserialize<Jokes>(json);

                                if(!jokes.Contains(joke))
                                    jokes.Add(joke);
                            }
                        }
                    }
                }
            }

            if (jokes.Count<25)
            {
                result = new ResponseJokes();
                result.Jokes = new List<Jokes>();
                result.StatusCode = lastStatusCode;
                result.Message = "Ocurrio un error al obtener 25 registros de Chuck Norris Jokes API";
            }
            else
            {
                result = new ResponseJokes();
                result.Jokes = new List<Jokes>();
                result.Jokes = jokes;
                result.StatusCode = lastStatusCode;
                result.Message = "Se obtuvieron 25 registros de Chuck Norris Jokes API correctamente";
            }
        
            return result;
        }
    }
}
