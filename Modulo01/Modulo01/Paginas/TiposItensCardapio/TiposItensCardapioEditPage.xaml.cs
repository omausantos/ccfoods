using System;
using System.Collections.Generic;
using System.IO;
using Modulo01.Dal;
using Modulo01.Modelo;
using Plugin.Media;
using Xamarin.Forms;

namespace Modulo01.Paginas.TiposItensCardapio
{
    public partial class TiposItensCardapioEditPage : ContentPage
    {
        private TipoItemCardapio tipoItemCardapio;
        private TipoItemCardapioDAL dalTipoItemCardapio = new TipoItemCardapioDAL();
        private byte[] bytesFoto;

        public TiposItensCardapioEditPage(TipoItemCardapio tipoItemCardapio)
        {
            InitializeComponent();
            PopularFormulario(tipoItemCardapio);
            RegistraClickBotaoAlbum();
            RegistraClickBotaoCamera();
        }

        private void PopularFormulario(TipoItemCardapio tipoItemCardapio)
        {
            this.tipoItemCardapio = tipoItemCardapio;
            nome.Text = tipoItemCardapio.Nome.ToString();
        }

        private void RegistraClickBotaoAlbum()
        {
            BtnAlbum.Clicked += async (sender, e) =>
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Álbum não suportado", "Não existe permissão para acessar o álbum de fotos", "OK");
                    return;
                }

                var file = await CrossMedia.Current.PickPhotoAsync();

                if (file == null)
                    return;

                var stream = file.GetStream();
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                fototipoitemcardapio.Source = ImageSource.FromStream(() =>
                {
                    var s = file.GetStream();
                    file.Dispose();
                    return s;
                });

                bytesFoto = memoryStream.ToArray();
            };
        }

        private void RegistraClickBotaoCamera()
        {
            BtnCamera.Clicked += async (sender, e) =>
            {
                await CrossMedia.Current.Initialize();

                if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Não existe camera", "A camera não está disponivel", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(
                    new Plugin.Media.Abstractions.StoreCameraMediaOptions
                        {
                            Directory = "Fotos",
                            Name = "tipoitem.jpg",
                            SaveToAlbum = true
                        });
                if (file == null)
                    return;

                var stream = file.GetStream();
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                fototipoitemcardapio.Source = ImageSource.FromStream(() =>
                {
                    var s = file.GetStream();
                    file.Dispose();
                    return s;
                });

                bytesFoto = memoryStream.ToArray();
            };
        }

        public async void BtnGravarClick(object sender, EventArgs e)
        {
            if(nome.Text.Trim() == String.Empty)
            {
                await this.DisplayAlert("Erro", "Voce precisa informar o nome para o novo tipo de item do cardápio", "OK");
            } else
            {
                this.tipoItemCardapio.Nome = nome.Text;
                await Navigation.PopModalAsync();
            }
        }
    }
}

