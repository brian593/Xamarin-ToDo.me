using Prism.Events;
using Prism.Navigation;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToDoMe.Events;
using Xamarin.Forms;

namespace ToDoMe.ViewModels
{
    public class AuthPageViewModel : 
        BaseViewModel,
        IInitialize
    {
        #region Private & Protected

        private IRegionManager _regionManager { get; }
        private SwitchViewEvent _switchViewEvent;

        #endregion

        #region Properties

        public ObservableCollection<string> AuthScreenList { get; set; }
        public string CurrentAuthScreen { get; set; }

        #endregion

        #region Commands

        public ICommand BackCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand SignUpCommand { get; set; }
        public ICommand SwitchToLoginCommand { get; set; }
        public ICommand SwitchToSignUpCommand { get; set; }
        public ICommand SwitchToResetPasswordCommand { get; set; }

        #endregion

        #region Constructors

        public AuthPageViewModel(
            INavigationService navigationService,
            IRegionManager regionManager,
            IEventAggregator eventAggregator) : base(navigationService)
        {
            _regionManager = regionManager;
            
            BackCommand = new Command(BackCommandHandler);
            SwitchToLoginCommand = new Command(SwitchToLoginCommandHandler);
            SwitchToSignUpCommand = new Command(SwitchToSignUpCommandHandler);
            SwitchToResetPasswordCommand = new Command(SwitchToResetPasswordCommandHandler);

            _switchViewEvent = eventAggregator.GetEvent<SwitchViewEvent>();
            _switchViewEvent.Subscribe(SwitchViewEventHandler);
        }

        public void Initialize(INavigationParameters parameters)
        {
            CurrentAuthScreen = "ingresar";
            Title = "Ingresar";

            _regionManager.RequestNavigate("LoginRegion", "LoginTemplate");
            _regionManager.RequestNavigate("SignUpRegion", "SignUpTemplate");
            _regionManager.RequestNavigate("ResetPasswordRegion", "ResetPasswordTemplate");
        }

        #endregion

        #region Command Handlers

        private void SwitchToLoginCommandHandler()
        {
            CurrentAuthScreen = "ingresar";
            Title = "Ingresar";
        }

        private void SwitchToSignUpCommandHandler()
        {
            CurrentAuthScreen = "registrarme";
            Title = "Registrarme";
        }

        private void SwitchToResetPasswordCommandHandler()
        {
            CurrentAuthScreen = "reinicio";
            Title = "Reiniciar Contraseña";
        }

        private void SwitchViewEventHandler(string view)
        {
            if(view == "Ingresar")
            {
                CurrentAuthScreen = "ingresar";
                Title = "Ingresar";
            }
            else if (view == "Registrarme")
            {
                CurrentAuthScreen = "registrarme";
                Title = "Registrarme";
            }
            else if (view == "Reinicio")
            {
                CurrentAuthScreen = "reinicio";
                Title = "Reiniciar Contraseña";
            }
        }

        #endregion
    }
}
