using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Prodavnica.Models;
using Prodavnica.ViewModels;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Prodavnica
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PrikazInventara : Page
    {
        public PrikazInventara()
        {
            this.InitializeComponent();

            List<ArtikalViewModel> artikalView = new List<ArtikalViewModel>();

            foreach (ArtikalZaProdaju artikal in DataSource.DataSource.Data.Inventar.Artikli)
                artikalView.Add(ArtikalViewModel.izArtikla(artikal));

            prikazInventara.ItemsSource = artikalView;
        }

        private async void prikazInventara_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            nazivArtikla.Text = DataSource.DataSource.Data.Inventar.Artikli[prikazInventara.SelectedIndex].Artikal.NazivArtikla;
            cijena.Text = DataSource.DataSource.Data.Inventar.Artikli[prikazInventara.SelectedIndex].Artikal.CijenaArtikla.ToString();
            brojDostupnih.Text = DataSource.DataSource.Data.Inventar.Artikli[prikazInventara.SelectedIndex].BrojDostupnihArtikala.ToString();

            DataSource.DataSource.Data.ListaUposlenika.UpdateBazuUposlenika();
        }
    }
}
