﻿using App.Core.Tshirt.Models;
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
	public partial class PlanResume : ContentPage
	{
        public string _user { get; set; }
        public PlanResume(List<ViewCountPlanDetailExtend> plan, string planName, string user)
        {
            _user = user;
            InitializeComponent();
            BindingContext = new CountResumeViewModel(plan, planName, _user);
        }

        private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new MainMenu(_user));
        }
    }
}