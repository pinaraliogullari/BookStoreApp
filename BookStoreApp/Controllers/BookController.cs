using BookStoreApp.Services.Abstract;
using BookStoreApp.Shared.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;
        private readonly IPublisherService _publisherService;

        public BookController(IBookService bookService, IAuthorService authorService, IGenreService genreService, IPublisherService publisherService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _genreService = genreService;
            _publisherService = publisherService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllAsync();
            return View(books);
        }

        
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var authors = await _authorService.GetAllAsync();

            List<SelectListItem> authorListItem = authors
               .Select(a => new SelectListItem
               {
                   Text = a.AuthorName,
                   Value = a.Id.ToString()
               }).ToList();
            var publishers = await _publisherService.GetAllAsync();
            List<SelectListItem> publisherListItem = publishers
                .Select(p => new SelectListItem
                {
                    Text = p.PublisherName,
                    Value = p.Id.ToString()
                }).ToList();
            var genres = await _genreService.GetAllAsync();
            List<SelectListItem> genreListItem = genres
              .Select(g => new SelectListItem
              {
                  Text = g.Name,
                  Value = g.Id.ToString()
              }).ToList();
            AddBookViewModel model = new AddBookViewModel
            {
                AuthorList = authorListItem,
                PublisherList = publisherListItem,
                GenreList = genreListItem

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddBookViewModel addBookViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addBookViewModel);
            }
         
            await _bookService.AddAsync(addBookViewModel);
            return RedirectToAction("Index");
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
