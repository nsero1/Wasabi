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
    public sealed partial class PrikazUposlenika : Page
    {
        public PrikazUposlenika()
        {
            this.InitializeComponent();
            prikazUposlenika.ItemsSource = DataSource.DataSource.Data.ListaUposlenika.uposlenici;            
        }

        private void prikazUposlenika_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            imeUposlenika.Text = DataSource.DataSource.Data.ListaUposlenika.uposlenici[prikazUposlenika.SelectedIndex].Ime;
            prezimeUposlenika.Text = DataSource.DataSource.Data.ListaUposlenika.uposlenici[prikazUposlenika.SelectedIndex].Prezime;
            korisnickoIme.Text = DataSource.DataSource.Data.ListaUposlenika.uposlenici[prikazUposlenika.SelectedIndex].korisnickoIme;
        }

        private async void izmijeniPodatke_Click(object sender, RoutedEventArgs e)
        {
            if (prikazUposlenika.SelectedItems.Count == 0)
            {
                var dialog1 = new MessageDialog("Niste izabrali uposlenika!");
                await dialog1.ShowAsync();
                return;
            }           

            DataSource.DataSource.Data.ListaUposlenika.uposlenici[prikazUposlenika.SelectedIndex].Ime = imeUposlenika.Text;
            DataSource.DataSource.Data.ListaUposlenika.uposlenici[prikazUposlenika.SelectedIndex].Prezime = prezimeUposlenika.Text;
            DataSource.DataSource.Data.ListaUposlenika.uposlenici[prikazUposlenika.SelectedIndex].korisnickoIme = korisnickoIme.Text;

            DataSource.DataSource.Data.ListaUposlenika.UpdateBazuUposlenika();

            //prikazUposlenika.ItemsSource = null;
            prikazUposlenika.ItemsSource = DataSource.DataSource.Data.ListaUposlenika.uposlenici;

            var dialog = new MessageDialog("Podaci izmijenjeni!");
            await dialog.ShowAsync();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if (prikazUposlenika.SelectedItems.Count == 0)
            {
                var dialog1 = new MessageDialog("Niste izabrali uposlenika!");
                await dialog1.ShowAsync();
                return;
            }

            DataSource.DataSource.Data.ListaUposlenika.uposlenici.RemoveAt(prikazUposlenika.SelectedIndex);

            DataSource.DataSource.Data.ListaUposlenika.UpdateBazuUposlenika();

            //prikazUposlenika.ItemsSource = null;
            prikazUposlenika.ItemsSource = DataSource.DataSource.Data.ListaUposlenika.uposlenici;

            var dialog = new MessageDialog("Uposlenik obrisan!");
            await dialog.ShowAsync();
        }
    }
}
