using System;
using System.Windows;
using Przedszkole.Database.Services.SerwisyModele;

namespace Przedszkole.GUI;

public partial class EdytujObecnosc : Window
{
    private readonly ObecnoscService _service;
    private int id;
    public EdytujObecnosc(int id )
    {
        this.id = id;
        InitializeComponent();
        _service = new ObecnoscService();
        GetById(id);
    }
    
    
    private async void GetById(int id)
    {
        var item =  await _service.GetById(id);
        Data.Text = item.Data.ToString();
        DzieckoID.Text = item.DzieckoId.ToString();
        if (item.Obecny == true)
        {
            Obecny.IsChecked = true;
        }
        else
        {
            Obecny.IsChecked = false;
        }


    }
    private void Edytuj_Obecnosc(object sender, RoutedEventArgs e)
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
            _service.Update(id,Data.SelectedDate.Value, Int32.Parse(DzieckoID.Text), obecnosc);

            MessageBox.Show("Edytowano obecność");
            this.Close();
        }
        else
        {
            MessageBox.Show("Dane nieprawidłowe");
        }
        
    }
}