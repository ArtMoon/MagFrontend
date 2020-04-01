using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace FrontendMaga.Http.Sender
{
    public class HttpDataPostSender
    {
        public async Task<string> SendHttpPost(string address, List<KeyValuePair<string, string>> param,params string[] args )
        {
            string res = string.Empty;
            string req = string.Format(address, args);
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(req);
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.Content = new FormUrlEncodedContent(param);

                var response = await client.SendAsync(request);
                res = await response.Content.ReadAsStringAsync();
                response.Dispose();
            }

            return res.Replace('"',' ').Trim();
        }

    }
}
