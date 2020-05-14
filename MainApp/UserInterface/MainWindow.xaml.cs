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
            Criptoclass.Languege.Libra("ru");
        }

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

        private void Encryption_Click_1(object sender, RoutedEventArgs e)
        {
            ClickTitle.Text = "Зашифрованный текст";
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
    }
}
