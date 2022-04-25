using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyLaptopShop.GUI.Converter
{
    public class IntToDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int i && i > 0)
            {
                return new DateTime(i, 1, 1); 
            }
            return new DateTime(1970, 1, 1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dt && dt.Year > 0)
            {
                return dt.Year;
            }
            return 1970;
        }
    }
}
