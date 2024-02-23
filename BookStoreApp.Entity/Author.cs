using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Entity
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public List<Book> Books { get; set; }
    }
}
