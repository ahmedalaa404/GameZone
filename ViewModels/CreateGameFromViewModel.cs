

namespace GameZone.ViewModels
{
    public class CreateGameFromViewModel: ParentViewModelCreateAndUpdate
    {
       
        //[Extension("")] // Make Errot In Mvc With Render
        [AllowExtenstion(FileSetting.AllowExtenstions),
            MaxFileSize(FileSetting.MaxFileSizeBytes)]
        public IFormFile Cover { get; set; } = default!; // It`s fILES





    }
}
