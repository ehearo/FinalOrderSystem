using FinalOrderSystem.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalOrderSystem.DataClass.DataModels;

namespace FinalOrderSystem.WebAPI.Core.Menu
{

    public class MenuModule 
    {
        private readonly MenuRepository _menuRepository = new MenuRepository();


        public IEnumerable<FinalOrderSystem.DataClass.DataModels.Menu> GetMenus()
        {
            var result = _menuRepository.GetMenus();
            return result;
        }

        public IEnumerable<FinalOrderSystem.DataClass.DataModels.Menu> GetMenuByID(String SID)
        {
            var result = _menuRepository.GetMenuByID(SID);
            return result;
        }

        public IEnumerable<FinalOrderSystem.DataClass.DataModels.Menu> GetMenuByName(String Name)
        {
            var result = _menuRepository.GetMenuByName(Name);
            return result;
        }

        public bool CreateMenu(FinalOrderSystem.DataClass.DataModels.Menu Menu)
        {
            var result = _menuRepository.CreateMenu(Menu);
            return result;
        }
        public bool EditMenu(FinalOrderSystem.DataClass.DataModels.Menu Menu)
        {
            var result = _menuRepository.EditMenu(Menu);
            return result;
        }
        public bool DeleteMenu(String SID)
        {
            var result = _menuRepository.DeleteMenu(SID);
            return result;
        }
    }   
}
