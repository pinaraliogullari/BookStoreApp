using BookStoreApp.Data.Abstract;
using BookStoreApp.Entity;
using BookStoreApp.Services.Abstract;
using BookStoreApp.Shared.ViewModels;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Services.Concrete
{
    public class PublisherService:IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task AddAsync(AddPublisherViewModel AddPublisherViewModel)
        {
            var publisher = AddPublisherViewModel.Adapt<Publisher>();
            await _publisherRepository.AddAsync(publisher);
        }

        public async Task<List<PublisherViewModel>> GetAllAsync()
        {
            var publishers = await _publisherRepository.GetAllAsync();
            var publishersViewModel = publishers.Adapt<List<PublisherViewModel>>();
            return publishersViewModel;
        }

        public async Task<PublisherViewModel> GetByIdAsync(int id)
        {
            var publisher = await _publisherRepository.GetAsync(x => x.Id == id);
            var publisherVewModel = publisher.Adapt<PublisherViewModel>();
            return publisherVewModel;
        }

        public async Task HardDeleteAsync(int id)
        {
            var publisher = await _publisherRepository.GetAsync(x => x.Id == id);
            await _publisherRepository.HardDeleteAsync(publisher);
        }

        public async Task SoftDeleteAsync(int id)
        {
            var publisher = await _publisherRepository.GetAsync(x => x.Id == id);
            await _publisherRepository.UpdateAsync(publisher);
        }

        public async Task UpdateAsync(EditPublisherViewModel editpublisherViewModel)
        {
            var publisher = editpublisherViewModel.Adapt<Publisher>();
            await _publisherRepository.UpdateAsync(publisher);
        }
    }
}
