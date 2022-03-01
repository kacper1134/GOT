using GOT.Data;
using GOT.Data.Services;
using GOT.Models.Enums;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Controllers
{
    public class WeryfikacjaController : Controller
    {
        private readonly IWeryfikacjaService _service;
        private readonly int pageSize = 4;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public WeryfikacjaController(IWeryfikacjaService service, IWebHostEnvironment hostingEnvironment)
        {
            _service = service;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index(int pageNumber = 1, int filterOption = 3, int orderOption = 1)
        {
            _service.ChangeFilterAndOrderOptions(filterOption, orderOption);

            ViewData["Titles"] = await _service.GetTitlesByPageNumber(pageNumber, pageSize);

            ViewData["NoApplications"] = await _service.GetCount() == 0 ? "Brak wniosków do rozpatrzenia" : "";

            (ViewData["CurrentPageNumber"], ViewData["NextPageNumber"], ViewData["MaxPageNumber"]) = await _service.GetPageNumbers(pageNumber, pageSize);

            ViewData["filterOptionNumber"] = filterOption;

            ViewData["orderOptionNumber"] = orderOption;

            return View(await _service.GetByPageNumer(pageNumber, pageSize));
        }

        public async Task<IActionResult> ApplicationDetails(int id)
        {
            ViewData["ApplicationTitle"] = await _service.GetTitleById(id);
            (ViewData["TripStartDate"], ViewData["TripEndDate"]) = await _service.GetTripDuration(id);

            ViewData["TripSegments"] = await _service.GetTripSegments(id);

            return View(await _service.GetById(id));
        }

        public async Task<IActionResult> ApplicationDeclineReason(int id)
        {
            ViewData["ApplicationTitle"] = await _service.GetTitleById(id);
            (ViewData["TripStartDate"], ViewData["TripEndDate"]) = await _service.GetTripDuration(id);

            ViewData["TripSegments"] = await _service.GetTripSegments(id);

            return View(await _service.GetById(id));
        }

        public async Task<IActionResult> ApplicationAcceptUpdate(int id)
        {
            await _service.UpdateStatusById(id, Status.Zweryfikowany);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ApplicationDeclineUpdate(int id, string reason)
        {
            var (tmp, tmp2) = (id, reason);
            await _service.UpdateStatusById(id, Status.Odrzucony, reason);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DownloadZipFile(int id)
        {

            var fileName = string.Format("{0}_DowódTurysty.zip", DateTime.Today.Date.ToString("dd-MM-yyyy") + "_" + id);
            var tempOutPutPath = Path.Combine(_hostingEnvironment.WebRootPath, "zip", fileName);

            using (ZipOutputStream s = new ZipOutputStream(System.IO.File.Create(tempOutPutPath)))
            {
                s.SetLevel(9);

                byte[] buffer = new byte[4096];

                var images = await _service.GetImagesById(id);


                for (int i = 0; i < images.Count; i++)
                {
                    var image = Path.Combine(_hostingEnvironment.WebRootPath, "images", images[i]);

                    ZipEntry entry = new ZipEntry(Path.GetFileName(image)); 
                    entry.DateTime = DateTime.Now;
                    entry.IsUnicodeText = true;
                    s.PutNextEntry(entry);

                    using (FileStream fs = System.IO.File.OpenRead(image))
                    {
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            s.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                }
                s.Finish();
                s.Flush();
                s.Close();

            }

            byte[] finalResult = System.IO.File.ReadAllBytes(tempOutPutPath);
            if (System.IO.File.Exists(tempOutPutPath))
                System.IO.File.Delete(tempOutPutPath);

            if (finalResult == null || !finalResult.Any())
                throw new Exception(String.Format("No Files found with Image"));

            return File(finalResult, "application/zip", fileName);

        }
    }
}
