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
            await firebaseClient
              .Child("Cook")
              .PostAsync(cook);
        }
        public async void GetCooks(string Login, string Password)
        {
            var cooks = await firebaseClient
              .Child("Cook")
              .OnceAsync<Cook>();

            foreach (var cook in cooks)
            {
                if (cook.Object.Login == Login && cook.Object.Password == Password)
                {
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
            CummonCollection<Cook>.cummonList.Clear();
            foreach(var cook in cooks)
            {
                CummonCollection<Cook>.cummonList.Add(new Cook
                {
                    Login = cook.Object.Login,
                    Password = cook.Object.Password,
                    Name = cook.Object.Name
                });
            }
        }
    }
}
