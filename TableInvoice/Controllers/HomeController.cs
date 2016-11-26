using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TableInvoice.Models;

namespace TableInvoice.Controllers
{
    public class HomeController : Controller
    {
        private Product[] products = {
            new Product {Name = "Pralka White", Unit ="szt.", Price = 1200M },
            new Product {Name = "Pralka Blue", Unit ="szt.", Price = 1300M },
            new Product {Name = "Pralka Yellow", Unit ="szt.", Price = 1400M },
            new Product {Name = "Pralka Brown", Unit ="szt.", Price = 1500M },
            new Product {Name = "Pralka Green", Unit ="szt.", Price = 1600M },
            new Product {Name = "Pralka Red", Unit ="szt.", Price = 1600M }
            };

        // GET: Home (default View)
        public ActionResult Index()
        {
            IValueCalculator calc = new LinqValueCalculator();

            SumOfTable tab = new SumOfTable(calc) { Products = products };

            decimal totalValue = tab.CalculateProductTotal();

            //return default view (Views/Home/Index)
            return View(totalValue);
        }
    }
}







