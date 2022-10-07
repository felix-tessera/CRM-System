using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM_System.Models
{
    public class IngredientsCollection
    {
        public static ObservableCollection<Ingredient> Ingredients = new ObservableCollection<Ingredient>();
    }
}
