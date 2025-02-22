﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfTestingApplication {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private void Application_Startup(object sender, StartupEventArgs e) {
            Application.Current.Properties["GodMode"] = false;

            foreach (string arg in e.Args) {
                if (arg.Equals("/godmode", StringComparison.OrdinalIgnoreCase)) {
                    Application.Current.Properties["GodMode"] = true;
                    break;
                }
            }
        }

        private void Application_Exit(object sender, ExitEventArgs e) {

        }
    }
}
