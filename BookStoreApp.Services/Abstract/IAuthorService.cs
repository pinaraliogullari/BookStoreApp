using BookStoreApp.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Services.Abstract
{
    public interface IAuthorService
    {
        Task AddAsync(AddAuthorViewModel addAuthorViewModel);
        Task UpdateAsync(EditAuthorViewModel editAuthorViewModel);
        Task HardDeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task<AuthorViewModel> GetByIdAsync(int id);
        Task<List<AuthorViewModel>> GetAllAsync();
    }
}
