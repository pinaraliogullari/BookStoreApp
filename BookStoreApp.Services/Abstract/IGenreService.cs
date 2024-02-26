using BookStoreApp.Entity;
using BookStoreApp.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Services.Abstract
{
    public interface IGenreService
    {
        Task AddAsync(AddGenreViewModel addGenreViewModel);
        Task UpdateAsync(EditGenreViewModel editGenreViewModel);
        Task HardDeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task<GenreViewModel> GetByIdAsync(int id);
        Task<List<GenreViewModel>> GetAllAsync();
    }
}
