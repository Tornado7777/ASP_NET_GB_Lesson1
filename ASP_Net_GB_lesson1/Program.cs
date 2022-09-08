using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ASP_Net_GB_lesson1
{
    internal class Program
    {
        private static readonly CancellationTokenSource cts = new CancellationTokenSource();
        static readonly System.Net.Http.HttpClient client = new HttpClient();
        

        static async Task Main()
        {
            //получение запросов
            var requestsHttp = new List<Task<string>>(); 
            string url = "https://www.test.com";
            for (int i = 4; i < 14; i++)
            {
                requestsHttp.Add(GetPostId(i, url, cts));
            }
            //ожидание окончания запросов
            await Task.WhenAll(requestsHttp);

            //перевод в массив строк
            string[] postsString = new string[10];
            for (int i = 0; i < postsString.Length; i++)
            {
                postsString[i] = requestsHttp[i].ToString();

            }

            //десериализация в массив
            var posts = new List<Post>();
            for (int i = 0; i < 10; i++)
            {
               // posts[i] = await System.Text.Json.JsonSerializer.DeserializeAsync<Post>(postsString[i]);
                posts[i] = JsonConvert.DeserializeObject<Post>(postsString[i]);
            }

            //сохранение в файл
            for (int i = 0; i < 10; i++)
            {
                using (FileStream fs = new FileStream("posts.json", FileMode.OpenOrCreate))
                {
                    await System.Text.Json.JsonSerializer.SerializeAsync<Post>(fs,posts[i]);
                }
            }
        }

        static async Task<string> GetPostId(int id, string url, CancellationTokenSource cts)
        {
            try
            {
                string responseBody = await client.GetStringAsync(url);
                return responseBody;
            }
            catch(HttpRequestException ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
                return null;
            }
            
        }
    }
}
