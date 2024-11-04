using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO.TShirt;
using API.Interfaces;
using API.Mappers;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;

namespace API.Service
{
    public class FMPService : IFMPService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        public FMPService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }
        public async Task<TShirt> FindTShirtByBrandAsync(string brand)
        {
            try
            {
                //var apiKey = _config["FMPKey"];
                //var result = await _httpClient.GetAsync($"https://financialmodelingprep.com/api/v3/profile/{brand}?apikey={apiKey}");
                var result = await _httpClient.GetAsync($"https://financialmodelingprep.com/api/v3/profile/{brand}?apikey=JXdHYiAgy1Z9ips6T6YMLNJxC9b6L8Le");
                if(result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var tasks = JsonConvert.DeserializeObject<FMPTShirt[]>(content);
                    var tShirt = tasks[0];
                    if (tShirt != null)
                    {
                        return tShirt.ToTShirtFromFMP();
                    }
                    return null;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
        }
    }
}