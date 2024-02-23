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
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookStoreAppContext _context) : base(_context)
        {
        }
        private BookStoreAppContext bookStoreAppContext
        {
            get { return _dbContext as BookStoreAppContext; }
        }

    }
}
