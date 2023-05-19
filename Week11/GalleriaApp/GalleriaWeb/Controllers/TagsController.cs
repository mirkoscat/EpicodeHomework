using Microsoft.AspNetCore.Mvc;
using DataLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer;
using GalleriaWeb.Models.Entities;
using GalleriaWeb.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace GalleriaWeb.Controllers
{
	[Authorize(Roles = "SuperAdmin")]
   
	public class TagsController : Controller
    { 
        private readonly IGalleriaService gs;
        public TagsController(IGalleriaService gs)
        {   
            this.gs=gs;
        }
        // GET: TagsController
        public ActionResult Index()
        {   
            var tags = gs.GetTags().ToList();
            var model = tags.Select(t => new TagModel { Id= t.Id,Name=t.Name}) ;
            return View(model);
        }
        public IActionResult AssegnaTag(int id)
        {
            var image = gs.GetImageById(id);
            var allTags = gs.GetTags().ToList();
            var model = new AssegnaTagViewModel
            {   
                Image = image,
                Tags = allTags
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult AssegnaTag(AssegnaTagViewModel m)
        {
            
            if (ModelState.IsValid) {
                var lista = new List<int>();
                foreach (var p in m.Tags)
                {
                    if (p.IsChecked)
                    {
                        lista.Add(p.Id);
                    }
                }

                gs.AssegnaTag(m.Id,lista);
                return RedirectToAction("List","Galleria");
            }
           return View(m);
        }


        // GET: TagsController/Create
        public ActionResult Create()
        { 
            return View();
        }

        // POST: TagsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TagModel m)
        {
            try
            {
                gs.CreateTag(m.Name);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TagsController/Delete/5
        public ActionResult Delete(int id)
        {
			gs.DeleteTag(id);
			return RedirectToAction(nameof(Index));
		}

    }
}
