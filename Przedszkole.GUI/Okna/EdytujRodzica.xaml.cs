using System.Windows;
using Przedszkole.Database.Services.SerwisyModele;

namespace Przedszkole.GUI.Okna;

public partial class EdytujRodzica : Window
{
    private readonly RodziceService _service;
    private int id;
    public EdytujRodzica(int id )
    {
        this.id = id;
        InitializeComponent();
        _service = new RodziceService();
        GetById(id);
    }
    
    private async void GetById(int id)
    {
        var item =  await _service.GetById(id);
        ImieMatki.Text = item.ImieMatki;
        NazwiskoMatki.Text = item.NazwiskoMatki;
        ImieOjca.Text = item.ImieOjca;
        NazwiskoOjca.Text = item.NazwiskoOjca;


    }
    private void Edytuj_Rodzica(object sender, RoutedEventArgs e)
    {
        if (ImieMatki != null && NazwiskoMatki != null && ImieOjca != null && NazwiskoOjca != null)
        {
            _service.Update(id, ImieMatki.Text, NazwiskoMatki.Text, ImieOjca.Text, NazwiskoOjca.Text);

            MessageBox.Show("Edytowano rodzica");
            this.Close();
        }
        else
        {
            MessageBox.Show("Dane nieprawidłowe");
        }
        
    }
}