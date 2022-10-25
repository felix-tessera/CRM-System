using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM_System.Models
{
    public class Cook
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public ObservableCollection<MenuItemm> CookMenuItems { get; set; }
    }
}
