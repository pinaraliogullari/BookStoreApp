using BookStoreApp.Services.Abstract;
using BookStoreApp.Shared.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    public class AuthorController : Controller
    {
     private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAllAsync();
            var authorsViewModel = authors.Adapt<List<AuthorViewModel>>();
            return View(authorsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddAuthorViewModel addAuthorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addAuthorViewModel);
            }

            await _authorService.AddAsync(addAuthorViewModel);
            return RedirectToAction(nameof(Create));
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var updatedGenre = await _authorService.GetByIdAsync(id);
            var updatedAuthorViewModel = updatedGenre.Adapt<EditAuthorViewModel>();
            return View(updatedAuthorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditAuthorViewModel editAuthorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editAuthorViewModel);
            }

            await _authorService.UpdateAsync(editAuthorViewModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {

            await _authorService.SoftDeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {

            await _authorService.HardDeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
