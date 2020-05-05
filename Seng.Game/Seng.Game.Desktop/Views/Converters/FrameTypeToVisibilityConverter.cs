using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Seng.Game.Desktop.Helpers.IntermissionModule;

namespace Seng.Game.Desktop.Views.Converters
{
	/// <summary>
	/// Converts wanted <see cref="FrameType"/> and current <see cref="FrameType" /> to <see cref="Visibility.Visible"/>
	/// if they're same or to <see cref="Visibility.Collapsed"/> othewise.
	/// </summary>
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