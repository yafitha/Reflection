using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Bl
{
    public class NumberManipulationBL
    {

        private static void Run(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:54759/api/PrimeNumber/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static bool IsPrimeNumber(string number)
        {
            bool isPrime = false;
            try
            {
                Task task = Task.Run(async () =>
                {
                    using (var client = new HttpClient())
                    {
                        Run(client);
                        HttpResponseMessage response = await client.PostAsJsonAsync("IsPrime", number);
                        string httpResponseBody = "";
                        if (response.IsSuccessStatusCode)
                        {
                            httpResponseBody = await response.Content.ReadAsStringAsync();
                            isPrime = JsonConvert.DeserializeObject<bool>(httpResponseBody);
                        }
                        return isPrime;
                    }
                });
                task.Wait(); // Wait
            }
            catch (Exception ex)
            {

            }
            return isPrime;
        }
    }
}
