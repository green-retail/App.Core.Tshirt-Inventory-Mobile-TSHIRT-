using App.Core.Tshirt.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Tshirt.Services
{
    public class ProductServices
    {
        HttpClient client;
        private string PATHSERVER { get; set; }

        public ProductServices()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            PATHSERVER = "10.1.92.207:83"; //Resources.PathServer;
        }

        public async Task<List<Product>> Search(string code)
        {
            var items = new List<Product>();
            string url = "http://" + PATHSERVER + "/tshirt/product/search?code=";
            string uri = string.Concat(url, code);
            try
            {
                var result = await client.GetAsync(uri);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<Product>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return items;
        }


    }
}
