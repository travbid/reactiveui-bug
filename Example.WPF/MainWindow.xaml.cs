
namespace Example.WPF
{
    using System.Windows;
    using ReactiveUI;

    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            this.InitializeComponent();

            this.ViewModel = new MainWindowViewModel();
            this.DataContext = this.ViewModel;

            this.ViewModel.PropertyChanged += (obj, eventArgs) =>
            {
                var mainViewModel = (MainWindowViewModel)obj;

                switch (eventArgs.PropertyName)
                {
                    case nameof(MainWindowViewModel.IsUserAuthenticated):
                        if (mainViewModel.IsUserAuthenticated)
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                FirstPage page = new FirstPage();
                                this.mainFrame.Content = page;
                            });
                        }

                        break;
                }
            };

            this.mainFrame.Navigating += (o, e) => this.ViewModel.ClearMenu();
            this.Loaded += async (o, e) => await this.ViewModel.AuthenticateUserAsync();
        }
    }
}
