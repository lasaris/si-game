using System;
using System.Globalization;
using System.Windows.Data;

namespace Seng.Game.Desktop.Views.Converters
{
	/// <summary>
	/// Converts <see cref="bool"/> to its inverted value.
	/// </summary>
	[ValueConversion(typeof(bool), typeof(bool))]
	public class InvertBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool original = (bool)value;
			return !original;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool original = (bool)value;
			return !original;
		}
	}
}