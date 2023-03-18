using LoteriaExamen.Bussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoteriaExamen.Controllers
{
    public class HomeController : Controller
    {
        private Bcards bcards = new Bcards();
        private LoteriaEntities db = new LoteriaEntities();

        // GET: Home



        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult getTablas(int total)
        {


            Dictionary<string, object> result =bcards.GetTarjetas(total);

       



            return Json(new {result=result, tabla= result.Keys }, JsonRequestBehavior.AllowGet);
        }

      
    }
}
