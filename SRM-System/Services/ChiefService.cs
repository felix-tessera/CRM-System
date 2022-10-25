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
    public class ChiefService
    {
        private const string FirebaseDatabaseUrl = "https://smr-system-data-default-rtdb.firebaseio.com/";
        private readonly FirebaseClient firebaseClient;
        public bool isNameMatch = true;
        public ChiefService()
        {
            firebaseClient = new FirebaseClient(FirebaseDatabaseUrl);
        }
        public async Task AddChief(Chief chief)
        {
            await firebaseClient
              .Child("Chief")
              .PostAsync(chief);
        }
        public async void GetChief(string Login, string Password)
        {
            var chiefs = await firebaseClient
              .Child("Chief")
              .OnceAsync<Chief>();

            foreach (var chief in chiefs)
            {
                if (chief.Object.Login == Login && chief.Object.Password == Password)
                {
                    await Shell.Current.GoToAsync("ChiefMainPage");
                    return;
                }
                else
                {

                }
            }
        }
    }
}
