using App1.Models;
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

namespace App1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UposleniciListView : Page
    {
        public UposleniciListView()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (UposlenikDbContext db = new UposlenikDbContext())
            {
                uposleniciLView.ItemsSource = db.Uposlenici.OrderBy(o => o.Prezime).ToList();
            }
        }

        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            using (UposlenikDbContext db = new UposlenikDbContext())
            {
                Uposlenik zaposleni = new Uposlenik
                {
                    Ime = imeTextBox.Text,
                    Prezime = prezimeTextBox.Text
                };
                db.Uposlenici.Add(zaposleni);
                db.SaveChanges();
                imeTextBox.Text = "";
                prezimeTextBox.Text = "";
                uposleniciLView.ItemsSource = db.Uposlenici.OrderBy(o => o.Prezime).ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null)
                return;
            using (UposlenikDbContext db = new UposlenikDbContext())
            {
                db.Uposlenici.Remove((Uposlenik)uposleniciLView.ItemFromContainer(dep));
                db.SaveChanges();
                uposleniciLView.ItemsSource = db.Uposlenici.OrderBy(o => o.Prezime).ToList();
            }
        }
    }
}
