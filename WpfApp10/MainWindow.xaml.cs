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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Student selectedStudent;

        public ObservableCollection<Student> Students
        {
            get => Data.Students;
        }
        public ObservableCollection<Group> Groups { 
            get => Data.Groups; 
        }

        public Student SelectedStudent
        {
            get => selectedStudent;
            set
            {
                selectedStudent = value;
                Signal();
            }
        }

        public MainWindow()
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

        private void AddStudent(object sender, RoutedEventArgs e)
        {
            Students.Add(new Student
            {
                LastName = "Новый студент",
                Birthday = DateTime.Today
            });
        }

        private void DeleteStudent(object sender, RoutedEventArgs e)
        {
            if (SelectedStudent == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранного студента?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Students.Remove(SelectedStudent);
                SelectedStudent = null;
            }
        }

        private void OpenSpecials(object sender, RoutedEventArgs e)
        {
            SpecialWin win = new SpecialWin();
            win.ShowDialog();
        }

        private void OpenGroups(object sender, RoutedEventArgs e)
        {
            GroupWin win = new GroupWin();
            win.ShowDialog();
        }

        private void OpenCurators(object sender, RoutedEventArgs e)
        {
            CuratorWin win = new CuratorWin();
            win.ShowDialog();
        }
    }
}
