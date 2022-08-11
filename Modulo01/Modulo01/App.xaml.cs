using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo01
{
    public partial class App : Application
    {
        public App ()
        {
            MainPage = new NavigationPage(new Paginas.MenuPage());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

