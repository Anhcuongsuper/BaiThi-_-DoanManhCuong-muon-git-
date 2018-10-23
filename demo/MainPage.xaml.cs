using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace demo
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker f = new FileOpenPicker();
            f.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            f.ViewMode = PickerViewMode.Thumbnail;
            f.FileTypeFilter.Clear();
            f.FileTypeFilter.Add(".jpg");
            f.FileTypeFilter.Add(".png");
            f.FileTypeFilter.Add(".jpeg");
            StorageFile sf = await f.PickSingleFileAsync();
            if (sf != null)
            {
                lbl.Text = sf.Name;
                Windows.Storage.Streams.IRandomAccessStream fs = await sf.OpenAsync(FileAccessMode.Read);
                BitmapImage bm = new BitmapImage();
                bm.SetSource(fs);
                iv.Source = bm;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Views.demoApp));
        }
    }
}
