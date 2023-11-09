#nullable disable
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class SongsController : Controller
    {
        // TODO: Add service injections here
        private readonly ISongService _songService;
        private readonly IAlbumService _albumService;

        public SongsController(ISongService songService, IAlbumService albumService)
        {
            _songService = songService;
            _albumService = albumService;
        }

        // GET: Songs
        public IActionResult Index()
        {
            List<SongModel> songList = _songService.Query().ToList(); // TODO: Add get list service logic here
            return View(songList);
        }

        // GET: Songs/Details/5
        public IActionResult Details(int id)
        {
            SongModel song = _songService.Query().SingleOrDefault(s => s.Id == id); // TODO: Add get item service logic here
            if (song == null)
            {
                return NotFound();
            }
            return View(song);
        }

        // GET: Songs/Create
        public IActionResult Create()
        {
            // TODO: Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["AlbumId"] = new SelectList(_albumService.Query().ToList(), "Id", "Name");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SongModel song)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here
                bool result = _songService.Add(song);
                if (result)
                {
                    TempData["Message"] = "Song added successfully.";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Song couldn't be added!");
            }
            // TODO: Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["AlbumId"] = new SelectList(_albumService.Query().ToList(), "Id", "Name");
            return View(song);
        }

        // GET: Songs/Edit/5
        public IActionResult Edit(int id)
        {
            SongModel song = _songService.Query().SingleOrDefault(s => s.Id == id); // TODO: Add get item service logic here
            if (song == null)
            {
                return NotFound();
            }
            // TODO: Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["AlbumId"] = new SelectList(_albumService.Query().ToList(), "Id", "Name");
            return View(song);
        }

        // POST: Songs/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SongModel song)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                bool result = _songService.Update(song);
                if (result)
                {
                    TempData["Message"] = "Song updated successfully.";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Song couldn't be updated!");
            }
            // TODO: Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["AlbumId"] = new SelectList(_albumService.Query().ToList(), "Id", "Name");
            return View(song);
        }

        // GET: Songs/Delete/5
        public IActionResult Delete(int id)
        {
            SongModel song = _songService.Query().SingleOrDefault(s => s.Id == id); // TODO: Add get item service logic here
            if (song == null)
            {
                return NotFound();
            }
            return View(song);
        }

        // POST: Songs/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            _songService.Delete(id);
            TempData["Message"] = "Song deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
	}
}
