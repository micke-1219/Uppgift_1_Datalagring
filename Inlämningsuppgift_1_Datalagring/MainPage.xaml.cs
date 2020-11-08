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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Inlämningsuppgift_1_Datalagring
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

        private async void OpenFileBtn_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".csv");
            picker.FileTypeFilter.Add(".json");
            picker.FileTypeFilter.Add(".txt");
            picker.FileTypeFilter.Add(".xml");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                ListBoxOutput.Items.Clear();
                TextBlockOutput.Text = "Selected file: " + file.Name;
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                using(StreamReader reader = new StreamReader(stream.AsStream()))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        ListBoxOutput.Items.Add(line);
                    }
                }
            }
            else
            {
                TextBlockOutput.Text = "Operation cancelled";
            }
        }
    }
}
