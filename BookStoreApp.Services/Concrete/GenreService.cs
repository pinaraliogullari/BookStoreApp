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
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task AddAsync(AddGenreViewModel addGenreViewModel)
        {
            var genre = addGenreViewModel.Adapt<Genre>();
             await _genreRepository.AddAsync(genre);
        }

        public async Task<List<GenreViewModel>> GetAllAsync()
        {
            var genres = await _genreRepository.GetAllAsync();
            var genresViewModel= genres.Adapt<List<GenreViewModel>>();
            return genresViewModel;
        }

        public async Task<GenreViewModel> GetByIdAsync(int id)
        {
            var genre= await _genreRepository.GetAsync(x=> x.Id == id);
            var genreViewModel= genre.Adapt<GenreViewModel>();
            return genreViewModel;
        }

        public async Task HardDeleteAsync(int id)
        {
           var genre= await _genreRepository.GetAsync(x=> x.Id == id);
            await _genreRepository.HardDeleteAsync(genre);
        }

        public async Task SoftDeleteAsync(int id)
        {
           var genre= await _genreRepository.GetAsync(x=> x.Id == id);
            await _genreRepository.UpdateAsync(genre);
        }

        public async Task UpdateAsync(EditGenreViewModel editGenreViewModel)
        {
             var genre=editGenreViewModel.Adapt<Genre>();
            await _genreRepository.UpdateAsync(genre);
        }
    }
}
