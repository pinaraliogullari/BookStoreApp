using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Shared.ViewModels
{
    public class AddAuthorViewModel
    {

        [Required(ErrorMessage = "\r\nPlease do not leave this field blank ")]
        public string AuthorName { get; set; }

    }
}
