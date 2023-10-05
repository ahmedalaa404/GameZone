

namespace GameZone.Services
{
    public interface ICategorieyServices
    {

        public IEnumerable<SelectListItem> GetSelectList();
        public IEnumerable<SelectListItem> GetSelectListDevices();

    }
}
