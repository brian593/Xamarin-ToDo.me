using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoMe.Styles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Theme : ResourceDictionary
    {
        public Theme()
        {
            InitializeComponent();
        }
    }
}