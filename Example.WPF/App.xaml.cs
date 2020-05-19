
namespace Example.WPF
{
    using System.Threading.Tasks;
    using System.Windows;
    
    public class AppState
    {
        public AppState() {}

        public bool IsUserAuthenticated { get; private set; } = false;

        public async Task AuthenticateUserAsync()
        {
            await Task.Delay(1000);
            this.IsUserAuthenticated = true;
            return;
        }
    }

    public partial class App : Application
    {
        private static readonly AppState state = new AppState();

        public App() {}
        
        public static bool IsUserAuthenticated { get; } = true;
        
        public static async Task AuthenticateUserAsync()
        {
            await state.AuthenticateUserAsync();
        }

        private void Application_Startup(object sender, StartupEventArgs e) {}
    }
}
