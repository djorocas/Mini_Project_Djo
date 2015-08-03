using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class IdGeneratorController : Controller
    {
        
        //
        // GET: /IdGenerator/

        public ActionResult Index()
        {
            MiniProject mini = new MiniProject();
            mini.id = mini.Generate_ID();

            return View(mini);
        }

        [HttpPost]
        public JsonResult Index(FormCollection formdata)
        {

                 MiniProject mini = new MiniProject();
                 return Json(mini.Validate(formdata["idnumber"])); 
        }
    }
}
