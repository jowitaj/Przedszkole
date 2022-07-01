using System;
using System.Windows;
using Przedszkole.Database.Services.SerwisyModele;

namespace Przedszkole.GUI;

public partial class DodajObecnosc : Window
{
    private readonly ObecnoscService _service;
    public DodajObecnosc()
    {
        InitializeComponent();
        _service = new ObecnoscService();
    }

    private void Dodaj_Obecnosc(object sender, RoutedEventArgs e)
    {
        if (Data != null && DzieckoID != null && Obecny != null )
        {
            Boolean obecnosc;
            if ((bool) Obecny.IsChecked)
            {
                obecnosc = true;
            }
            else
            {
                obecnosc = false;
            }
            
            _service.Create(Data.SelectedDate.Value, Int32.Parse(DzieckoID.Text), obecnosc);
            MessageBox.Show("Dodano obecność");
            this.Close();
        }
        else
        {
            MessageBox.Show("Dane nieprawidłowe");
        }
    }
}