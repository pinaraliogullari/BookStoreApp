using BookStoreApp.Services.Abstract;
using BookStoreApp.Shared.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
           _publisherService = publisherService;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _publisherService.GetAllAsync();
            var authorsViewModel = authors.Adapt<List<PublisherViewModel>>();
            return View(authorsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddPublisherViewModel addPublisherViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addPublisherViewModel);
            }

            await _publisherService.AddAsync(addPublisherViewModel);
            return RedirectToAction(nameof(Create));
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var updatedGenre = await _publisherService.GetByIdAsync(id);
            var updatedPublisherViewModel = updatedGenre.Adapt<EditPublisherViewModel>();
            return View(updatedPublisherViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditPublisherViewModel editPublisherViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editPublisherViewModel);
            }

            await _publisherService.UpdateAsync(editPublisherViewModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {

            await _publisherService.SoftDeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {

            await _publisherService.HardDeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
