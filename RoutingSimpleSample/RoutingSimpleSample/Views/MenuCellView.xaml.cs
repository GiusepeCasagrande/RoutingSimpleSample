using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.XamForms;
using RoutingSimpleSample.ViewModels;
using Xamarin.Forms;

namespace RoutingSimpleSample.Views
{
    public partial class MenuCellView : ReactiveViewCell<MenuCellViewModel>
    {
        protected readonly CompositeDisposable SubscriptionDisposables = new CompositeDisposable();

        public MenuCellView()
        {
            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.Icon, x => x.PageIcon.Text).DisposeWith(SubscriptionDisposables);
                this.OneWayBind(ViewModel, x => x.Name, x => x.PageName.Text).DisposeWith(SubscriptionDisposables);
            });
        }
    }
}
