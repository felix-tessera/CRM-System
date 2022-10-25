using Firebase.Database;
using Firebase.Database.Query;
using SRM_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM_System.Services
{
    public class DoneMenuItemService
    {
        private const string FirebaseDatabaseUrl = "https://smr-system-data-default-rtdb.firebaseio.com/";
        private readonly FirebaseClient firebaseClient;
        public DoneMenuItemService()
        {
            firebaseClient = new FirebaseClient(FirebaseDatabaseUrl);
        }
        public async Task AddDoneMenuItem(MenuItemm menuItemm)
        {
            var dmi = await firebaseClient
            .Child("DoneMenuItems")
                .PostAsync(menuItemm);
            menuItemm.Key = dmi.Key;
            await firebaseClient
               .Child("DoneMenuItems")
               .Child(menuItemm.Key)
               .PutAsync(menuItemm);
        }
        public async void GetDoneMenuItems()
        {
            var donemenuitems = await firebaseClient
                .Child("DoneMenuItems")
                .OnceAsync<MenuItemm>();
            DoneMenuItemsCollection.doneItems.Clear();
            foreach (var menuItem in donemenuitems)
            {
                DoneMenuItemsCollection.doneItems.Add(new MenuItemm
                {
                    Key = menuItem.Object.Key,
                    Currency = menuItem.Object.Currency,
                    Name = menuItem.Object.Name,
                    Price = menuItem.Object.Price,
                });
            }
        }
    }
}
