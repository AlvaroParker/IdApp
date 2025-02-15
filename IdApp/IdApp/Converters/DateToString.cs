﻿using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IdApp.Converters
{
    /// <summary>
    /// Converts the date part of a <see cref="DateTime"/> value to a <see cref="String"/> value. If the value is
    /// <see cref="DateTime.MinValue"/> or <see cref="DateTime.MaxValue"/>, the empty string is returned.
    /// </summary>
    public class DateToString : IValueConverter, IMarkupExtension
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime TP)
            {
                if (TP == DateTime.MinValue || TP == DateTime.MaxValue)
                    return string.Empty;
                else
                    return TP.ToShortDateString();
            }
            else
                return string.Empty;
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string s && DateTime.TryParse(s, out DateTime TP))
                return TP;
            else
                return DateTime.MinValue;
        }

        /// <inheritdoc/>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
