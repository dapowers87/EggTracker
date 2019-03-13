using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EggTracker.Web.Models.Chicken;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace EggTracker.Web.Controllers
{
    public class ChickenController : Controller
    {
        private readonly IMongoCollection<ChickenModel> _chickens;

        public ChickenController(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("EggTracker"));
            var database = client.GetDatabase("EggTracker");
            _chickens = database.GetCollection<ChickenModel>("Chickens");
        }

        public IActionResult Create()
        {
            var model = new ChickenModel();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ChickenModel model)
        {
            if (ModelState.IsValid)
            {
                await _chickens.InsertOneAsync(model);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListChicken()
        {
            ListChickenModel model = new ListChickenModel
            {
                Chickens = new List<ChickenModel>()
            };

            var findings = await _chickens.FindAsync(chicken => true);
            model.Chickens = findings.ToList();


            return View(model);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _chickens.DeleteOneAsync(chicken => chicken.Id == id);
            return RedirectToAction("ListChicken");
        }
    }
}
