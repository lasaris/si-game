using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Seng.Game.Desktop.Views.Converters
{
	/// <summary>
	/// Converts object to <see cref="Visibility.Visible"/> if object in not null, or to <see cref="Visibility.Collapsed"/> otherwise.
	/// </summary>
	public class NullVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value == null ? Visibility.Collapsed : Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}