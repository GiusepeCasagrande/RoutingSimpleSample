using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Foundation;
using ReactiveUI;
using UIKit;

namespace RoutingSimpleSample.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        AutoSuspendHelper suspendHelper;

        public AppDelegate()
        {
            RxApp.SuspensionHost.CreateNewAppState = () => new AppBootstrapper();
        }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            LogFonts();

            return base.FinishedLaunching(app, options);
        }
        /// <summary>
        /// Logs the installed fonts to the debug window.
        /// </summary>
        private void LogFonts()
        {
            foreach (NSString family in UIFont.FamilyNames)
            {
                foreach (NSString font in UIFont.FontNamesForFamilyName(family))
                {
                    Debug.WriteLine(@"{0}", font);
                }
            }
        }
    }
}

