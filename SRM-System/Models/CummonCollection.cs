using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM_System.Models
{
    public class CummonCollection<T>
    {
        public static ObservableCollection<T> cummonList = new ObservableCollection<T>();
    }
}
