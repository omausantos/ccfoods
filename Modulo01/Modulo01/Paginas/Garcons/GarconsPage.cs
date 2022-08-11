using System;

using Xamarin.Forms;

namespace Modulo01.Paginas.Garcons
{
    public class GarconsPage : TabbedPage
    {
        public GarconsPage()
        {
            Children.Add(new GarconsListPage()
            {
                Title = "Listagem",
                IconImageSource = "icone_list.png"
            });
            Children.Add(new GarconsNewPage()
            {
                Title = "Inserir Novo Garçon",
                IconImageSource = "icone_new.png"
            });
        }
    }
}


