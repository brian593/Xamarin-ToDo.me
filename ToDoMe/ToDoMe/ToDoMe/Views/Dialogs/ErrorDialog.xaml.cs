﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoMe.Views.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorDialog : Frame
    {
        public ErrorDialog()
        {
            InitializeComponent();
        }
    }
}