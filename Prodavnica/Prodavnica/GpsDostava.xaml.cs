using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.ApplicationModel.Core;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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
    public sealed partial class GpsDostava : Page
    {
        public GpsDostava()
        {
            this.InitializeComponent();
            mapMeine.Loaded += MyMap_Loaded;
            mapMeine.Tag = false;
        }
        Geolocator rajvosa = new Geolocator();
        Tuple<double, double> pozicijaUredjaja = new Tuple<double, double>(0, 0);
        Timer timica;

        public static double DistanceTo(double lat1, double lon1, double lat2, double lon2)
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;
            return dist * 1.609344;
        }


        private void koordinateTextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {


        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Geoposition pozi = await rajvosa.GetGeopositionAsync();
            pozicijaUredjaja = new Tuple<double, double>(pozi.Coordinate.Point.Position.Latitude, pozi.Coordinate.Point.Position.Longitude);
            RandomAccessStreamReference novaslika = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/StoreLogo.png"));
            MapIcon mapIk2 = new MapIcon();
            mapIk2.Location = new Geopoint(new BasicGeoposition
            {
                Latitude = pozicijaUredjaja.Item1,
                Longitude = pozicijaUredjaja.Item2
            });
            mapIk2.Image = novaslika;
            mapMeine.MapElements.Add(mapIk2);
            TimerCallback oU = new TimerCallback(ocitajUdaljenost);
            AutoResetEvent aRE = new AutoResetEvent(false);
            timica = new Timer(oU, aRE, 1000, 1000);

        }

        private void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            mapMeine.Center =
               new Geopoint(new BasicGeoposition()
               {
                   //Geopoint for Sarajevo 
                   Latitude = 43.85,
                   Longitude = 18.38
               });
            mapMeine.ZoomLevel = 15;
        }
        private void mapMeine_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private async void ocitajUdaljenost(Object stateInfo)
        {
            double lat, lon;
            string fajlName = "udaljenost.dat";
            fajlName = Path.Combine(ApplicationData.Current.LocalFolder.Path, fajlName);
            try
            {

                HttpClient hC = new HttpClient();
                var nesta = await hC.GetByteArrayAsync("http://fyou.atwebpages.com/udaljenost.dat");
                MemoryStream udWeb = new MemoryStream(nesta);
                using (BinaryReader bR = new BinaryReader(udWeb))
                {
                    lat = bR.ReadDouble();
                    lon = bR.ReadDouble();
                }

            }
            catch (Exception e)
            {
                return;
            }

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if ((bool)mapMeine.Tag) mapMeine.MapElements.RemoveAt(1);
                koordinateTextBlock.Text = "Udaljenost izmedju uredjaja i radnje je " + DistanceTo(pozicijaUredjaja.Item1, pozicijaUredjaja.Item2, lat, lon).ToString("0.00") + "km zracne linije.";
                MapIcon mapIkona = new MapIcon();
                mapIkona.Location = new Geopoint(new BasicGeoposition
                {
                    Latitude = lat,/*pozi.Coordinate.Point.Position.Latitude,*/
                    Longitude = lon//pozi.Coordinate.Point.Position.Longitude
                });
                RandomAccessStreamReference novaslika = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/rszTruck.png"));
                mapIkona.Image = novaslika;
                mapMeine.MapElements.Add(mapIkona);
                mapMeine.Tag = true;
            });



        }

        private void zaustaviButton_Click(object sender, RoutedEventArgs e)
        {
            timica.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }
}
