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
        public async Task AddOrder(Order order)
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
        public async Task GetOrders()
        {
            var ord = await firebaseClient
            .Child("Order")
            .OnceAsync<Order>();
            OrdersCollection.orders.Clear();
            MenuItemsFromOrdersCollection.menuItemmsFromOrders.Clear();
            foreach (var order in ord)
            {
                if (order.Object.OrderList != null)
                {
                    OrdersCollection.orders.Add(new Order
                    {
                        Key = order.Object.Key,
                        OrderList = order.Object.OrderList,
                        Table = order.Object.Table
                    });
                    for (int i = 0; i < order.Object.OrderList.Count; i++)
                    {
                        try
                        {
                            MenuItemsFromOrdersCollection.menuItemmsFromOrders.Add(new MenuItemm
                            {
                                OrderKey = order.Object.Key,
                                Key = i.ToString(),
                                Name = order.Object.OrderList[i].Name += $" {order.Object.Table} столик"
                            });
                        }
                        catch { }
                    } 
                }
                else
                {
                    await RemoveOrder(order.Object.Key);
                }
            }
        }
        public async Task RemoveMenuItemFromOrder(string OrderKey, string Index)
        {
            await firebaseClient
                .Child("Order")
                .Child(OrderKey)
                .Child("OrderList")
                .Child(Index)
                .DeleteAsync();
        }
        public async Task RemoveOrder(string Key)
        {
            await firebaseClient
               .Child("Order")
               .Child(Key)
               .DeleteAsync();

        }
        public async Task RemoveMenuItemFromCookMenuItemsList(string CookKey, string Index)
        {
            await firebaseClient
                .Child("Cook")
                .Child(CookKey)
                .Child("CookMenuItems")
                .Child(Index)
                .DeleteAsync();
        }
    }
}
