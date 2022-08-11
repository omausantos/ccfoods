
using Xamarin.Forms;

namespace Modulo01.Paginas
{
    public class MenuPage : ContentPage
    {
        public MenuPage()
        {
            Title = "Menu de opções";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    new Button()
                    {
                        Text = "Garçons",
                        ImageSource = "icone_garcons.png",
                        Command = new Command(() => Navigation.PushAsync(new Garcons.GarconsPage()))
                    }
                }
            };
        }
    }
}


