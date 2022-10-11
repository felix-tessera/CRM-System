using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRM_System.Models;

namespace SRM_System.Services
{
    public class MenuItemService
    {
        private const string FirebaseDatabaseUrl = "https://smr-system-data-default-rtdb.firebaseio.com/";
        private readonly FirebaseClient firebaseClient;
        public MenuItemService()
        {
            firebaseClient = new FirebaseClient(FirebaseDatabaseUrl);
        }
        public async Task AddMenuItem(MenuItemm menuItem)
        {
            var mui = await firebaseClient
                .Child("MenuItems")
                .PostAsync(menuItem);
            menuItem.Key = mui.Key;
            await firebaseClient
                .Child("MenuItems")
                .Child(menuItem.Key)
                .PutAsync(menuItem);
        }
        public async void GetMenuItems()
        {
            var menuItems = await firebaseClient
                .Child("MenuItems")
                .OnceAsync<MenuItemm>();
            MenuItemsCollection.MenuItems.Clear();
            foreach (var menuItem in menuItems)
            {
                MenuItemsCollection.MenuItems.Add(new MenuItemm
                {
                    Key = menuItem.Object.Key,
                    Currency = menuItem.Object.Currency,
                    Name = menuItem.Object.Name,
                    Price = menuItem.Object.Price,
                });
            }
        }
        public async void RemoveMenuItem(string Key)
        {
            await firebaseClient
                .Child("MenuItems")
                .Child(Key)
                .DeleteAsync();
        }
        public async void UpdateMenuItem(MenuItemm menuItemm)
        {
            await firebaseClient
                .Child("MenuItems")
                .Child(menuItemm.Key)
                .PutAsync(menuItemm);
        }
    }
}
