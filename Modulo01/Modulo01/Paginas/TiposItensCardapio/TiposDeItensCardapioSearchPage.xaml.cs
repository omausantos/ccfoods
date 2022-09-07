using System;
using System.Collections.Generic;
using System.Linq;
using Modulo01.Dal;
using Modulo01.Modelo;
using Xamarin.Forms;

namespace Modulo01.Paginas.TiposItensCardapio
{
    public partial class TiposDeItensCardapioSearchPage : ContentPage
    {
        private TipoItemCardapioDAL dalTipoItemCardapio = new TipoItemCardapioDAL();
        private Label displayValue;
        private Label keyValue;
        private IEnumerable<TipoItemCardapio> itens;

        public TiposDeItensCardapioSearchPage(Label keyValue, Label displayValue)
        {
            InitializeComponent();
            itens = dalTipoItemCardapio.GetAll();
            this.keyValue = keyValue;
            this.displayValue = displayValue;
        }

        void OnTextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            lvTipos.BeginRefresh();
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                lvTipos.ItemsSource = itens;
            else
                lvTipos.ItemsSource = itens.Where(i => i.Nome.Contains(e.NewTextValue));
            lvTipos.EndRefresh();
        }

        async void OnItemTapped(System.Object o, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var item = (o as ListView).SelectedItem as TipoItemCardapio;
            this.keyValue.Text = item.TipoItemCardapioId.ToString();
            this.displayValue.Text = item.Nome;
            await Navigation.PopAsync();
        }
    }
}

