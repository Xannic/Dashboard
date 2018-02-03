using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Models;
using Dashboard.Logic;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new ViewModel {
                RaboBetaal = DataSingleton.Instance.RaboBetaalMoney,
                RaboSpaar = DataSingleton.Instance.RaboSpaarMoney,
                Moneyou = DataSingleton.Instance.MoneyouMoney,
                Transactions = DataSingleton.Instance.Transactions.Where(x => x.Date.Year == 2017).ToList()
            };
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
