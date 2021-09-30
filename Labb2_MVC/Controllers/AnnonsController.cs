using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Labb2_MVC.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Labb2_MVC.Controllers
{
    public class AnnonsController : Controller
    {
        HelperClass helper = new HelperClass();

        public async Task<IActionResult> Index()
        {
            List<PrenumerantModell> Prenumeranter = new List<PrenumerantModell>();
            HttpClient client = helper.Initial();
            HttpResponseMessage res = await client.GetAsync("/api/Prenumerant");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                Prenumeranter = JsonConvert.DeserializeObject<List<PrenumerantModell>>(result);
            }

            return View(Prenumeranter);
        }
    }
}
