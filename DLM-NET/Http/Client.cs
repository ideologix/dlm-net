using System.Net.Http;
using System.Text;

namespace DLM_NET.Http
{
    public class Client
    {
        private readonly String apiBase;
        private readonly String consumerKey;
        private readonly String consumerSecret;
        private readonly HttpClient httpClient;

        public Client(String apiBase, String consumerKey, String consumerSecret)
        {

            this.apiBase = apiBase.Last() == '/' ? apiBase.Remove(apiBase.LastIndexOf("/")) : apiBase;
            this.apiBase += "/wp-json/dlm/v1/";

            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;

            httpClient = new HttpClient();

        }


        public async Task<string> RequestGet(String path)
        {     
            var authToken = Encoding.ASCII.GetBytes($"{this.consumerKey}:{this.consumerSecret}");
            this.httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
            String fullUrl = this.apiBase + path;

            using (var result = await this.httpClient.GetAsync($"{fullUrl}"))
            {
                string content = await result.Content.ReadAsStringAsync();
                return content;
            }
        }

    }
}