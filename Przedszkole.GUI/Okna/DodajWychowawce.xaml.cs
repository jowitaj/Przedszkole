using System.Windows;
using Przedszkole.Database.Services.SerwisyModele;

namespace Przedszkole.GUI;

public partial class DodajWychowawce : Window
{
    private readonly WychowawcaService _service;
    public DodajWychowawce()
    {
        InitializeComponent();
        _service = new WychowawcaService();
    }

    private void Dodaj_Wychowawce(object sender, RoutedEventArgs e)
    {
        if (Imie != null && Nazwisko != null )
        {
            _service.Create(Imie.Text, Nazwisko.Text);
            MessageBox.Show("Dodano wychowawce");
            this.Close();
        }
        else
        {
            MessageBox.Show("Dane nieprawidłowe");
        }
    }
}