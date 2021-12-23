using Microsoft.AspNetCore.Mvc;
using FinalOrderSystem.Web.Core.Menu;
namespace FinalOrderSystem.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuModule _menuModule = new MenuModule();
        public IActionResult Index()
        {
            var data = _menuModule.GetMenus();
            return View(data);
        }
        public IActionResult News()
        {
            return View();
        }
        public IActionResult ListMenu()
        {
            var data = _menuModule.GetMenus();
            return View(data);
        }
   
        public IActionResult CreateMenu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMenu(FinalOrderSystem.DataClass.DataModels.Menu model)
        {
            var data = _menuModule.CreateMenu(model);
            return RedirectToAction("ListMenu");
        }
        public IActionResult GetMenuByName(String Name)
        {
            var data = _menuModule.GetMenuByName(Name);
            return View(data);
        }

        public IActionResult EditMenu(String SID)
        {
            var data = _menuModule.GetMenuByID(SID);
            return View(data);
        }
        [HttpPost]
        public IActionResult EditMenu(FinalOrderSystem.DataClass.DataModels.Menu model)
        {
            var data = _menuModule.EditMenu(model);
            return RedirectToAction("ListMenu");
        }
        [HttpPost]
        public IActionResult DeleteMenu(string SID)
        {
            var data = _menuModule.DeleteMenu(SID);
            return RedirectToAction("ListMenu");
        }
    }
}
