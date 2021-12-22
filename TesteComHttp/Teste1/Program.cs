
using System;

namespace teste_1
{
    public class Program
    {

        static readonly HttpClient client = new HttpClient();
        static async Task Main()
        {
            
            try
            {

                HttpResponseMessage response = await client.GetAsync("https://www.google.com.br");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
               

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }


    }
}



