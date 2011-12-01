using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using CalculatorInterfaces;

namespace CalculatorWithExtensions.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private CompositionContainer _container;

        [Import(typeof(ICalculator))]
        public ICalculator calculator;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Server.MapPath("~\\Plugins")));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(HomeController).Assembly));

            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            ViewData.Model = calculator;
            ViewData["Result"] = "";
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(string mathstring)
        {
            ViewData.Model = calculator;
            ViewData["Result"] = calculator.Calculate(mathstring);
            return View();
        }

        private float DoCalc(string mathstring)
        {
            throw new NotImplementedException();
        }
    }
}
