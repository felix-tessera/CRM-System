using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRM_System.Models;
using Microsoft.Maui.Controls;

namespace SRM_System.Services
{
    public class OrderService
    {
        private const string FirebaseDatabaseUrl = "https://smr-system-data-default-rtdb.firebaseio.com/";
        private readonly FirebaseClient firebaseClient;
        public OrderService()
        {
            firebaseClient = new FirebaseClient(FirebaseDatabaseUrl);
        }
        public async void AddOrder(Order order)
        {
            var ord = await firebaseClient
            .Child("Order")
                .PostAsync(order);
            order.Key = ord.Key;
            await firebaseClient
               .Child("Order")
               .Child(order.Key)
               .PutAsync(order);
        }
        public async void GetOrder()
        {
            var ord = await firebaseClient
            .Child("Order")
            .OnceAsync<Order>();

        }
    }
}
