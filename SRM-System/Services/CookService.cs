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
    public class CookService
    {
        private const string FirebaseDatabaseUrl = "https://smr-system-data-default-rtdb.firebaseio.com/";
        private readonly FirebaseClient firebaseClient;
        public CookService()
        {
            firebaseClient = new FirebaseClient(FirebaseDatabaseUrl);
        }
        public async Task AddCook(Cook cook)
        {
           var ck = await firebaseClient
              .Child("Cook")
              .PostAsync(cook);
            cook.Key = ck.Key;
            await firebaseClient
                .Child("Cook")
                .Child(cook.Key)
                .PutAsync(cook);
        }
        public async void GetCook(string Login, string Password)
        {
            var cooks = await firebaseClient
              .Child("Cook")
              .OnceAsync<Cook>();

            foreach (var cook in cooks)
            {
                if (cook.Object.Login == Login && cook.Object.Password == Password)
                {
                    Common.GlogalCookService.CurrentCookPerson = new Cook{
                        Login = cook.Object.Login,
                        Password = cook.Object.Password,
                        Name = cook.Object.Name,
                        CookMenuItems = cook.Object.CookMenuItems,
                        Key = cook.Object.Key
                    };
                    await Shell.Current.GoToAsync("CookMainPage");
                    return;
                }
                else
                {

                }
            }
        }
        public async Task GetCooksPersons()
        {
            var cooks = await firebaseClient
              .Child("Cook")
              .OnceAsync<Cook>();
            CummonCollection.cooksList.Clear();
            foreach(var cook in cooks)
            {
                CummonCollection.cooksList.Add(new Cook
                {
                    Login = cook.Object.Login,
                    Password = cook.Object.Password,
                    Name = cook.Object.Name,
                    CookMenuItems = cook.Object.CookMenuItems,
                    Key = cook.Object.Key
                });
            }
        }
        public async Task UpdateCook(Cook cook)
        {
            await firebaseClient
                .Child("Cook")
                .Child(cook.Key)
                .PutAsync(cook);
        }
    }
}
