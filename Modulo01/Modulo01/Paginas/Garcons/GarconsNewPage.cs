using System;

using Xamarin.Forms;

namespace Modulo01.Paginas.Garcons
{
    public class GarconsNewPage : ContentPage
    {
        public GarconsNewPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}


