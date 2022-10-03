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
    public class HallMenagerService
    {
        private const string FirebaseDatabaseUrl = "https://smr-system-data-default-rtdb.firebaseio.com/";
        private readonly FirebaseClient firebaseClient;
        public HallMenagerService()
        {
            firebaseClient = new FirebaseClient(FirebaseDatabaseUrl);
        }
        public async Task AddHallMenager(HallMenager hallMenager)
        {
            await firebaseClient
              .Child("HallMenager")
              .PostAsync(hallMenager);
        }
        public async void GetHallMenager(string Login, string Password)
        {
            var hallMenagers = await firebaseClient
              .Child("HallMenager")
              .OnceAsync<HallMenager>();

            foreach (var hallMenager in hallMenagers)
            {
                if (hallMenager.Object.Login == Login && hallMenager.Object.Password == Password)
                {
                    await Shell.Current.GoToAsync("HallMenagerMainPage");
                    return;
                }
                else
                {

                }
            }
        }
    }
}
