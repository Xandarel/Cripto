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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using Criptoclass;
using CriptoClass;
using CryptographicSecurity;
using LiveCharts;
using LiveCharts.Wpf;

namespace UserInterface
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Languege.Libra("ru");
            SeriesCollection = new SeriesCollection();
            SeriesCollection2 = new SeriesCollection();
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public SeriesCollection SeriesCollection2 { get; set; }
        public string[] Labels2 { get; set; }
        public Func<double, string> Formatter2 { get; set; }



        public string CriptMetod { get; private set; }
        private void CriptMetod_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton item)
                CriptMetod = item.Name.ToString();
        }

        public string DecriptMetod { get; private set; }
        private void DecriptMetod_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton item)
            {
                var text = item.Name.ToString().ToCharArray();
                text[0] = char.ToUpper(text[0]);
                DecriptMetod = new string(text);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            Languege.Libra(pressed.Name);
        }

        private void ShowStat( Dictionary<string,int> data)
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

        private void ShowStat2(Dictionary<string, int> data)
        {
            data = data.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            var chartvalues = new ChartValues<int>();
            foreach (var k in data.Keys)
            {
                chartvalues.Add(data[k]);
            }
            if (SeriesCollection2.Count > 0)
            {
                AxisX2.Labels = null;
                Table2 = null;
                Labels2 = null;
                SeriesCollection2.Remove(SeriesCollection2[0]);
            }
            SeriesCollection2.Add(new ColumnSeries
            {
                Values = chartvalues,
                DataLabels = true
            }
                );
            Labels2 = data.Keys.ToArray();
            AxisX2.Labels = Labels2;
            Formatter2 = value => value.ToString();
            DataContext = this;
        }

        private void Encryption_Click_1(object sender, RoutedEventArgs e)
        {
            ClickTitle.Text = "Зашифрованный текст";
            var data = Ngramm.NGrams(textBox1.Text);
            ShowStat(data);
            switch (CriptMetod)
            {
                case "Vishener":
                    var cm = GetCriptMetod("Vishener");
                    var textWK = GetWKClass("Vishener", textBox1.Text, key.Text);
                    ExecuteCript(cm, textWK);
                    break;
                case "ReverseVeshener":
                    cm = GetCriptMetod("ReverseVeshener");
                    textWK = GetWKClass("ReverseVeshener", textBox1.Text, key.Text);
                    ExecuteCript(cm, textWK);
                    break;
                case "Hill":
                    cm = GetCriptMetod("Hill");
                    textWK = GetWKClass("Hill", textBox1.Text, key.Text);
                    ExecuteCript(cm, textWK);
                    break;
                case "Permutation":
                    cm = GetCriptMetod("Permutation");
                    textWK = GetWKClass("Permutation", textBox1.Text, key.Text);
                    ExecuteCript(cm, textWK);
                    break;
            }
            data = Ngramm.NGrams(CripDecripBox.Text);
            ShowStat2(data);
        }
        void ExecuteCript<T>(Interfase_criptoelements<T> cm, WordAndKey<T> wk)
        {
            cm.Code(wk);
            CripDecripBox.Text = wk.Encoded;
        }



        List<Matrix<double>> BuildMatrix(string matrixElement)
        {
            var res = new List<Matrix<double>>();
            matrixElement = matrixElement.Replace("\r\n", " ");
            var matrixLength = matrixElement.IndexOf(' ');
            matrixElement = matrixElement.Replace(" ", "");
            var matrixArray = new double[matrixLength, matrixLength];
            var matrixVector = new double[matrixLength];
            for (var i = 0; i < matrixLength; i++)
            {
                matrixVector[i] = 0;
                for (var j = 0; j < matrixLength; j++)
                {
                    matrixArray[j, i] = double.Parse(matrixElement[0].ToString());
                    matrixElement = matrixElement.Remove(0, 1);
                }
            }
            res.Add(Matrix<double>.Build.DenseOfArray(matrixArray));
            res.Add(Matrix<double>.Build.DenseOfColumnVectors(Vector<double>.Build.DenseOfArray(matrixVector)));
            return res;
        }

        private dynamic GetWKClass(string metod, string text, string key)
        {
            switch (metod)
            {
                case "Vishener":
                    return new WordAndKey<string>(text, key);
                case "ReverseVeshener":
                    return new WordAndKey<string>(text, key);
                case "Hill":
                    var matrix = BuildMatrix(key);
                    return new WordAndKey<List<Matrix<double>>>(text, matrix);
                case "Permutation":
                    var keyMatrix = CreateArray(key);
                    return new WordAndKey<int[,]>(text, keyMatrix);
                default:
                    return new WordAndKey<string> (text, key);
            }
        }

        private int[,] CreateArray(string keyText)
        {
            keyText = keyText.Replace("\r\n", " ");
            var length = keyText.IndexOf(" ");
            var res = new int[2, length];
            keyText = keyText.Replace(" ", "");
            for (var i=0;i<2;i++)
                for(var j=0;j<length;j++)
                {
                    res[i,j]= int.Parse(keyText[0].ToString());
                    keyText = keyText.Remove(0, 1);
                }
            return res;
        }
        private dynamic GetCriptMetod(string metod)
        {
            switch (metod)
            {
                case "Vishener":
                    return new Vishener();
                case "ReverseVeshener":
                    return new ReverseVeshener();
                case "Hill":
                    return new Hill();
                case "Permutation":
                    return new Permutation();
                default:
                    return new Vishener();
            }
        }

        private void Decryption_Click(object sender, RoutedEventArgs e)
        {
            ClickTitle.Text = "Расшифрованный текст";
            switch (CriptMetod)
            {
                case "Vishener":
                    var cm = GetCriptMetod("Vishener");
                    var textWK = GetWKClass("Vishener", textBox1.Text, key.Text);
                    ExecuteDecript(cm, textWK);
                    break;
                case "ReverseVeshener":
                    cm = GetCriptMetod("ReverseVeshener");
                    textWK = GetWKClass("ReverseVeshener", textBox1.Text, key.Text);
                    ExecuteDecript(cm, textWK);
                    break;
                case "Hill":
                    cm = GetCriptMetod("Hill");
                    textWK = GetWKClass("Hill", textBox1.Text, key.Text);
                    ExecuteDecript(cm, textWK);
                    break;
                case "Permutation":
                    cm = GetCriptMetod("Permutation");
                    textWK = GetWKClass("Permutation", textBox1.Text, key.Text);
                    ExecuteDecript(cm, textWK);
                    break;
            }
        }
        void ExecuteDecript<T>(Interfase_criptoelements<T> cm, WordAndKey<T> wk)
        {
            cm.Decode(wk);
            CripDecripBox.Text = wk.Encoded;
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(CripDecripBox.Text);
        }

        private void A_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b.Name == "A2")
            {
                var data = Ngramm.NGrams(CripDecripBox.Text, 1);
                if (data.Count> Languege.z)
                    new Stat(data).Show();
                else
                    ShowStat2(data);
            }
            else
            {
                var data = Ngramm.NGrams(textBox1.Text, 1);
                if (data.Count > Languege.z)
                    new Stat(data).Show();
                else
                    ShowStat(data);
            }
        }

        private void AA_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b.Name == "AA2")
            {
                var data = Ngramm.NGrams(CripDecripBox.Text, 2);
                if (data.Count > Languege.z)
                    new Stat(data).Show();
                else
                    ShowStat2(data);
            }
            else
            {
                var data = Ngramm.NGrams(textBox1.Text, 2);
                if (data.Count > Languege.z)
                    new Stat(data).Show();
                else
                    ShowStat(data);
            }
        }

        private void AAA_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b.Name == "AAA2")
            {
                var data = Ngramm.NGrams(CripDecripBox.Text, 3);
                if (data.Count > Languege.z)
                    new Stat(data).Show();
                else
                    ShowStat2(data);
            }
            else
            {
                var data = Ngramm.NGrams(textBox1.Text, 3);
                if (data.Count > Languege.z)
                    new Stat(data).Show();
                else
                    ShowStat(data);
            }
        }
    }
}
