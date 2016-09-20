using System;
using System.Reactive.Disposables;

namespace RoutingSimpleSample.Utils
{
    public static class CompositeDisposableExtensions
    {
        public static T AddTo<T>(this T @this, CompositeDisposable compositeDisposable)
            where T : IDisposable
        {
            compositeDisposable.Add(@this);
            return @this;
        }
    }
}
