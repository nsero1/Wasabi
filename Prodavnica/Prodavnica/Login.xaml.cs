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
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
            var inicijalizacija = new DataSource.DataSource.Data();
        }

        private async void logInButton_Click(object sender, RoutedEventArgs e)
        {
            string korisnickoIme = korisnickoImeTextBox.Text;
            string sifra = sifraTextBox.Text;

            Uposlenik uposlenik = DataSource.DataSource.Data.ListaUposlenika.provjeraUposlenika(korisnickoIme, sifra);

            if(uposlenik != null && uposlenik.ID > 0)
            {
                this.Frame.Navigate(typeof(MainPage), uposlenik);
            }
            else
            {
                var dialog = new MessageDialog("Pogrešno korisničko ime/šifra!", "Neuspješna prijava");

                await dialog.ShowAsync();
            }
        }
    }
}
