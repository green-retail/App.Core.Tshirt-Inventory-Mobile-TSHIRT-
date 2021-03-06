﻿using App.Core.Tshirt.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Tshirt.Services
{
    public class WarehouseServices
    {
        private string PATHSERVER { get; set; }
        HttpClient client;
        public List<Warehouse> Items { get; private set; }

        public WarehouseServices()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            PATHSERVER = "10.1.92.207:83";
        }

        public async Task<List<Warehouse>> GetListWarehouse()
        {
            var warehouses = new List<Warehouse>();
            string url = "http://" + PATHSERVER + "/tshirt/warehouse/GetAllWarehouse";

            try
            {
                HttpResponseMessage result = null;

                result = await client.GetAsync(url);

                if (result.IsSuccessStatusCode)
                {
                    var x = await result.Content.ReadAsStringAsync();
                    warehouses = JsonConvert.DeserializeObject<List<Warehouse>>(x);
                    if (warehouses.Count == 0)
                    {
                        warehouses = null;
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return warehouses;
        }
    }
}
