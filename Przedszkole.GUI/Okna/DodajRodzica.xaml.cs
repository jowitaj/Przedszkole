using System.Windows;
using Przedszkole.Database.Services.SerwisyModele;

namespace Przedszkole.GUI.Okna;

public partial class DodajRodzica : Window
{
    private readonly RodziceService _service;
    public DodajRodzica()
    {
        InitializeComponent();
        _service = new RodziceService();
    }

    private void Dodaj_Rodzica(object sender, RoutedEventArgs e)
    {
        if (ImieMatki != null && NazwiskoMatki != null && ImieOjca != null && NazwiskoOjca != null)
        {
            _service.Create(ImieMatki.Text, NazwiskoMatki.Text, ImieOjca.Text, NazwiskoOjca.Text);
            MessageBox.Show("Dodano rodzica");
            this.Close();
        }
        else
        {
            MessageBox.Show("Dane nieprawidłowe");
        }
    }
}