using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;

namespace GameZone.ViewModels
{
    public class CreateGameFromViewModel
    {
        [MaxLength(250)]

        public string Name { get; set; } = string.Empty;


        [Display(Name="Category")]
        public int CategoreyId { get; set; }



        public IEnumerable<SelectListItem> Categores { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name = "Suppored Devices")]

        public List<int> SelectedDevices { get; set; } 
        public IEnumerable<SelectListItem>Devices { get; set; }=Enumerable.Empty<SelectListItem>();

        //[Extension("")] // Make Errot In Mvc With Render
        public IFormFile Cover { get; set; } = default!; // It`s fILES
        public string Description { get; set; } = string.Empty;




    }
}
