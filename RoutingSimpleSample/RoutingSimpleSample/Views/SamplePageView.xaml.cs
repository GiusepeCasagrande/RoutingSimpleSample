using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using ReactiveUI;
using RoutingSimpleSample.ViewModels;
using Xamarin.Forms;

namespace RoutingSimpleSample.Views
{
    public partial class SamplePageView : ContentPageBase<SamplePageViewModel>
    {
        public SamplePageView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.Icon, x => x.PageIcon.Text).DisposeWith(SubscriptionDisposables);
                this.OneWayBind(ViewModel, x => x.Name, x => x.PageName.Text).DisposeWith(SubscriptionDisposables);
            });
        }
    }
}
