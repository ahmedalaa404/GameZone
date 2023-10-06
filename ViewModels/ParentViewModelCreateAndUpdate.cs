namespace GameZone.ViewModels
{
    public class ParentViewModelCreateAndUpdate
    {

        [MaxLength(250)]

        public string Name { get; set; } = string.Empty;


        [Display(Name = "Category")]
        public int CategoreyId { get; set; }

        public string Description { get; set; } = string.Empty;

        public IEnumerable<SelectListItem> Categores { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name = "Suppored Devices")]

        public List<int> SelectedDevices { get; set; }
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
