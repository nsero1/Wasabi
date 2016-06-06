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
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

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
            var byteArray = DataSource.DataSource.Data.Inventar.Artikli[prikazInventara.SelectedIndex].Artikal.Slika;
            var image = new BitmapImage();
            try
            {
                using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                {
                    using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                    {
                        writer.WriteBytes(byteArray);
                        await writer.StoreAsync();
                    }
                    await image.SetSourceAsync(stream);
                }
                slikica.Source = image;
            }
            catch (Exception) {
                slikica.Source = new BitmapImage(new Uri("ms-appx:///Assets/faliSlika.png"));
            }
            //DataSource.DataSource.Data.ListaUposlenika.UpdateBazuUposlenika();
        }
    }
}
