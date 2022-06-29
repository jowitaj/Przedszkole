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
using Przedszkole.Database.Services.SerwisyModele;

namespace Przedszkole.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DzieckoSevice _dzieckoSevice;
        private readonly WychowawcaService _wychowawcaService;
        private readonly RodziceService _rodziceService;
        private readonly ObecnoscService _obecnoscService;
        public MainWindow()
        {
            InitializeComponent();
            _dzieckoSevice = new DzieckoSevice();
            _obecnoscService = new ObecnoscService();
            _rodziceService = new RodziceService();
            _wychowawcaService = new WychowawcaService();
        }
        

        private void Rodzice_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Rodzice();
        }

        private void Dzieci_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Dzieci();
        }

        private void Obecnosci_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Obecnosci();
        }

        private void Wychowawcy_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Wychowawcy();
        }
    }
}
