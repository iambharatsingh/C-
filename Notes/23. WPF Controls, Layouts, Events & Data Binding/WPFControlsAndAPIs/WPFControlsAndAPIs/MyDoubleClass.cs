﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
namespace WPFControlsAndAPIs {
    class MyDoubleClass : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            double val = (double)value;
            return (int)(val);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }
    }
}
    