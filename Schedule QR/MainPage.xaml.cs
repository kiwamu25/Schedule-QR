using System;
using System.Collections.Generic;
using System.ComponentModel;
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

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace Schedule_QR
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MainPageViewModel ViewModel = new MainPageViewModel();
        public MainPage()
        {
            this.InitializeComponent();
        }

        public void Button_Create_Click(object sender, RoutedEventArgs e)
        {
           imageview.Source =  ViewModel.Calendar.CreateCalendar();
            ViewModel.ButtonVisibility = Visibility.Collapsed;
        }

        private void Button_Up_Click(object sender ,RoutedEventArgs e)
        {
            ViewModel.ButtonVisibility = Visibility.Visible;
        }
    }

    public class MainPageViewModel : INotifyPropertyChanged
    {
        public iCalendar Calendar = new iCalendar();

        public event PropertyChangedEventHandler PropertyChanged;


        private static readonly PropertyChangedEventArgs ButtonVisibilityPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(ButtonVisibility));
        private Visibility buttonVisibility = Visibility.Visible;
        public Visibility ButtonVisibility
        {
            get { return this.buttonVisibility; }
            set
            {
                if (this.buttonVisibility == value) { return; }
                this.buttonVisibility = value;
                this.PropertyChanged?.Invoke(this, ButtonVisibilityPropertyChangedEventArgs);
            }
        }

    }





}
