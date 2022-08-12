using System;
using System.Collections.Generic;

using Xamarin.Forms;

using Modulo01.Dal;

namespace Modulo01.Paginas.Entregadores
{
    public partial class EntregadoresListPage : ContentPage
    {
        private EntregadorDAL dalEntregadores = EntregadorDAL.GetInstance();

        public EntregadoresListPage()
        {
            InitializeComponent();
            lvEntregadores.ItemsSource = dalEntregadores.GetAll();
        }
    }
}

