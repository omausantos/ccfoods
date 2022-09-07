using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Modulo01.Paginas.ItensCardapio
{
    public partial class ItensCardapioPage : ContentPage
    {
        public ItensCardapioPage()
        {
            InitializeComponent();
            BtnNovoItemClick();
        }

        private void BtnNovoItemClick()
        {
            BtnNovoItem.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new ItensCardapioNewPage());
            };
        }
    }
}

