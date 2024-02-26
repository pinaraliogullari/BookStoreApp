using BookStoreApp.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Services.Abstract
{
    public interface IBookService
    {
        Task AddAsync(AddBookViewModel addBookViewModel);
        Task UpdateAsync(EditBookViewModel editBookViewModel);
        Task HardDeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task<BookViewModel> GetByIdAsync(int id);
        Task<List<BookViewModel>> GetAllAsync();
    }
}
