using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Modulo01.Paginas.ItensCardapio.Controls
{
    public partial class GridCustomControl : Grid
    {
        public GridCustomControl()
        {
            InitializeComponent();
        }

        async void OnTapLookForTipos(System.Object sender, System.EventArgs e)
        {
           await Navigation.PushAsync(new Paginas.TiposItensCardapio.TiposDeItensCardapioSearchPage(idTipo, nomeTipo));
        }

    }
}

