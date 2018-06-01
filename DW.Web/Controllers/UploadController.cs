using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeliveryWizard;


namespace DW.Web.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Print(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var dto = DeliverySerializer.LoadFromStream(file.InputStream);
                return View(dto);
            }

            return RedirectToAction("Index");
        }
    }
}