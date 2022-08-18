using System;
using System.Collections.Generic;
using Modulo01.Dal;
using Xamarin.Forms;

namespace Modulo01.Paginas.TiposItensCardapio
{
    public partial class TiposItensCardapioListPage : ContentPage
    {
        private TipoItemCardapioDAL dalTipoItemCardapio = TipoItemCardapioDAL.GetInstance();

        public TiposItensCardapioListPage()
        {
            InitializeComponent();
            lvTiposItensCardapio.ItemsSource = dalTipoItemCardapio.GetAll();
        }
    }
}

