using Microsoft.Practices.Prism.Mvvm;
using System.Windows;

namespace PrismTest.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModelLocationProvider.AutoWireViewModelChanged(this);
        }
    }
}
