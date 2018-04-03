using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Player
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MediaPlayer myplayer=new MediaPlayer();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void openFile()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".mp4");
            openPicker.FileTypeFilter.Add(".mp3");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                //var mediaSource = MediaSource.CreateFromStorageFile(file);
                //mediaPlayer.Source = mediaSource;
                mediaPlayer.Source = MediaSource.CreateFromStorageFile(file);
                mediaPlayer.Visibility = Visibility.Visible;
                button.Visibility = Visibility.Collapsed;
            }
            else
            {
                FileText.Text = "未选择文件";
            }
        }
        
        private async void Button_Click(object sender,RoutedEventArgs e)
        {
            openFile();
            mediaPlayer.SetMediaPlayer(myplayer);
        }
    }
}

