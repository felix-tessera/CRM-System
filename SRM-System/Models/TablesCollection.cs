using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM_System.Models
{
    public class TablesCollection
    {
        public static ObservableCollection<Table> Tables = new ObservableCollection<Table>();
        public static void CleanCollection()//Для перезаписи коллекции столов
        {
            Tables.Clear();
        }
        public static ObservableCollection<string> Keys = new ObservableCollection<string>();
    }
}
