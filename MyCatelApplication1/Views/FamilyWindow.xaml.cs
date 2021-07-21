using Catel.Windows;
using MyCatelApplication1.ViewModels;

namespace MyCatelApplication1.Views
{
    public partial class FamilyWindow : DataWindow
    {
        public FamilyWindow()
        {
            InitializeComponent();
        }

        public FamilyWindow(FamilyWindowViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
