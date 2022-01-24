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
    /// Interaction logic for GroupWin.xaml
    /// </summary>
    public partial class GroupWin : Window, INotifyPropertyChanged
    {
        private Group selectedGroup;

        public Group SelectedGroup
        {
            get => selectedGroup;
            set
            {
                selectedGroup = value;
                Signal();
            }
        }
        public ObservableCollection<Group> Groups
        {
            get => Data.Groups;
        }
        public ObservableCollection<Special> Specials
        {
            get => Data.Specials;
        }
        public ObservableCollection<Curator> Curators
        {
            get => Data.Curators;
        }
        public GroupWin()
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

        private void AddGroup(object sender, RoutedEventArgs e)
        {
            Groups.Add(new Group { Title = "Новая группа" });
        }

        private void DeleteGroup(object sender, RoutedEventArgs e)
        {
            if (SelectedGroup == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранную группу?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Groups.Remove(SelectedGroup);
            }
        }

    }
}
