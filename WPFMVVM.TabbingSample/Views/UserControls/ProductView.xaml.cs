using System.Windows.Controls;
using WPFMVVM.TabbingSample.ViewModels;

namespace WPFMVVM.TabbingSample.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        public ProductView()
        {
            InitializeComponent();
            DataContext = new ProductViewModel();
        }
    }
}
