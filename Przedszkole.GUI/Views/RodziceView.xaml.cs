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
using Przedszkole.GUI.Okna;

namespace Przedszkole.GUI.Views
{
    public partial class RodziceView : UserControl
    {
        private readonly RodziceService _service;
        public RodziceView()
        {
            InitializeComponent();
            _service = new RodziceService();
            Get();
        }

        public async void Get()
        {
            var items =  await _service.GetAll();
            PokazRodzicow.ItemsSource = items;
        }
        
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic content = ((Button) sender).DataContext;
            _service.Delete(content.Id);
            Get();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DodajRodzica_Click(object sender, RoutedEventArgs e)
        {
            Window dodajRodzica = new DodajRodzica();
            dodajRodzica.Show();
        }

        private void Odswiez_Click(object sender, RoutedEventArgs e)
        {
            Get();
        }
    }
}
