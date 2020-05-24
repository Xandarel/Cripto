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

        public int selectIndex;
        private dynamic GetWordAndKey { get; set; }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public SeriesCollection SeriesCollection2 { get; set; }
        public string[] Labels2 { get; set; }
        public Func<double, string> Formatter2 { get; set; }
        public string CriptMetod { get; private set; }
        /// <summary>
        /// Переключение способов шифрования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CriptMetod_Checked(object sender, RoutedEventArgs e)
        {
            ChangeDesign("");
            if (sender is RadioButton item)
                CriptMetod = item.Name.ToString();
        }

        public string DecriptMetod { get; private set; }
        /// <summary>
        /// Переключение способов дешифровывания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecriptMetod_Checked(object sender, RoutedEventArgs e)
        {
            ChangeDesign("");
            if (sender is RadioButton item)
            {
                var text = item.Name.ToString().ToCharArray();
                text[0] = char.ToUpper(text[0]);
                DecriptMetod = new string(text);
            }
        }
        
        /// <summary>
        /// Переключение языков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            Languege.Libra(pressed.Name);
        }

        /// <summary>
        /// Статистика для левой таблицы
        /// </summary>
        /// <param name="data">статистический словарь</param>
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
            AxisX.Title = textBox1.Text;
        }
        /// <summary>
        /// Статистика для правой таблицы
        /// </summary>
        /// <param name="data">>статистический словарь</param>
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
            AxisX2.Title = CripDecripBox.Text;

        }
        /// <summary>
        /// Реализация кнопки "Зашифровать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Encryption_Click_1(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if (button.Content.ToString() == "Зашифровать")
            {
                ClickTitle.Text = "Зашифрованный текст";
                var data = Ngramm.NGrams(textBox1.Text);
                ShowStat(data);
                dynamic textWK;
                switch (CriptMetod)
                {
                    case "Vishener":
                        var cm = GetCriptMetod("Vishener");
                        if (GetWordAndKey != null)
                            if (textBox1.Text == GetWordAndKey.Word)
                                textWK = GetWordAndKey;
                            else
                                textWK = GetWKClass("Vishener", textBox1.Text, key.Text);
                        else
                            textWK = GetWKClass("Vishener", textBox1.Text, key.Text);
                        ExecuteCript(cm, textWK);
                        GetWordAndKey = textWK;
                        break;
                    case "ReverseVeshener":
                        cm = GetCriptMetod("ReverseVeshener");
                        if (GetWordAndKey != null)
                            if (textBox1.Text == GetWordAndKey.Word)
                                textWK = GetWordAndKey;
                            else
                                textWK = GetWKClass("ReverseVeshener", textBox1.Text, key.Text);
                        else
                            textWK = GetWKClass("ReverseVeshener", textBox1.Text, key.Text);
                        ExecuteCript(cm, textWK);
                        GetWordAndKey = textWK;
                        break;
                    case "Hill":
                        cm = GetCriptMetod("Hill");
                        if (GetWordAndKey != null)
                            if (textBox1.Text == GetWordAndKey.Word)
                                textWK = GetWordAndKey;
                            else
                                textWK = GetWKClass("Hill", textBox1.Text, key.Text);
                        else
                            textWK = GetWKClass("Hill", textBox1.Text, key.Text);
                        ExecuteCript(cm, textWK);
                        GetWordAndKey = textWK;
                        break;
                    case "Permutation":
                        cm = GetCriptMetod("Permutation");
                        if (GetWordAndKey != null)
                            if (textBox1.Text == GetWordAndKey.Word)
                                textWK = GetWordAndKey;
                            else
                                textWK = GetWKClass("Permutation", textBox1.Text, key.Text);
                        else
                            textWK = GetWKClass("Permutation", textBox1.Text, key.Text);
                        ExecuteCript(cm, textWK);
                        GetWordAndKey = textWK;
                        break;
                }
                data = Ngramm.NGrams(CripDecripBox.Text);
                ShowStat2(data);
            }
            else
            {
                switch (HackMetod)
                {
                    case "VigenereKey":
                        var cs = GetCriptSecur("VigenereKey");
                        cs.FindKey(key.Text);
                        var csh =new Normalizator();
                        csh.NormalizeKey(cs.GetKey, selectIndex);
                        MessageBox.Show(String.Join("\n\r", csh.Keys));
                        break;
                    case "FindHillsKey":
                        cs = GetCriptSecur("FindHillsKey");
                        cs.FindKey(textBox1.Text, key.Text);
                        MessageBox.Show("1");

                        break;
                }
            }
        }

        private dynamic GetCriptSecur(string metod)
        {
            switch (metod)
            {
                case "VigenereKey":
                    return new VigenereKey();
                case "FindHillsKey":
                    return new FindHillsKey();
                default:
                    return new VigenereKey();
            }
        }

        /// <summary>
        /// Выполнение шифрования выбранным способом
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cm"></param>
        /// <param name="wk"></param>
        void ExecuteCript<T>(Interfase_criptoelements<T> cm, WordAndKey<T> wk)
        {
            cm.Code(wk);
            if (wk.Encoded=="-1")
                CripDecripBox.Text = "Матрица является вырожденной. Данную матрицу невозможно расшифровать";
            else
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
        /// <summary>
        /// Инициализация класса WordAndKey
        /// </summary>
        /// <param name="metod">как представляется ключ</param>
        /// <param name="text">текст для шифрования/дешифрования</param>
        /// <param name="key">ключ</param>
        /// <returns></returns>
        private dynamic GetWKClass(string metod, string text, dynamic key)
        {
            switch (metod)
            {
                case "Vishener":
                    return new WordAndKey<string>(text, (string)key);
                case "ReverseVeshener":
                    return new WordAndKey<string>(text, (string)key);
                case "Hill":
                    if (key is string)
                    {
                        var matrix = BuildMatrix(key);
                        return new WordAndKey<List<Matrix<double>>>(text, matrix);
                    }
                    else
                       return new WordAndKey<List<Matrix<double>>>(text, key);
                case "Permutation":
                    if (key is string)
                    {
                        var keyMatrix = CreateArray(key);
                        return new WordAndKey<int[,]>(text, keyMatrix);
                    }
                    else
                        return new WordAndKey<int[,]>(text, key);
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
        /// <summary>
        /// Выполнить шифрование
        /// </summary>
        /// <param name="metod">метод шифрования</param>
        /// <returns></returns>
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
        /// <summary>
        /// Мозки кнопки "расшифровать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Decryption_Click(object sender, RoutedEventArgs e)
        {
            ClickTitle.Text = "Расшифрованный текст";
            var data = Ngramm.NGrams(textBox1.Text);
            ShowStat(data);
            dynamic textWK;
            switch (CriptMetod)
            {
                case "Vishener":
                    var cm = GetCriptMetod("Vishener");
                    //TYT
                    if (GetWordAndKey!= null)
                        if (textBox1.Text == GetWordAndKey.Encoded)
                            textWK = GetWKClass("Vishener", GetWordAndKey.Encoded, GetWordAndKey.Key);
                        else
                            textWK = GetWKClass("Vishener", textBox1.Text, key.Text);
                    else
                        textWK = GetWKClass("Vishener", textBox1.Text, key.Text);
                    ExecuteDecript(cm, textWK);
                    break;
                case "ReverseVeshener":
                    cm = GetCriptMetod("ReverseVeshener");
                    if (GetWordAndKey != null)
                        if (textBox1.Text == GetWordAndKey.Encoded)
                            textWK = GetWKClass("ReverseVeshener", GetWordAndKey.Encoded, GetWordAndKey.Key);
                        else
                            textWK = GetWKClass("ReverseVeshener", textBox1.Text, key.Text);
                    else
                        textWK = GetWKClass("ReverseVeshener", textBox1.Text, key.Text);
                    ExecuteDecript(cm, textWK);
                    break;
                case "Hill":
                    cm = GetCriptMetod("Hill");
                    if (GetWordAndKey != null)
                        if (textBox1.Text == GetWordAndKey.Encoded)
                            textWK = GetWKClass("Hill", GetWordAndKey.Encoded, GetWordAndKey.Key);
                        else
                            textWK = GetWKClass("Hill", textBox1.Text, key.Text);
                    else
                        textWK = GetWKClass("Hill", textBox1.Text, key.Text);
                    ExecuteDecript(cm, textWK);
                    break;
                case "Permutation":
                    cm = GetCriptMetod("Permutation");
                    if (GetWordAndKey != null)
                        if (textBox1.Text == GetWordAndKey.Encoded)
                            textWK = GetWKClass("Permutation", GetWordAndKey.Encoded, GetWordAndKey.Key);
                        else
                            textWK = GetWKClass("Permutation", textBox1.Text, key.Text);
                    else
                        textWK = GetWKClass("Permutation", textBox1.Text, key.Text);
                    ExecuteDecript(cm, textWK);
                    break;
            }
            data = Ngramm.NGrams(CripDecripBox.Text);
            ShowStat2(data);
        }
        /// <summary>
        /// Выбор способа дешифрования
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cm"></param>
        /// <param name="wk"></param>
        void ExecuteDecript<T>(Interfase_criptoelements<T> cm, WordAndKey<T> wk)
        {
            cm.Decode(wk);
            CripDecripBox.Text = wk.Encoded;
        }
        /// <summary>
        /// Мозги кнопки "копировать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(CripDecripBox.Text);
        }
        /// <summary>
        /// Вывод буквенной статистики
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Вывод статистики по биграммам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Вывод статистики по триграммам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        public string HackMetod { get; private set; }
        private void Hack(object sender, RoutedEventArgs e)
        {
            ChangeDesign("Hack");
            if (sender is RadioButton item)
                HackMetod = item.Name.ToString();
        }


        private void ChangeDesign(string mode)
        {
            switch (mode)
            {
                case "Hack":
                    TBword.Text = "Открытый текст";
                    TBkey.Text = "Зашифрованный текст";
                    ClickTitle.Text = "";
                    CripDecripBox.Text = "";
                    Decryption.Visibility = Visibility.Hidden;
                    Encryption.Content = "Взломать";
                    KL.Visibility = Visibility.Visible;
                    KeyLength.Visibility = Visibility.Visible;
                    break;
                default:
                    TBword.Text = "Слово";
                    TBkey.Text = "Ключ";
                    Decryption.Visibility = Visibility.Visible;
                    Encryption.Content = "Зашифровать";
                    KL.Visibility = Visibility.Hidden;
                    KeyLength.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void KeyLength_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = (TextBlock)KeyLength.SelectedItem;
            selectIndex = Convert.ToInt32(select.Tag);
        }
    }
}
