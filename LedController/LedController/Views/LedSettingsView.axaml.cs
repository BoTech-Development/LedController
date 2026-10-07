using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LedController.Views
{
    public partial class LedSettingsView : UserControl
    {
        public LedSettingsView()
        {
            DataContext = new ViewModels.LedSettingsViewModel();
            InitializeComponent();
        }
    }
}