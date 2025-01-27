﻿using Prism.Navigation;
using Prism.Regions.Navigation;
using System;
using System.ComponentModel;
using Xamarin.CommunityToolkit.UI.Views;

namespace ToDoMe.ViewModels
{
    public class BaseRegionViewModel:
        INotifyPropertyChanged, 
        IRegionAware
    {
        #region Private & Protected

        protected INavigationService _navigationService { get; set; }

        #endregion

        #region Properties

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }
        public LayoutState MainState { get; set; }

        #endregion

        #region Constructor

        public BaseRegionViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        #endregion

        #region Region Navigation Handlers

        public virtual void OnNavigatedTo(INavigationContext navigationContext) { }

        public virtual bool IsNavigationTarget(INavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public virtual void OnNavigatedFrom(INavigationContext navigationContext) { }

        #endregion
    }
}
