using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TableInvoice.Models;
using Ninject;

namespace TableInvoice.Controllers
{
    public class HomeController : Controller
    {
        // During create HomeContoller Ninject provides object with interface implementation 
        private IValueCalculator calc;

        private Product[] products = {
            new Product {Name = "Pralka White", Unit ="szt.", Price = 1200M },
            new Product {Name = "Pralka Blue", Unit ="szt.", Price = 1300M },
            new Product {Name = "Pralka Yellow", Unit ="szt.", Price = 1400M },
            new Product {Name = "Pralka Brown", Unit ="szt.", Price = 1500M },
            new Product {Name = "Pralka Green", Unit ="szt.", Price = 1600M },
            new Product {Name = "Pralka Red", Unit ="szt.", Price = 16M }
            };

        public HomeController (IValueCalculator calcParam, IValueCalculator calc2)
        {
            calc = calcParam;
        }

        // GET: Home (default View)
        public ActionResult Index()
        {
            //This tasks are solved by NinjectDepencyResolver registered in NinjectWebCommons
 
                //1. Preparing Ninject to use - create one piece of object kernel using StandardKernel
                //IKernel ninjectKernel = new StandardKernel();

                //2. Binding interface with class. Show Ninject which class is needed to respond the interface request 
                //ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();

                //3. Return interfece using get
                //IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();

            SumOfTable tab = new SumOfTable(calc) { Products = products };

            decimal totalValue = tab.CalculateProductTotal();

            //return default view (Views/Home/Index)
            return View(totalValue);
        }
    }
}







