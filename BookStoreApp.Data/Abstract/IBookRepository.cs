using BookStoreApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Data.Abstract
{
    public interface IBookRepository:IGenericRepository<Book>
    {
    }
}
