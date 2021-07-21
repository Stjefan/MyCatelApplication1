using Catel.Windows;
using MyCatelApplication1.ViewModels;

namespace MyCatelApplication1.Views
{
    public partial class PersonWindow : DataWindow
    {
        public PersonWindow()
        {
            InitializeComponent();
        }

        public PersonWindow(PersonViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
