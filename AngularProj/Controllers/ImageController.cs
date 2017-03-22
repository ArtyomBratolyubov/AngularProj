using System;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ORM;

namespace MvcPL.Controllers
{
    public class FileController : Controller
    {

        public FileResult GetFile(int id)
        {
            var db = new EntityModel();
            if (id > 0)
            {
                var file = db.Set<File>().FirstOrDefault(File => File.Id == id);

                if (file.Data != null && file.MimeType != null)
                    return File(file.Data, file.MimeType);
            }
            var path = Server.MapPath("~/Content/Images/noimagefound.jpg");
            var type = "image/jpg";

            return File(path, type);
        }

        [HttpPost]
        public void Create(HttpPostedFileBase file = null)
        {
            var File = new File()
            {
                MimeType = file.ContentType,
                Data = new byte[file.ContentLength]
            };


            file.InputStream.Read(File.Data, 0, file.ContentLength);

        }

    }
}