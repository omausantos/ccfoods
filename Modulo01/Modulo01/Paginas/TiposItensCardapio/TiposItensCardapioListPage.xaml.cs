using System;
using System.Collections.Generic;
using Modulo01.Dal;
using Modulo01.Modelo;
using Xamarin.Forms;

namespace Modulo01.Paginas.TiposItensCardapio
{
    public partial class TiposItensCardapioListPage : ContentPage
    {
        private TipoItemCardapioDAL dalTipoItemCardapio = new TipoItemCardapioDAL();

        public TiposItensCardapioListPage()
        {
            InitializeComponent();
        }

        public async void OnRomoverClick(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var item = mi.CommandParameter as TipoItemCardapio;
            var opcao = await DisplayAlert("Confirmação de exclusao", "Confirmar excluir o item " + item.Nome.Trim() + "?", "Sim", "Não");
            if (opcao)
            {
                dalTipoItemCardapio.DeleteById((long)item.TipoItemCardapioId);
                lvTiposItensCardapio.ItemsSource = dalTipoItemCardapio.GetAll();
            }
        }

        public async void OnAlterarClick(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var item = mi.CommandParameter as TipoItemCardapio;
            await Navigation.PushModalAsync(new TiposItensCardapioEditPage(item));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvTiposItensCardapio.ItemsSource = dalTipoItemCardapio.GetAll();
        }
    }
}

