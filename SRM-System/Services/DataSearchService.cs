using SRM_System.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM_System.Services
{
    public class DataSearchService
    {
        public ObservableCollection<MenuItemm> SearchingMenuItems = new ObservableCollection<MenuItemm>();
        public async Task SearchInMenuItemListAsync(string searchText)
        {
            await Task.Run(() => SearchInMenuItemList(searchText)); 
        }
        public void SearchInMenuItemList(string searchText)
        {
            SearchingMenuItems.Clear();
            for (int i = 0; i < MenuItemsCollection.MenuItems.Count; i++)
            {
                bool isMatch = MenuItemsCollection.MenuItems[i].Name.ToLower().Contains(searchText.ToLower());
                if (isMatch)
                {
                    SearchingMenuItems.Add(MenuItemsCollection.MenuItems[i]);
                }
            }
        }
    }
}
