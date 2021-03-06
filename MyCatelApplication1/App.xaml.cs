namespace MyCatelApplication1
{
    using System.Windows;

    using Catel.IoC;
    using Catel.Logging;
    using Catel.Reflection;
    using Catel.Services;
    using Catel.Windows;
    using MyCatelApplication1.Services;
    using MyCatelApplication1.Services.Interfaces;
    using MyCatelApplication1.ViewModels;
    using MyCatelApplication1.Views;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        protected override void OnStartup(StartupEventArgs e)
        {
#if DEBUG
            LogManager.AddDebugListener();
#endif

            Log.Info("Starting application");

            // Want to improve performance? Uncomment the lines below. Note though that this will disable
            // some features. 
            //
            // For more information, see http://docs.catelproject.com/vnext/faq/performance-considerations/

            // Log.Info("Improving performance");
            // Catel.Windows.Controls.UserControl.DefaultCreateWarningAndErrorValidatorForViewModelValue = false;
            // Catel.Windows.Controls.UserControl.DefaultSkipSearchingForInfoBarMessageControlValue = true;

            // TODO: Register custom types in the ServiceLocator
            //Log.Info("Registering custom types");
            //var serviceLocator = ServiceLocator.Default;
            //serviceLocator.RegisterType<IMyInterface, IMyClass>();

            var serviceLocator = ServiceLocator.Default;
            serviceLocator.RegisterType<IFamilyService, FamilyService>();

            // To auto-forward styles, check out Orchestra (see https://github.com/wildgums/orchestra)
            // StyleHelper.CreateStyleForwardersForDefaultStyles();

            var uiVisualizerService = serviceLocator.ResolveType<IUIVisualizerService>();
            uiVisualizerService.Register(typeof(PersonViewModel), typeof(PersonWindow));
            // uiVisualizerService.Register(typeof(FamilyWindowViewModel), typeof(FamilyWindow));

            Log.Info("Calling base.OnStartup");

            base.OnStartup(e);
        }
    }
}