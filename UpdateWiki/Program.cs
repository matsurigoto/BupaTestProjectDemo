using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace UpdateWiki
{
    class Program
    {
        public static string personalaccesstoken = "iegsgqz4qgtxq6z6afbk2f74gxf4qmt4nrf4ique6ekrzhtarlva";
        public static string path = "/Release API";

        public class request
        {
            public string content { get; set; }
        }

        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("wiki page");
                request req = new request { content = "New content for page" };
                var jsonString = JsonConvert.SerializeObject(req);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri("https://dev.azure.com");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(
                    System.Text.ASCIIEncoding.ASCII.GetBytes(
                        string.Format("{0}:{1}", "", personalaccesstoken))));

                var deleteResponse = client.DeleteAsync("/duranhsieh/Bupa Demo/_apis/wiki/wikis/Bupa-Demo.wiki/pages?path=" + path + "&api-version=5.0").Result;
                var response = client.PutAsync("/duranhsieh/Bupa Demo/_apis/wiki/wikis/Bupa-Demo.wiki/pages?path=" + path + "&api-version=5.0", httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Error");
                }

                foreach (string file in Directory.EnumerateFiles("./swagger/docs", "*.md"))
                {
                    Console.WriteLine(file);
                    var filename = file.Replace("./swagger/docs", "").Replace("*.md", "");
                    var subContent = File.ReadAllText(file);
                    request subRequest = new request { content = subContent };
                    var subJsonString = JsonConvert.SerializeObject(subRequest);
                    var subHttpContent = new StringContent(subJsonString, Encoding.UTF8, "application/json");
                    var subPagePath = path + filename;
                    var subPageResponse = client.PutAsync("/duranhsieh/Bupa Demo/_apis/wiki/wikis/Bupa-Demo.wiki/pages?path=" + subPagePath + "&api-version=5.0", subHttpContent).Result;

                    if (subPageResponse.IsSuccessStatusCode)
                    {
                        Console.Write("Success");
                    }
                    else
                    {
                        Console.Write("Error");
                    }
                }
            }
        }
    }
}
