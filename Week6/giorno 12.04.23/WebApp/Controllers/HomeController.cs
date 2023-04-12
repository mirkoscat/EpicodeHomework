using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller //System.Web.Mvc
    {
        public ActionResult Index()
        {
            return View();
           //consente di attivare una vista che per default si chiama come la action
           //e si trova dentro Views, con lo stesso nome del controller es. ClienteController
        //vedo index.cshtml
        }

        private List<string> GeneraBinari(List<int> numeri)
        {
            List<string> binari = new List<string>();

            foreach (int numero in numeri)
            {
                string binario = Convert.ToString(numero, 2);
                binari.Add(binario);
            }

            return binari;
        }

        private List<int> GeneraNumeri()
        {
            List<int> numeri = new List<int>();

            for (int i = 0; i <= 500; i++)
            {
                numeri.Add(i);
            }

            return numeri;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}