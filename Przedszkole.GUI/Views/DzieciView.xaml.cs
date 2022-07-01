using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Microsoft.EntityFrameworkCore.Query.Internal;
using Przedszkole.Database.Models;
using Przedszkole.Database.Services.SerwisyModele;
using Przedszkole.GUI.ViewModels;

namespace Przedszkole.GUI.Views
{
    /// <summary>
    /// Interaction logic for Dziecixaml.xaml
    /// </summary>
    public partial class DzieciView : UserControl
    {
        private readonly DzieckoSevice _service;
        public DzieciView()
        {
            InitializeComponent();
            _service = new DzieckoSevice();
            Get();

        }

        public async void Get()
        {
            var items =  await _service.GetAll();
            PokazDzieci.ItemsSource = items;
        }

        private void DodajDziecko_Click(object sender, RoutedEventArgs e)
        {
            Window dodajDziecko = new DodajDziecko();
            dodajDziecko.Show();
        }

        private  void Odswiez_Click(object sender, RoutedEventArgs e)
        {
             Get();
        }

        private  void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic content = ((Button) sender).DataContext;
            _service.Delete(content.Id);
            Get();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            dynamic content = ((Button) sender).DataContext;
            Window edytujDziecko = new EdytujDziecko(content.Id);
            edytujDziecko.Show();
        }
    }
}
