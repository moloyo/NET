using System.Windows;
using log4net;

namespace UI.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override void OnStartup(StartupEventArgs e) {
            log4net.Config.XmlConfigurator.Configure();
            Log.Info("Hello World");
            base.OnStartup(e);
        }
    }
}
