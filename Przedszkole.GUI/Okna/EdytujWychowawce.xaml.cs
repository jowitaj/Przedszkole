using System.Windows;
using Przedszkole.Database.Models;
using Przedszkole.Database.Services.SerwisyModele;

namespace Przedszkole.GUI;

public partial class EdytujWychowawce : Window
{
    private readonly WychowawcaService _service;
    private int id;
    public EdytujWychowawce(int id )
    {
        this.id = id;
        InitializeComponent();
        _service = new WychowawcaService();
        GetById(id);
    }
    
    
    private async void GetById(int id)
    {
        var item =  await _service.GetById(id);
        Imie.Text = item.Imie;
        Nazwisko.Text = item.Nazwisko;


    }
    private void Edytuj_Wychowawce(object sender, RoutedEventArgs e)
    {
        if (Imie != null && Nazwisko !=null )
        {
            _service.Update(id,Imie.Text, Nazwisko.Text);

            MessageBox.Show("Edytowano wychowawce");
            this.Close();
        }
        else
        {
            MessageBox.Show("Dane nieprawidłowe");
        }
        
    }
}