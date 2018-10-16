using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PhotoGallaryMVC.Models;
using WebGrease.Css.Extensions;

namespace PhotoGallaryMVC.Controllers {

    public class HomeController : Controller {

        public async Task<ActionResult> Index() {

            await Pictures.GetFiles(Directory.GetFiles(Server.MapPath("/") + "/Pictures"));
            return View(Pictures.Pics);
        } // Index

        public async Task<ActionResult> Upload(HttpPostedFileBase[] uploads) {

            if (uploads?[0] != null) {
                await Task.Factory.StartNew(() => {
                    uploads.ForEach(file => {
                        var fileName = Path.GetFileName(file.FileName);
                        file.SaveAs(Server.MapPath("~/Pictures/" + fileName));
                    });
                    ViewBag.UploadStatus = $"{uploads.Length} файлов успешно загружено!";
                });
            }
            return RedirectToAction("Index");
        } // Upload

        public ActionResult Delete(string path) {

            if (path == null)
                return RedirectToAction("Index");

            Picture deletePic = null;

            Pictures.Pics.ForEach(pic => {
                if (!pic.FullPath.Equals(path))
                    return;
                System.IO.File.Delete(path);
                deletePic = pic;
            });

            if (deletePic == null)
                RedirectToAction("Index");

            Pictures.Pics.Remove(deletePic);

            return RedirectToAction("Index");
        } // Delete

        public ActionResult About() {

            return View();
        } // About
    } // HomeController
}