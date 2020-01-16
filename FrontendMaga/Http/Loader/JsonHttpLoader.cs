using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using FrontendMaga.Interfaces;

namespace FrontendMaga.Http
{
    public class JsonHttpLoader : IDataLoader
    {
        public async Task<string> LoadData(string url)
        {
            using (var client = new HttpClient())
            {
                var msg = await client.GetAsync(url);
                var json = await msg.Content.ReadAsStringAsync();
                msg.Dispose();
                return json;
            }

        }
    }

  
}
