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
    public class AuthorService:IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task AddAsync(AddAuthorViewModel addAuthorViewModel)
        {
            var author = addAuthorViewModel.Adapt<Author>();
            await _authorRepository.AddAsync(author);
        }

        public async Task<List<AuthorViewModel>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            var authorsViewModel = authors.Adapt<List<AuthorViewModel>>();
            return authorsViewModel;
        }

        public async Task<AuthorViewModel> GetByIdAsync(int id)
        {
            var author = await _authorRepository.GetAsync(x => x.Id == id);
            var authorVewModel = author.Adapt<AuthorViewModel>();
            return authorVewModel;
        }

        public async Task HardDeleteAsync(int id)
        {
            var author = await _authorRepository.GetAsync(x => x.Id == id);
            await _authorRepository.HardDeleteAsync(author);
        }

        public async Task SoftDeleteAsync(int id)
        {
            var author = await _authorRepository.GetAsync(x => x.Id == id);
            await _authorRepository.UpdateAsync(author);
        }

        public async Task UpdateAsync(EditAuthorViewModel editAuthorViewModel)
        {
            var author = editAuthorViewModel.Adapt<Author>();
            await _authorRepository.UpdateAsync(author);
        }
    }
}
