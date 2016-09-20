using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;

namespace RoutingSimpleSample.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public ReactiveList<MenuCellViewModel> MenuItems
        {
            get;
        }

        MenuCellViewModel m_selectedItem;
        public MenuCellViewModel SelectedItem
        {
            get { return m_selectedItem; }
            set { this.RaiseAndSetIfChanged(ref m_selectedItem, value); }
        }

        public MenuViewModel(IScreen hostScreen = null) : base(hostScreen)
        {
            UrlPathSegment = "Menu";

            MenuItems = new ReactiveList<MenuCellViewModel>();

            this
                .WhenAnyValue(x => x.MenuItems)
                .Where(mi => mi.Count <= 0)
                .Subscribe(o => AddMenuItems())
                .DisposeWith(subscriptionDisposables);

            this
                .WhenAnyValue(x => x.SelectedItem)
                .Where(x => x != null)
                .Subscribe(x => LoadSelectedPage(x))
                .DisposeWith(subscriptionDisposables);
        }

        void AddMenuItems()
        {
            MenuItems.Add(new MenuCellViewModel
            {
                Name = "Option 1",
                MenuItem = MenuItemEnum.Option1
            });

            MenuItems.Add(new MenuCellViewModel
            {
                Name = "Option 2",
                MenuItem = MenuItemEnum.Option2
            });

            MenuItems.Add(new MenuCellViewModel
            {
                Name = "Option 3",
                MenuItem = MenuItemEnum.Option3
            });
        }

        void LoadSelectedPage(MenuCellViewModel viewModel)
        {
            HostScreen.Router.Navigate.Execute(new SamplePageViewModel(viewModel));        
        }
    }
}