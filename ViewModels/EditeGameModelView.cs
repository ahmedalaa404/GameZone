

namespace GameZone.ViewModels
{
    public class EditeGameModelView:ParentViewModelCreateAndUpdate
    {
        public int Id { get; set; }

        //[Extension("")] // Make Errot In Mvc With Render

        public string? CurrentCover { get; set; } = default!; // It`s fILES

        [AllowExtenstion(FileSetting.AllowExtenstions),
            MaxFileSize(FileSetting.MaxFileSizeBytes)]
        public IFormFile? Cover { get; set; } = default!;


    }
}
