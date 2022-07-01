using System;
using System.Windows;
using Przedszkole.Database.Models;
using Przedszkole.Database.Services.SerwisyModele;
using Przedszkole.GUI.Views;

namespace Przedszkole.GUI;

public partial class DodajDziecko : Window
{
    private readonly DzieckoSevice _service;
    public DodajDziecko()
    {
        InitializeComponent();
        _service = new DzieckoSevice();
    }


    private void Dodaj_Dziecko(object sender, RoutedEventArgs e)
    {
        if (Imie != null && Nazwisko != null && RodziceID != null && WychowawcaID != null)
        {
            _service.Create(Imie.Text, Nazwisko.Text, Int32.Parse(RodziceID.Text), Int32.Parse(WychowawcaID.Text));
            MessageBox.Show("Dodano dziecko");
            this.Close();
        }
        else
        {
            MessageBox.Show("Dane nieprawidłowe");
        }
    }
}