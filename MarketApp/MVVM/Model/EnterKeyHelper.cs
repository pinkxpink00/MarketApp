using System.Windows;
using System.Windows.Input;

namespace CryptoCurrency.MVVM.AttachedProperties
{
	public class EnterKeyHelper
	{
		public static readonly DependencyProperty EnterKeyCommandProperty =
			DependencyProperty.RegisterAttached("EnterKeyCommand", typeof(ICommand), typeof(EnterKeyHelper), new PropertyMetadata(null));

		public static void SetEnterKeyCommand(UIElement element, ICommand value)
		{
			element.SetValue(EnterKeyCommandProperty, value);
		}

		public static ICommand GetEnterKeyCommand(UIElement element)
		{
			return (ICommand)element.GetValue(EnterKeyCommandProperty);
		}
	}
}
