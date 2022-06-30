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
using Przedszkole.GUI.ViewModels;
using Przedszkole.GUI.Views;

namespace Przedszkole.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MenuView();
        }


        private void Dzieci_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new DzieciViewModel();
        }

        private void Rodzice_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new RodziceViewModel();
        }

        private void Wychowawcy_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new WychowawcaViewModel();
        }

        private void Obecnosci_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ObecnoscViewModel();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MenuView();
        }
    }
}
