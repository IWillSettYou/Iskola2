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
        public class Data(int year, string schoolClass, string name)
        {
            public int Year { get; set; } = year;
            public string SchoolClass { get; set; } = schoolClass;
            public string Name { get; set; } = name;
        }
        public MainWindow()
        {
            InitializeComponent();
            var lines = File.ReadAllLines(@"../../../nevek.txt");
            List<Data> data = [];

            //3. Feladat
            foreach (var item in lines)
            {
                var dataArray = item.Split(';');
                Data newData = new(
                    int.Parse(dataArray[0]),
                    Convert.ToString(dataArray[1]),
                    Convert.ToString(dataArray[2]));
                data.Add(newData);
            }

            //4. Feladat:
            foreach (var item in data)
            {
                lItems.Items.Add($"{item.Year} {item.SchoolClass} {item.Name}");
            }
            laTanulok.Content = "Tanulók Száma: " + data.Count;



        }
        
    }
}