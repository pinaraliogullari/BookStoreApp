using BookStoreApp.Data.Abstract;
using BookStoreApp.Entity;
using BookStoreApp.Services.Abstract;
using BookStoreApp.Shared.ViewModels;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Services.Concrete
{
    public class BookService:IBookService

    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task AddAsync(AddBookViewModel addBookViewModel)
        {
            var book = addBookViewModel.Adapt<Book>();
            await _bookRepository.AddAsync(book);
        }

        public async Task<List<BookViewModel>> GetAllAsync()
        {
           var books= await _bookRepository.GetAllAsync(null,
                source => source
                    .Include(x => x.Publisher)
                    .Include(x => x.Genre)
                    .Include(x => x.Author));
            var result = books.Select(b => new BookViewModel
            {
                Id = b.Id,
                Title = b.Title,
                Isbn = b.Isbn,
                TotalPages = b.TotalPages,
                Publisher = new PublisherViewModel
                {
                    Id = b.Publisher.Id,
                    PublisherName = b.Publisher.PublisherName
                },
                Genre = new GenreViewModel
                {
                    Id = b.Genre.Id,
                    Name = b.Genre.Name
                },
                Author = new AuthorViewModel
                {
                    Id = b.Author.Id,
                    AuthorName = b.Author.AuthorName
                }
            }).ToList();

            return result;
        }


        public async Task<BookViewModel> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetAsync(x => x.Id == id);
            var bookVewModel = book.Adapt<BookViewModel>();
            return bookVewModel;
        }

        public async Task HardDeleteAsync(int id)
        {
            var book = await _bookRepository.GetAsync(x => x.Id == id);
            await _bookRepository.HardDeleteAsync(book);
        }

        public async Task SoftDeleteAsync(int id)
        {
            var book = await _bookRepository.GetAsync(x => x.Id == id);
            await _bookRepository.UpdateAsync(book);
        }

        public async Task UpdateAsync(EditBookViewModel editBookViewModel)
        {
            var book = editBookViewModel.Adapt<Book>();
            await _bookRepository.UpdateAsync(book);
        }
    }
}
