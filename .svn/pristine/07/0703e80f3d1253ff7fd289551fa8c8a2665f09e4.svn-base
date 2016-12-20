using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Color = System.Drawing.Color;
namespace DoubleJ.Oms.LabelManager.Converters
{
    public class CutColorsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var hex = value.ToString();
            if (String.IsNullOrWhiteSpace(hex) || !(hex.Length == 7 || hex.Length == 4) || !hex.StartsWith("#"))
            {
                return new SolidBrush(Color.Black);
            }
            return (SolidColorBrush)(new BrushConverter().ConvertFrom(hex));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
