using System.Reactive.Disposables;
using ReactiveUI;
using RoutingSimpleSample.Utils;
using RoutingSimpleSample.ViewModels;

namespace RoutingSimpleSample.Views
{
    public partial class MenuView : ContentPageBase<MenuViewModel>
    {
        public MenuView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.SelectedItem = null;

            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.MenuItems, x => x.MenuList.ItemsSource).DisposeWith(SubscriptionDisposables);
                this.Bind(ViewModel, x => x.SelectedItem, x => x.MenuList.SelectedItem).DisposeWith(SubscriptionDisposables);
            });
        }
    }
}

