using Prodavnica.Models;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Prodavnica
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DodajUposlenika : Page
    {
        public DodajUposlenika()
        {
            this.InitializeComponent();
        }

      

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pozicijaSelection.SelectedIndex == 0 || pozicijaSelection.SelectedIndex == 1)
                smjenaSelection.Visibility = Visibility.Visible;
            else
                smjenaSelection.Visibility = Visibility.Collapsed;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Uposlenik noviUposlenik;

            if (pozicijaSelection.SelectedIndex == 0)            
                noviUposlenik = new Prodavac();            
            else if (pozicijaSelection.SelectedIndex == 1)
                noviUposlenik = new Supervizor();
            else noviUposlenik = new Menadzer();

            Smjena smjena;

            if((noviUposlenik is Prodavac))
            {
                if (smjenaSelection.SelectedIndex == 0) smjena = Smjena.Jutarnja;
                else if (smjenaSelection.SelectedIndex == 1) smjena = Smjena.Popodnevna;
                else smjena = Smjena.Nocna;

                (noviUposlenik as Prodavac).Smjena = smjena;
            }
            else if ((noviUposlenik is Supervizor))
            {
                if (smjenaSelection.SelectedIndex == 0) smjena = Smjena.Jutarnja;
                else if (smjenaSelection.SelectedIndex == 1) smjena = Smjena.Popodnevna;
                else smjena = Smjena.Nocna;

                (noviUposlenik as Supervizor).Smjena = smjena;
            }

            noviUposlenik.Ime = imeUposlenika.Text;
            noviUposlenik.Prezime = prezimeUposlenika.Text;
            noviUposlenik.korisnickoIme = korisnickoIme.Text;
            noviUposlenik.Sifra = sifra.Text;

            DataSource.DataSource.Data.ListaUposlenika.dodajUposlenika(noviUposlenik);
        }
    }
}
