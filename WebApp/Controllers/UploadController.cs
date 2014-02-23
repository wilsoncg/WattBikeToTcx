using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class UploadController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Select files to upload...";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Convert()
        {
            var r = new ViewDataUploadFilesResult();

            foreach (string file in Request.Files)
            {
                var uploadResult = new ViewDataUploadFilesResult();
                UploadWholeFile(Request, uploadResult);

                JsonResult result = Json(uploadResult);
                result.ContentType = "text/plain";

                return result;
            }

            return Json(r);
        }

       private void UploadWholeFile(System.Web.HttpRequestBase request, ViewDataUploadFilesResult statuses)
       {
           for (int i = 0; i < request.Files.Count; i++)
           {
               var file = request.Files[i];
               var storageRoot = Path.Combine(Server.MapPath("~/App_Data"));
               var fullPath = Path.Combine(storageRoot, Path.GetFileName(file.FileName));

               file.SaveAs(fullPath);

               statuses.files.Add(new File
               {
                   name = file.FileName,
                   size = file.ContentLength,
                   type = file.ContentType,
                   url = "/Home/Download/" + file.FileName,
                   deleteUrl = "/Home/Delete/" + file.FileName,
                   deleteType = "GET",
               });
           }
       }
    }

    public class ViewDataUploadFilesResult
    {
        private List<File> _files;
        public List<File> files { get { return _files; } set { _files = value; } }

        public ViewDataUploadFilesResult()
        {
            if (_files == null)
                _files = new List<File>();
        }
    }

    public class File
    {
        public string name { get; set; }
        public int size { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string deleteUrl { get; set; }
        public string deleteType { get; set; }
    }
}