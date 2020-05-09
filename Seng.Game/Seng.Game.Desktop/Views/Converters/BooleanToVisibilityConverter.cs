using System.Windows;

namespace Seng.Game.Desktop.Views.Converters
{
	/// <summary>
	/// Converts <see cref="bool"/> to setted <see cref="Visibility"/> type for True and False value.
	/// </summary>
	public sealed class BooleanToVisibilityConverter : BooleanConverter<Visibility>
	{
		public BooleanToVisibilityConverter() :
			base(Visibility.Visible, Visibility.Collapsed) { }
	}
}