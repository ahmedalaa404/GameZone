using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.ViewModels
{
    public class CreateGameFromViewModel
    {
        [MaxLength(250)]

        public string Name { get; set; } = string.Empty;


        [Display(Name="Category")]
        public int CategoreyId { get; set; }



        public IEnumerable<SelectListItem> Categores { get; set; } = Enumerable.Empty<SelectListItem>();
        public List<int> SelectedDevices { get; set; } = new List<int>();


        [Display(Name="Suppored Devices")]
        public IEnumerable<SelectListItem>Devices { get; set; }=Enumerable.Empty<SelectListItem>();

        public IFormFile Cover { get; set; } = default!; // It`s fILES
        public string Description { get; set; } = string.Empty;




    }
}
