
namespace Example.WPF
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ReactiveUI;

    public class MainWindowViewModel : ReactiveObject
    {
        public MainWindowViewModel() {}

        private List<string> menuItems;
        public List<string> MenuItems
        {
            get => this.menuItems;
            set
            {
                this.RaiseAndSetIfChanged(ref this.menuItems, value);
            }
        }

        public bool IsUserAuthenticated { get => App.IsUserAuthenticated; }

        public void ClearMenu()
        {
            this.MenuItems = new List<string>();
        }

        public async Task AuthenticateUserAsync()
        {
            await App.AuthenticateUserAsync().ConfigureAwait(false);
            this.RaisePropertyChanged(nameof(this.IsUserAuthenticated));
        }
    }
}
