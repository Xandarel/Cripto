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
using Criptoclass;

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
            var type = Type.GetType(CriptMetod);
            var cm = Activator.CreateInstance(type);
        }

        private void Decryption_Click(object sender, RoutedEventArgs e)
        {
            ClickTitle.Text = "Расшифрованный текст";
            var type = Type.GetType(DecriptMetod);
            var dm = Activator.CreateInstance(type);
        }
    }
}
