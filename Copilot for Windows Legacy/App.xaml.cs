using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.Wpf;
using System.Windows;

namespace Copilot_for_Windows_Legacy
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (!Cef.IsInitialized)
            {
                var settings = new CefSettings();
                settings.CachePath = @"C:\MeuApp\Cache";
                Cef.Initialize(settings);
            }
        }
    }

}
