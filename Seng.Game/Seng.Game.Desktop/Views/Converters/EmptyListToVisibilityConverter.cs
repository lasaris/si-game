﻿using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Seng.Game.Desktop.Views.Converters
{
	public class EmptyListToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch (value)
			{
				case null:
					return Visibility.Collapsed;
				case ICollection list:
					return list.Count == 0 ? Visibility.Collapsed : Visibility.Visible;
				default:
					return Visibility.Visible;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}