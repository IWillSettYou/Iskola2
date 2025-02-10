using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Iskola_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> students = [];
        public MainWindow()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            try
            {
                students = File.ReadAllLines(@"../../../nevek.txt").ToList();
                lItems.ItemsSource = students;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a fájl beolvasásakor: " + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lItems.SelectedItem != null)
            {
                students.Remove(lItems.SelectedItem.ToString());
                lItems.ItemsSource = null;
                lItems.ItemsSource = students;
            }
            else
            {
                MessageBox.Show("Nem jelölt ki tanulót!", "Figyelmeztetés", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                File.WriteAllLines(@"../../../nevekNEW.txt", students);
                MessageBox.Show("Sikeres mentés!", "Információ", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a fájl mentésekor: " + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}