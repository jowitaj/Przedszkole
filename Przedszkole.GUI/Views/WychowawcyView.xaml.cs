using System.Windows;
using System.Windows.Controls;
using Przedszkole.Database.Services.SerwisyModele;

namespace Przedszkole.GUI.Views;

public partial class WychowawcyView : UserControl
{
    private readonly WychowawcaService _service;
    public WychowawcyView()
    {
        InitializeComponent();
        _service = new WychowawcaService();
        Get();
    }

    public async void Get()
    {
        var items =  await _service.GetAll();
        PokazWychowawcow.ItemsSource = items;
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

    private void DodajWychowawce_Click(object sender, RoutedEventArgs e)
    {
        Window dodajWychowawce = new DodajWychowawce();
        dodajWychowawce.Show();
    }

    private void Odswiez_Click(object sender, RoutedEventArgs e)
    {
        Get();
    }
}