using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Shared.ViewModels
{
    public class EditBookViewModel
    {
        [DisplayName("Title")]
        [Required(ErrorMessage = "")]
        public string Title { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "")]
        public string Isbn { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "")]
        public int TotalPages { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "")]
        public List<SelectListItem> AuthorList { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "")]
        public List<SelectListItem> GenreList { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "")]
        public List<SelectListItem> PublisherList { get; set; }
    }
}
