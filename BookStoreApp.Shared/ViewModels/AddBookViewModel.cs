using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreApp.Shared.ViewModels
{
    public class AddBookViewModel
    {


        [DisplayName("Title")]
        [Required(ErrorMessage = "Please do not left blank this field.")]
        public string Title { get; set; }

        [DisplayName("Isbn")]
        [Required(ErrorMessage = "Please do not left blank this field.")]
        public string Isbn { get; set; }

        [DisplayName("Total Page")]
        [Required(ErrorMessage = "Please do not left blank this field.")]
        public int TotalPages { get; set; }

        [DisplayName("Authors")]
        [Required(ErrorMessage = "Please do not left blank this field.")]
        public List<SelectListItem> AuthorList { get; set; }

        [DisplayName("Genres")]
        [Required(ErrorMessage = "Please do not left blank this field.")]
        public List<SelectListItem> GenreList { get; set; }

        [DisplayName("Publishers")]
        [Required(ErrorMessage = "Please do not left blank this field.")]
        public List<SelectListItem> PublisherList { get; set; }

    }
}
