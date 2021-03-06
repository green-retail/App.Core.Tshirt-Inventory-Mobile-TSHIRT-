﻿using App.Core.Tshirt.Models;
using App.Core.Tshirt.Services;
using App.Core.Tshirt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Core.Tshirt.Pages.Count
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlanList : ContentPage
	{
        public string _user { get; set; }
        private CountServices countServices;
        public PlanList(string user)
        {
            _user = user;
            InitializeComponent();
            countServices = new CountServices();
            BindingContext = new CountViewModel(null, user);
        }

        private async void ListCount_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            CountViewModel viewModel = sender as CountViewModel;
            if (e.SelectedItem == null)
            {
                return;
            }
            var x = (CountPlan)e.SelectedItem;


            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new Plan(x.Id, _user));

        }

        private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}