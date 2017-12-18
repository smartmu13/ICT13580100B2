using ICT13580100B2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ICT13580100B2
{
    public partial class App : Application
    {
        public static dbHelpers dbHelpers { get; set; }
        public App(String dbPath)
        {
            InitializeComponent();

            dbHelpers = new dbHelpers(dbPath);

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
