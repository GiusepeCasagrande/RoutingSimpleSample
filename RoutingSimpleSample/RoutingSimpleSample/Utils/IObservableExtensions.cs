using System;
using System.Reactive.Disposables;

namespace RoutingSimpleSample.Utils
{
    public static class IObservableExtensions
    {
        public static TDisposable DisposeWith<TDisposable>(this TDisposable observable, CompositeDisposable disposables) where TDisposable : class, IDisposable
        {
            if (observable != null)
                disposables.Add(observable);

            return observable;
        }
    }
}
