using DataLayer;
using GalleriaWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace GalleriaWeb.Controllers
{
	public class GalleriaController : Controller
	{
		private readonly IGalleriaService _service;

		public GalleriaController(IGalleriaService service)
		{
			_service = service;
		}
        [Authorize]
		public IActionResult Index()
		{
			return View();
		}

        [HttpPost]
        public IActionResult Upload(UploadImageViewModel model)
        {
            try
            {
                var image = new Image
                {
                    Title = model.Title,
                    Username = User.Identity.Name,
                    Format = model.File.ContentType
                };
                using (var ms = new MemoryStream())
                {
                    model.File.CopyTo(ms);
                    // "riavvolgiamo" lo stream
                    ms.Seek(0, SeekOrigin.Begin);
                    image.Content = ms.ToArray();
                }
                _service.Upload(image);
                return RedirectToAction(nameof(List));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }
		public IActionResult Delete(int id)
		{
			_service.DeleteImage(id);
			return RedirectToAction(nameof(List));

		}

        public IActionResult List()
        {
            var images = _service.GetImages();
           
            var model = images.Select(i => new ImageViewModel
            {
                Format = i.Format,
                Id = i.Id,
                Title = i.Title,
                Username = i.Username,
                Size = i.Content.Length / 1024,
                Tags= i.Tags
			});
            return View(model);
        }

        public IActionResult GetImage(int id)
        {
            var img = _service.GetImageById(id);
            // trasformare l'immagine in file 
            // per restituirla al browser
            return File(img.Content, img.Format);
        }
    }
}
