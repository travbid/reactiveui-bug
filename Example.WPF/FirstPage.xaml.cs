
namespace Example.WPF
{
    using ReactiveUI;

    public partial class FirstPage : ReactivePage<FirstViewModel>
    {

        public FirstPage()
        {
            this.InitializeComponent();
            this.ViewModel = new FirstViewModel();
            this.DataContext = this.ViewModel;
        }
    }
}
