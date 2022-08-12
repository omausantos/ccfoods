using System;
using System.Collections.Generic;

using Xamarin.Forms;

using Modulo01.Dal;
using Modulo01.Modelo;
using System.Linq;

namespace Modulo01.Paginas.Entregadores
{
    public partial class EntregadoresNewPage : ContentPage
    {
        private EntregadorDAL dalEntregador = EntregadorDAL.GetInstance();

        public EntregadoresNewPage()
        {
            InitializeComponent();
            PrepararParaNovoEntregador();
        }

        private void PrepararParaNovoEntregador()
        {
            var novoId = dalEntregador.GetAll().OrderBy(i => i.Id).Max(i => i.Id) + 1;
            identregador.Text = novoId.ToString().Trim();
            nome.Text = String.Empty;
            telefone.Text = String.Empty;
        }

        public void BtnGravarClick(object sender, EventArgs args)
        {
            if(nome.Text.Trim() == String.Empty || telefone.Text.Trim() == String.Empty)
            {
                this.DisplayAlert("Erro", "Voce precisa informar o nome e telefone para o novo entregador", "ok");
            } else
            {
                dalEntregador.Add(new Entregador()
                {
                    Id = Convert.ToInt32(identregador.Text),
                    Nome = nome.Text,
                    Telefone = telefone.Text
                });
                PrepararParaNovoEntregador();
                Navigation.PushAsync(new Entregadores.EntregadoresPage());
            }
        }
    }
}

