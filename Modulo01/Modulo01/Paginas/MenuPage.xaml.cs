using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Modulo01.Paginas
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        public async void GarconsOnClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Garcons.GarconsPage());
        }

        public async void EntregadoresOnClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Entregadores.EntregadoresPage());
        }
    }
}

