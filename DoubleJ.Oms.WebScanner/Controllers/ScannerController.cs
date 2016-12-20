using System;
using System.Configuration;
using System.IO;
using System.Web.Mvc;

namespace DoubleJ.Oms.WebScanner.Controllers
{
    public class ScannerController : Controller
    {
        // GET: Scanner
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);
            var filePath = ConfigurationManager.AppSettings["WebScannerFilePath"]??"";
            System.IO.File.WriteAllBytes(string.Concat(filePath, fileName), fileContents);
            return RedirectToAction("Index");
        }
    }
}