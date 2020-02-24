using System.Windows;

namespace Seng.Game.Desktop.Views.Converters
{
	public sealed class BooleanToVisibilityConverter : BooleanConverter<Visibility>
	{
		public BooleanToVisibilityConverter() :
			base(Visibility.Visible, Visibility.Collapsed) { }
	}
}