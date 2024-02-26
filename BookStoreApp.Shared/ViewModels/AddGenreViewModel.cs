using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Shared.ViewModels
{
    public class AddGenreViewModel
    {
        [Required(ErrorMessage = "This field cannot be left blank")]
        [DisplayName("Gender Name")]
        
        public string Name { get; set; }
    
    }
}
