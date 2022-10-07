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
    public class IngredientsService
    {
        private const string FirebaseDatabaseUrl = "https://smr-system-data-default-rtdb.firebaseio.com/";
        private readonly FirebaseClient firebaseClient;
        public IngredientsService()
        {
            firebaseClient = new FirebaseClient(FirebaseDatabaseUrl);
        }
        public async Task AddIngredient(Ingredient ingredient)
        {
            var tbl = await firebaseClient
              .Child("Ingredients")
              .PostAsync(ingredient);
            ingredient.Key = tbl.Key;
            await firebaseClient
                .Child("Ingredients")
                .Child(ingredient.Key)
                .PutAsync(ingredient);
        }
        public async void GetTables()
        {
            var ingredients = await firebaseClient
              .Child("Ingredients")
              .OnceAsync<Ingredient>();
            var SortedIngredients = from i in ingredients//сортировка по id
                               orderby i.Object.Id
                               select i;
            IngredientsCollection.Ingredients.Clear();
            foreach (var ingredient in SortedIngredients)//Запись ингредиентов в firebase
            {
                IngredientsCollection.Ingredients.Add(new Ingredient
                {
                    Id = ingredient.Object.Id,
                    Name = ingredient.Object.Name,
                    Quantity = ingredient.Object.Quantity,
                    Key = ingredient.Object.Key,
                });
            }
        }
        public async void RemoveIngredient(string Key)
        {
            await firebaseClient
        .Child("Ingredients")
        .Child(Key)
        .DeleteAsync();
        }
        public async void UpdateIngredients(Ingredient ingredient)
        {
            await firebaseClient
                .Child("Ingredients")
                .Child(ingredient.Key)
                .PutAsync(ingredient);
        }
    }
}
