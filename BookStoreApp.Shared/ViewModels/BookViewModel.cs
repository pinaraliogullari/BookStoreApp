using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Shared.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public int TotalPages { get; set; }
        public AuthorViewModel Author { get; set; }
        public PublisherViewModel Publisher { get; set; }
        public GenreViewModel Genre { get; set; }
    }
}
