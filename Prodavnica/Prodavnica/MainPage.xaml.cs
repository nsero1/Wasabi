using Prodavnica.Models;
using Prodavnica.ViewModels;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Prodavnica
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Uposlenik uposlenik = null;
            //Dobavljanje korisnika iz parametra budući da je isti sa logina poslan kao parametar
            if (e.Parameter != null)
            {
                uposlenik = (Uposlenik)e.Parameter;
            }

            var stavke = MeniStavkeListView.ItemsSource as List<MeniStavkeViewModel>;

            if (stavke == null && uposlenik != null)
            {
                stavke = new List<MeniStavkeViewModel>();

                foreach (var meniStavka in DataSource.DataSource.Data.Stavke[uposlenik.Nivo])
                {      
                     stavke.Add(MeniStavkeViewModel.SaMeniStavke(meniStavka));                    
                }
                //pridruzivanje odabranih stavki menija, listview-u koji prikazuje meni
                MeniStavkeListView.ItemsSource = stavke;
            }

        }
            //textBox.Text = "Ulogovan kao " + uposlenik.Ime;

            private void PrikaziMeni_Click(object sender, RoutedEventArgs e)
        {
            MojSplitView.IsPaneOpen = !MojSplitView.IsPaneOpen;
        }
        //Metoda koja na osnovu odabranog menija, poziva podstranicu koja je definisana u meniju
        private void MeniStavkeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var menuPodstranica = (e.AddedItems[0] as MeniStavkeViewModel).Podstranica;
                if (menuPodstranica != null) sadrzajPodstranice.Navigate(menuPodstranica, null);
            }
        }
    }
    
}
