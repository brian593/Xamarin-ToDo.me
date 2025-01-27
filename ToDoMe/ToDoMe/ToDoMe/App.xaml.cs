﻿using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using ToDoMe.Auth;
using ToDoMe.Models;
using ToDoMe.Repositories.FirestoreRepository;
using ToDoMe.Services.DateService;
using ToDoMe.ViewModels;
using ToDoMe.ViewModels.Dialogs;
using ToDoMe.ViewModels.Templates.AddEditItem;
using ToDoMe.ViewModels.Templates.Auth;
using ToDoMe.Views;
using ToDoMe.Views.Dialogs;
using ToDoMe.Views.Templates.AddEditItem;
using ToDoMe.Views.Templates.Auth;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: ExportFont("FontAwesome-Regular.ttf", Alias = "FontAwesome_Regular")]
[assembly: ExportFont("FontAwesome-Solid.ttf", Alias = "FontAwesome_Solid")]

[assembly: ExportFont("Mulish-Black.ttf", Alias = "Mulish_Black")]
[assembly: ExportFont("Mulish-Bold.ttf", Alias = "Mulish_Bold")]
[assembly: ExportFont("Mulish-ExtraBold.ttf", Alias = "Mulish_ExtraBold")]
[assembly: ExportFont("Mulish-ExtraLight.ttf", Alias = "Mulish_ExtraLight")]
[assembly: ExportFont("Mulish-Light.ttf", Alias = "Mulish_Light")]
[assembly: ExportFont("Mulish-Medium.ttf", Alias = "Mulish_Medium")]
[assembly: ExportFont("Mulish-Regular.ttf", Alias = "Mulish_Regular")]
[assembly: ExportFont("Mulish-SemiBold.ttf", Alias = "Mulish_SemiBold")]

namespace ToDoMe
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) 
        { }

        public new static App Current => Application.Current as App;

        protected override async void OnInitialized()
        {
            InitializeComponent();
            SetAppTheme();

            var auth = DependencyService.Get<IFirebaseAuthentication>();
            var isLoggedIn = auth.IsLoggedIn();
            if (isLoggedIn)
            {
                await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(TasksPage)}");
            }
            else
            {
                await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(WelcomePage)}");
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterRegionServices();

            containerRegistry.Register<IDateService, DateService>();
            containerRegistry.Register<IFirestoreRepository<TaskModel>, TasksRepository>();
            containerRegistry.Register<IFirestoreRepository<ListModel>, ListsRepository>();

            containerRegistry.RegisterForNavigation<NavigationPage>("NavigationPage");
            containerRegistry.RegisterForNavigation<WelcomePage, WelcomePageViewModel>("WelcomePage");
            containerRegistry.RegisterForNavigation<TasksPage, TasksPageViewModel>("TasksPage");
            containerRegistry.RegisterForNavigation<AddEditPage, AddEditPageViewModel>("AddEditPage");
            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>("ProfilePage");
            containerRegistry.RegisterForNavigation<AuthPage, AuthPageViewModel>("AuthPage");
            containerRegistry.RegisterForNavigation<MorePage, MorePageViewModel>("MorePage");

            containerRegistry.RegisterForRegionNavigation<AddEditListTemplate, AddEditListViewModel>("AddEditListTemplate");
            containerRegistry.RegisterForRegionNavigation<AddEditTaskTemplate, AddEditTaskViewModel>("AddEditTaskTemplate");

            containerRegistry.RegisterForRegionNavigation<LoginTemplate, LoginViewModel>();
            containerRegistry.RegisterForRegionNavigation<SignUpTemplate, SignUpViewModel>();
            containerRegistry.RegisterForRegionNavigation<ResetPasswordTemplate, ResetPasswordViewModel>();

            containerRegistry.RegisterDialog<ListDialog, ListDialogViewModel>();
            containerRegistry.RegisterDialog<ErrorDialog, ErrorDialogViewModel>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void SetAppTheme()
        {
            var theme = Preferences.Get("theme", string.Empty);
            if (string.IsNullOrEmpty(theme) || theme == "light")
            {
                Application.Current.UserAppTheme = OSAppTheme.Light;
            }
            else
            {
                Application.Current.UserAppTheme = OSAppTheme.Dark;
            }
        }
    }
}
