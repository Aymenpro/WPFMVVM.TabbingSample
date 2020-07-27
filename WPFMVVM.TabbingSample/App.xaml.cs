using System.Windows;
using WPFMVVM.TabbingSample.Views;

namespace WPFMVVM.TabbingSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            new Home().ShowDialog();
        }
    }
}
