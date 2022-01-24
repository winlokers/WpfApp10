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
    /// Interaction logic for CuratorWin.xaml
    /// </summary>
    public partial class CuratorWin : Window, INotifyPropertyChanged
    {
        private Curator selectedCurator;

        public Curator SelectedCurator
        {
            get => selectedCurator;
            set
            {
                selectedCurator = value;
                Signal();
            }
        }

        public ObservableCollection<Curator> Curators
        {
            get => Data.Curators;
        }
        public CuratorWin()
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

        private void AddCurator(object sender, RoutedEventArgs e)
        {
            Curators.Add(new Curator { LastName = "Фамилия" });
        }

        private void DeleteCurator(object sender, RoutedEventArgs e)
        {
            if (SelectedCurator == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранного куратора?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Curators.Remove(SelectedCurator);
            }
        }
    }
}
