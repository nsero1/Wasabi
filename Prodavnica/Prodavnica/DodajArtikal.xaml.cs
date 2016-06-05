using Prodavnica.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.Devices.Enumeration;
using Windows.Devices.Sensors;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Media;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;
using Windows.System.Display;
using Windows.UI.Core;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Prodavnica
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DodajArtikal : Page
    {
        private MediaCapture _mediaCapture;
        private bool _isInitialized;
        private bool _isPreviewing;
        private bool _isRecording;

        public DodajArtikal()
        {
            this.InitializeComponent();
        }

        private async void dodajArtikal_Click(object sender, RoutedEventArgs e)
        {
            Artikal noviArtikal = new Artikal();

            noviArtikal.NazivArtikla = nazivArtikla.Text;
            noviArtikal.CijenaArtikla = Double.Parse(cijenaArtikla.Text);
            var byteArray = new byte[1];
            try
            {
                using (var inputStream = await storeFile.OpenSequentialReadAsync())
                {
                    var readStream = inputStream.AsStreamForRead();

                     byteArray = new byte[readStream.Length];
                    await readStream.ReadAsync(byteArray, 0, byteArray.Length);
                }
            noviArtikal.Slika = byteArray;
            }
            catch (Exception)
            {

               
            }
            DataSource.DataSource.Data.Inventar.dodajArtikal(noviArtikal, Int32.Parse(brojArtikala.Text));
        }

        private StorageFile storeFile;
        private IRandomAccessStream stream;

        private async void captureBtn_Click(object sender, RoutedEventArgs e)
        {
            CameraCaptureUI capture = new CameraCaptureUI();
            capture.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            capture.PhotoSettings.CroppedAspectRatio = new Size(3, 5);
            capture.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.HighestAvailable;
            storeFile = await capture.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (storeFile != null)
            {
                BitmapImage bimage = new BitmapImage();
                stream = await storeFile.OpenAsync(FileAccessMode.Read); ;
                bimage.SetSource(stream);
                captureImage.Source = bimage;
            }
        }
    }
}
