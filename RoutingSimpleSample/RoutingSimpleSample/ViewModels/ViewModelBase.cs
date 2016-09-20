using System;
using System.Reactive.Disposables;
using ReactiveUI;
using Splat;

namespace RoutingSimpleSample.ViewModels
{
    public class ViewModelBase : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment
        {
            get;
            protected set;
        }

        public IScreen HostScreen
        {
            get;
            protected set;
        }

        protected readonly CompositeDisposable subscriptionDisposables = new CompositeDisposable();

        public ViewModelBase(IScreen hostScreen = null)
        {
            HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();
        }
    }
}

