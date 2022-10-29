using Firebase.Database;
using Firebase.Database.Query;
using Org.Apache.Http.Authentication;
using SRM_System.Models;
using SRM_System.RegisterLogic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SRM_System.Services
{
    public class AdminService
    {
        private const string FirebaseDatabaseUrl = "https://smr-system-data-default-rtdb.firebaseio.com/";
        private readonly FirebaseClient firebaseClient;

        public AdminService()
        {
            firebaseClient = new FirebaseClient(FirebaseDatabaseUrl);
        }
        public async Task AddAdmin(Admin admin)
        {
            await firebaseClient
              .Child("Admin")
              .PostAsync(admin);
        }
        public async void GetAdmin(string Login, string Password)
        {
            var admins = await firebaseClient
              .Child("Admin")
              .OnceAsync<Admin>();

            foreach(var admin in admins)
            {
                if (admin.Object.Login == Login && admin.Object.Password == Password)
                {
                    await Shell.Current.GoToAsync("AdminMainPage");
                    return;
                }
                else
                {
                    
                }
            }
        }
    }
}
