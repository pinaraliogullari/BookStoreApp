using BookStoreApp.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Services.Abstract
{
    public interface IPublisherService
    {
        Task AddAsync(AddPublisherViewModel addPublisherViewModel);
        Task UpdateAsync(EditPublisherViewModel editPublisherViewModel);
        Task HardDeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task<PublisherViewModel> GetByIdAsync(int id);
        Task<List<PublisherViewModel>> GetAllAsync();
    }
}
