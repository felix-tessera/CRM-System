using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using Firebase.Database;
using SRM_System.Models;
using System.Collections.ObjectModel;

namespace SRM_System.Services
{
    public class TableService
    {
        private const string FirebaseDatabaseUrl = "https://smr-system-data-default-rtdb.firebaseio.com/";
        private readonly FirebaseClient firebaseClient;
        public TableService()
        {
            firebaseClient = new FirebaseClient(FirebaseDatabaseUrl);
        }
        public async Task AddTable(Table table)
        {
            await firebaseClient
              .Child("Table")
              .PostAsync(table);
        }
        public async void GetTables()
        {
            var tables = await firebaseClient
              .Child("Table")
              .OnceAsync<Table>();
            TablesCollection.CleanCollection();
            foreach (var table in tables)
            {
                TablesCollection.Tables.Add(new Table
                {
                    Id = table.Object.Id,
                    Seats = table.Object.Seats,
                    State = table.Object.State,
                });
            }
        }
    }
}
