using Prodavnica.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Prodavnica
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PretragaInventara : Page
    {
        public PretragaInventara()
        {
            this.InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if (nazivArtikla.Text == "")
            {
                var dialog1 = new MessageDialog("Niste unijeli naziv za pretragu!");
                await dialog1.ShowAsync();
                return;
            }

            ArtikalZaProdaju artikal;

            artikal = DataSource.DataSource.Data.Inventar.dajArtikalPoNazivu(nazivArtikla.Text);

            if(artikal == null)
            {
                var dialog1 = new MessageDialog("Trazeni artikal ne postoji!");
                await dialog1.ShowAsync();
                return;
            }

            cijena.Text = artikal.Artikal.CijenaArtikla.ToString();
            brojDostupnih.Text = artikal.BrojDostupnihArtikala.ToString();
        }
    }
}
