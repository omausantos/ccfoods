using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Modulo01.Dal;
using System.Linq;
using Plugin.Media;
using System.IO;
using Modulo01.Modelo;

namespace Modulo01.Paginas.TiposItensCardapio
{
    public partial class TiposItensCardapioNewPage : ContentPage
    {
        private TipoItemCardapioDAL dalTipoItensCardapio = new TipoItemCardapioDAL();
        private byte[] bytesFoto;

        public TiposItensCardapioNewPage()
        {
            InitializeComponent();
            PreparaParaNovoTipoItemCardapio();
            RegistraClickBotaoCamera();
            RegitraClickBotaoAlbum();
        }

        private void PreparaParaNovoTipoItemCardapio()
        {
            nome.Text = String.Empty;
            fototipoitemcardapio.Source = null;
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
                        }
                );

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

        private void RegitraClickBotaoAlbum()
        {
            BtnAlbum.Clicked += async (sender, e) =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Álbum não suportado", "Não existe permissão para acessar o album de fotos", "OK");
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

        public void BtnGravarClick(object sender, EventArgs e)
        {
            if(nome.Text.Trim() == String.Empty)
            {
                this.DisplayAlert("Error", "Voce precisa informar o nome para o novo arquivo tipo de item cardápio.", "OK");
            } else
            {
                dalTipoItensCardapio.Add(new TipoItemCardapio()
                {
                    Nome = nome.Text,
                    Foto = bytesFoto
                });
                PreparaParaNovoTipoItemCardapio();
            }
        }
    }
}

