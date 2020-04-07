using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Seng.Game.Desktop.Helpers.IntermissionModule;

namespace Seng.Game.Desktop.Views.Converters
{
	public class FrameTypeToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			FrameType frameType = (FrameType)Enum.Parse(typeof(FrameType), (string) parameter);
			FrameType currentFrameType = (FrameType) value;

			return frameType == currentFrameType ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}