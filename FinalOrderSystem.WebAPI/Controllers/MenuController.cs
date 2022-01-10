using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalOrderSystem.WebAPI.Core.Menu;

namespace FinalOrderSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuModule _menuModule;
        public MenuController(IMenuModule MenuModule)
        {
            _menuModule = MenuModule;
        }
        //private readonly MenuModule _menuModule = new MenuModule();
        [HttpGet]
        [Route("GetMenus")]
        public IEnumerable<FinalOrderSystem.DataClass.DataModels.Menu> GetMenus()
        {
            var result = _menuModule.GetMenus();
            return result;
        }

        [HttpGet]
        [Route("GetMenuByID")]
        public IEnumerable<FinalOrderSystem.DataClass.DataModels.Menu> GetMenuByID(string SID)
        {
            var result = _menuModule.GetMenuByID(SID);
            return result;
        }
        [HttpGet]
        [Route("GetMenuByName")]
        public IEnumerable<FinalOrderSystem.DataClass.DataModels.Menu> GetMenuByName(string Name)
        {
            var result = _menuModule.GetMenuByName(Name);
            return result;
        }

        [HttpPost]
        [Route("CreateMenu")]
        public bool CreateMenu(FinalOrderSystem.DataClass.DataModels.Menu model)
        {
            var result = _menuModule.CreateMenu(model);
            return result;
        }
        [HttpPost]
        [Route("EditMenu")]
        public bool EditMenu(FinalOrderSystem.DataClass.DataModels.Menu model)
        {
            var result = _menuModule.EditMenu(model);
            return result;
        }
        [HttpPost]
        [Route("DeleteMenu")]
        public bool DeleteMenu([FromBody]string SID)
        {
            var result = _menuModule.DeleteMenu(SID);
            return result;
        }
    }
}
