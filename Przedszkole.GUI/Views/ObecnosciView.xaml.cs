using System.Windows;
using System.Windows.Controls;
using Przedszkole.Database.Services.SerwisyModele;

namespace Przedszkole.GUI.Views;

public partial class ObecnosciView : UserControl
{
    private readonly ObecnoscService _service;
    public ObecnosciView()
    {
        InitializeComponent();
        _service = new ObecnoscService();
        Get();
    }


    public async void Get()
    {
        var items =  await _service.GetAll();
        PokazObecnosci.ItemsSource = items;
    }
    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        dynamic content = ((Button) sender).DataContext;
        _service.Delete(content.Id);
        Get();
    }

    private void Update_Click(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void DodajObecnosc_Click(object sender, RoutedEventArgs e)
    {
        Window dodajObecnosc = new DodajObecnosc();
        dodajObecnosc.Show();
    }

    private void Odswiez_Click(object sender, RoutedEventArgs e)
    {
        Get();
    }
}