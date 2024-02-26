using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Shared.ViewModels
{
    public class AddPublisherViewModel
    {
        [Required(ErrorMessage = "This field cannot be left blank")]
        public string PublisherName { get; set; }

    }
}
