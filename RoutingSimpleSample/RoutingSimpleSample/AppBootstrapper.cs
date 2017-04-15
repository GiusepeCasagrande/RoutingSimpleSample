using System;
using ReactiveUI;
using ReactiveUI.XamForms;
using RoutingSimpleSample.ViewModels;
using RoutingSimpleSample.Views;
using Splat;
using Xamarin.Forms;

namespace RoutingSimpleSample
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        public RoutingState Router { get; protected set; }

        public AppBootstrapper()
        {
            Router = new RoutingState();
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
            Locator.CurrentMutable.Register(() => new MenuCellView(), typeof(IViewFor<MenuCellViewModel>));
            Locator.CurrentMutable.Register(() => new MenuView(), typeof(IViewFor<MenuViewModel>));
            Locator.CurrentMutable.Register(() => new SamplePageView(), typeof(IViewFor<SamplePageViewModel>));

            this
                .Router
                .NavigateAndReset
                .Execute(new MenuViewModel())
                .Subscribe();
        }

        public Page CreateMainPage()
        {
            // NB: This returns the opening page that the platform-specific
            // boilerplate code will look for. It will know to find us because
            // we've registered our AppBootstrapper as an IScreen.
            return new RoutedViewHost();
        }
    }
}