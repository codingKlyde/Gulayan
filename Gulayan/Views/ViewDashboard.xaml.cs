using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gulayan.Views
{
    public partial class ViewDashboard : UserControl
    {
        public class Vege
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Character { get; set; }
            public string Barcode { get; set; }
            public string Price { get; set; }
            public string Stock { get; set; }

            public Brush BGColor { get; set; }
        }

        public ViewDashboard()
        {
            InitializeComponent();

            var converter = new BrushConverter();
            ObservableCollection<Vege> veges = new ObservableCollection<Vege>();

            veges.Add(new Vege { ID = "1", Name = "Potato", Character="P", Barcode = "123456789", Price = "11", Stock = "2131", BGColor = (Brush)converter.ConvertFromString("#1098ad") });
            veges.Add(new Vege { ID = "2", Name = "Eggplant", Character = "E", Barcode = "987654321", Price = "15", Stock = "3031", BGColor = (Brush)converter.ConvertFromString("#1e88e5") });
            veges.Add(new Vege { ID = "3", Name = "Pumpkin", Character = "P", Barcode = "112233445", Price = "30", Stock = "2531", BGColor = (Brush)converter.ConvertFromString("#ff8f00") });
            veges.Add(new Vege { ID = "4", Name = "Tomato", Character = "T", Barcode = "000001111", Price = "7", Stock = "1231", BGColor = (Brush)converter.ConvertFromString("#ff5252") });
            veges.Add(new Vege { ID = "5", Name = "Onion", Character = "O", Barcode = "332265812", Price = "10", Stock = "3201", BGColor = (Brush)converter.ConvertFromString("#0ca678") });
        
            dtgrdVegetable.ItemsSource = veges;
        }
    }
}