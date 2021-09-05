using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public dmodel Dmodel { get; set; }
        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> OnGet()
        {
            using (var client=_clientFactory.CreateClient())
            {
                using (var res=await client.GetAsync("https://swapi.dev/api/planets/1"))
                {
                    var apires = await res.Content.ReadAsStringAsync();

                    Dmodel = JsonConvert.DeserializeObject<dmodel>(apires);
                    
                }
            }

            return Page();
        }
    }
}
