using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfApp10
{
    //класс-хранилище общих данных, доступных везде
    static class Data
    {
        public static ObservableCollection<Special> Specials = new ObservableCollection<Special>();
        public static ObservableCollection<Student> Students = new ObservableCollection<Student>();
        public static ObservableCollection<Group> Groups = new ObservableCollection<Group>();
        public static ObservableCollection<Curator> Curators = new ObservableCollection<Curator>();
    }
}
