using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;

namespace PhotoGallaryMVC.Models {

    public static class Pictures {

        /// <summary>
        /// Непосредственно данные, коллекция картинок
        /// </summary>
        public static List<Picture> Pics { get; } = new List<Picture>();

        public static async Task GetFiles(string[] files) {

            await Task.Factory.StartNew(() => {
                Pics.Clear();
                files.ForEach(path => {
                    var fileInfo = new FileInfo(path);
                    var imageInfo = System.Drawing.Image.FromFile(path);
                    var pic = new Picture {
                        FullPath = path,
                        Url = path.Substring(path.LastIndexOf('/')+1, path.Length - path.LastIndexOf('/')-1),
                        Name = path.Substring(path.LastIndexOf('\\')+1, path.Length - path.LastIndexOf('\\')-1),
                        Size = (fileInfo.Length / 1024).ToString() + " кб",
                        DateDownload = fileInfo.CreationTime.ToShortDateString(),
                        Resolution = $"{imageInfo.Width}x{imageInfo.Height}"
                    };
                    imageInfo.Dispose();
                    if (!Pics.Contains(pic)) {
                        Pics.Add(pic);
                    } // if
                });
            });
        } // GetFiles
    } // Pictures
}