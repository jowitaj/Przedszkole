using System;
using System.Windows;
using Przedszkole.Database.Services.SerwisyModele;

namespace Przedszkole.GUI;

public partial class EdytujDziecko : Window
{
    private readonly DzieckoSevice _service;
    private int id;
    public EdytujDziecko(int id )
    {
        this.id = id;
        InitializeComponent();
        _service = new DzieckoSevice();
        PobierzDaneDziecka(id);
    }

    private async void PobierzDaneDziecka(int id)
    {
       var dziecko =  await _service.GetById(id);
       Imie.Text = dziecko.Imie;
       Nazwisko.Text = dziecko.Nazwisko;
       RodziceID.Text = dziecko.RodziceId.ToString();
       WychowawcaID.Text = dziecko.WychowawcaId.ToString();


    }
    private void Edytuj_Dziecko(object sender, RoutedEventArgs e)
    {
        if (Imie != null && Nazwisko != null && RodziceID != null && WychowawcaID != null  )
        {
            _service.Update(id, Imie.Text, Nazwisko.Text, Int32.Parse(RodziceID.Text), Int32.Parse(WychowawcaID.Text));

            MessageBox.Show("Edytowano dziecko");
            this.Close();
        }
        else
        {
            MessageBox.Show("Dane nieprawidłowe");
        }
        
    }
}