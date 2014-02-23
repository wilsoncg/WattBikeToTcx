using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class UploadController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Select files to upload...";

            return View();
        }

        public FileContentResult File(string id)
        {
            var path = Server.MapPath(string.Format("~/Uploads/{0}", id));
            if (!System.IO.File.Exists(path))
                return null;

            var contents = System.IO.File.ReadAllBytes(path);
            return new FileContentResult(contents, "text/plain");
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
               var storageRoot = Path.Combine(Server.MapPath("~/Uploads"));
               var fileName = file.FileName;
               var fullPath = Path.Combine(storageRoot, Path.GetFileName(fileName));

               file.SaveAs(fullPath);

               //var encodedFileName = Server.UrlEncode(fileName);
               statuses.files.Add(new UploadedFile
               {
                   name = fileName,
                   size = file.ContentLength,
                   type = file.ContentType,
                   url = Url.Action("File","Upload") + "/?id=" + fileName,
                   deleteUrl = Url.Action("File", "Upload") + "/?id=" + fileName,
                   deleteType = "DELETE",
               });
           }
       }
    }

    public class ViewDataUploadFilesResult
    {
        private List<UploadedFile> _files;
        public List<UploadedFile> files { get { return _files; } set { _files = value; } }

        public ViewDataUploadFilesResult()
        {
            if (_files == null)
                _files = new List<UploadedFile>();
        }
    }

    public class UploadedFile
    {
        public string name { get; set; }
        public int size { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string deleteUrl { get; set; }
        public string deleteType { get; set; }
    }
}