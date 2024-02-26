using BookStoreApp.Services.Abstract;
using BookStoreApp.Shared.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public async Task<IActionResult> Index()
        {
            var genres = await _genreService.GetAllAsync();
            var genresViewModel = genres.Adapt<List<GenreViewModel>>();
            return View(genresViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddGenreViewModel addGenreViewModel)
        {
                if(!ModelState.IsValid)
                {
                  return View(addGenreViewModel);
                }

             await _genreService.AddAsync(addGenreViewModel);
            return RedirectToAction(nameof(Create));
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var updatedGenre = await _genreService.GetByIdAsync(id);
            var updatedGenreViewModel = updatedGenre.Adapt<EditGenreViewModel>();
            return View(updatedGenreViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditGenreViewModel editGenreViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editGenreViewModel);
            }
       
            await _genreService.UpdateAsync(editGenreViewModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {
        
            await _genreService.SoftDeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {

            await _genreService.HardDeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
