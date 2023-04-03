using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoMe.Views.Fragments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZeroStateView : StackLayout
    {
        public ZeroStateView()
        {
            InitializeComponent();
        }
    }
}