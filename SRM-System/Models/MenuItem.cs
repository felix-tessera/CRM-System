﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM_System.Models
{
    public class MenuItem
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }

        public ObservableCollection<Ingredient> MenuItemIngredients = new ObservableCollection<Ingredient>();
    }
}
