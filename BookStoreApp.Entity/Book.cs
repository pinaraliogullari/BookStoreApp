using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public int TotalPages { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
