using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Schedule_QR
{

    /// <summary>
    /// 表示状態を反転して返す
    /// </summary>
    public class VisibilityNegativeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (bool.TryParse(value.ToString(), out bool res))
            {
                if (res)
                    value = Visibility.Visible;
                else
                    value = Visibility.Collapsed;
            }
            if ((Visibility)value == Visibility.Collapsed)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}