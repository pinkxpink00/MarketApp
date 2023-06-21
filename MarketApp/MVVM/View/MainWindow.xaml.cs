using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoCurrency
{
	public partial class MainWindow : Window
	{

		private bool isDragging = false;
		private Point offset;



		public MainWindow()
		{
			InitializeComponent();
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			isDragging = true;
			offset = e.GetPosition(this);
			this.CaptureMouse();
		}

		private void Window_MouseMove(object sender, MouseEventArgs e)
		{
			if (isDragging)
			{
				Point currentPoint = e.GetPosition(this);
				double deltaX = currentPoint.X - offset.X;
				double deltaY = currentPoint.Y - offset.Y;
				this.Left += deltaX;
				this.Top += deltaY;
			}
		}

		private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			isDragging = false;
			this.ReleaseMouseCapture();
		}


	}
}
