using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AzureStorageWebinar.View
{
    public partial class PersonRegistrationPage : ContentPage
    {
        public PersonRegistrationPage()
        {
            InitializeComponent();
            BindingContext = new ViewModel.PersonRegistrationVM();
        }
    }
}
