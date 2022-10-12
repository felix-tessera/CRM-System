using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM_System.Models
{
    public class Order
    {
        public string Key { get; set; }
        public string Table { get; set; }
        public ObservableCollection<MenuItemm> OrderList { get; set; }
    }
}
