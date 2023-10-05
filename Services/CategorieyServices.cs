namespace GameZone.Services
{

    public class CategorieyServices : ICategorieyServices
    {
        private readonly ApplicationDbContext context;

        public CategorieyServices(ApplicationDbContext Context)
        {
            context = Context;
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
          return  context.Categoris.Select(x=>new SelectListItem { Text = x.Name,Value=x.Id.ToString() });  
        }

        public IEnumerable<SelectListItem> GetSelectListDevices()
        {
            return context.Devices.Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name })
                .OrderBy(x => x.Text)
                .ToList();
        }
    }

}