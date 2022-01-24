using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp10
{
    /// <summary>
    /// Interaction logic for SpecialWin.xaml
    /// </summary>
    public partial class SpecialWin : Window, INotifyPropertyChanged
    {
        private Special selectedSpecial;

        public Special SelectedSpecial
        {
            get => selectedSpecial;
            set
            {
                selectedSpecial = value;
                Signal();
            }
        }

        public ObservableCollection<Special> Specials
        {
            get => Data.Specials;
        }
        public SpecialWin()
        {
            InitializeComponent();
            DataContext = this;
        }

        void Signal([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this,
                      new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void AddSpecial(object sender, RoutedEventArgs e)
        {
            Specials.Add(new Special { Title = "Новая специальность" });
        }

        private void DeleteSpecial(object sender, RoutedEventArgs e)
        {
            if (SelectedSpecial == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранную специальность?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Specials.Remove(SelectedSpecial);
            }
        }
    }
}
