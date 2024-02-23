using BookStoreApp.Data.Abstract;
using BookStoreApp.Data.Concrete.Contexts;
using BookStoreApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Data.Concrete.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(BookStoreAppContext _context) : base(_context)
        {
        }

        private BookStoreAppContext bookStoreAppContext
        {
            get { return _dbContext as BookStoreAppContext; }
        }
    }
}
