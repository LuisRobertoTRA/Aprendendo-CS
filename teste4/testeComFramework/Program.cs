using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.IO;

namespace WebAPIClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            await ProcessRepositories();

        }

        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");

            

            string pagi1 = await client.GetStringAsync("https://www.kabum.com.br/login");


            JObject produto = new JObject();
            produto["email"] = "mesa@42gmai.com";
            produto["senha"] = "grande";
            produto["session"] = 42;

            string proCon = produto.ToString();

            var data = new StringContent(proCon, Encoding.UTF8, "application/json");

            var teste1 = await client.PostAsync("https://www.kabum.com.br/login/kabum", data);

            //var form = new Dictionary<string, string>();
            //form["usuario"] = "tangerina";
            //form["senha"] = "424242";

            //var conteudo = new FormUrlEncodedContent(form);

            //var teste1 = await client.PostAsync("https://api.github.com/users/", conteudo);







            var stringTask = client.GetStringAsync("https://api.github.com/users/avibzi");

            string msg = await stringTask;

            JObject teste = JObject.Parse(msg);

            string urlFoto = teste["avatar_url"].ToString();

            string nome = teste["name"].ToString();

            var fototask = client.GetByteArrayAsync($"{urlFoto}");

            byte[] foto = await fototask;

            int tamanho = foto.Length;

            string caminho = @"C:\temp\Documents\";
            if (!Directory.Exists(caminho))
                Directory.CreateDirectory(caminho);

            caminho += $"{nome}.jpg";

            File.WriteAllBytes(caminho, foto);

        }
    }
}
