﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Przedszkole.Database.Models;
using Przedszkole.Database.Services.SerwisyModele;
using Przedszkole.GUI.ViewModels;

namespace Przedszkole.GUI.Views
{
    /// <summary>
    /// Interaction logic for Dziecixaml.xaml
    /// </summary>
    public partial class DzieciView : UserControl
    {
        private readonly DzieckoSevice _dzieckoService;
        public DzieciView()
        {
            InitializeComponent();
            _dzieckoService = new DzieckoSevice();
            GetKids();

        }

        public async void GetKids()
        {
            var dzieci =  await _dzieckoService.GetAll();
            PokazDzieci.ItemsSource = dzieci;
        }
        
    }
}
