using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace UserInterface
{
    /// <summary>
    /// Логика взаимодействия для Stat.xaml
    /// </summary>
    public partial class Stat : Window
    {

        public Stat(Dictionary<string, int> data)
        {
            InitializeComponent();
            SeriesCollection = new SeriesCollection();
            Init(data);
        }
        public Stat()
        {
            InitializeComponent();
            SeriesCollection = new SeriesCollection();
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public void Init(Dictionary<string, int> data)
        {
            data = data.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            var chartvalues = new ChartValues<int>();
            foreach (var k in data.Keys)
            {
                chartvalues.Add(data[k]);
            }
            if (SeriesCollection.Count > 0)
            {
                AxisX.Labels = null;
                Table = null;
                Labels = null;
                SeriesCollection.Remove(SeriesCollection[0]);
            }
            SeriesCollection.Add(new ColumnSeries
            {
                Values = chartvalues,
                DataLabels = true
            }
                );
            Labels = data.Keys.ToArray();
            AxisX.Labels = Labels;
            Formatter = value => value.ToString();
            DataContext = this;
        }

    }
}
