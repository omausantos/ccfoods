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
        private string caminhoArquivo;
        private TipoItemCardapioDAL dalTipoItemCardapio = TipoItemCardapioDAL.GetInstance();

        public TiposItensCardapioEditPage(TipoItemCardapio tipoItemCardapio)
        {
            InitializeComponent();
            PopularFormulario(tipoItemCardapio);
            RegistraClickBotaoAlbum(idtipoitemcardapio.Text.Trim());
            RegistraClickBotaoCamera(idtipoitemcardapio.Text.Trim());
        }

        private void PopularFormulario(TipoItemCardapio tipoItemCardapio)
        {
            this.tipoItemCardapio = tipoItemCardapio;
            idtipoitemcardapio.Text = tipoItemCardapio.Id.ToString();
            nome.Text = tipoItemCardapio.Nome.ToString();
            caminhoArquivo = tipoItemCardapio.CaminhoArquivoFoto;
            fototipoitemcardapio.Source = ImageSource.FromFile(tipoItemCardapio.CaminhoArquivoFoto);
        }

        private void RegistraClickBotaoAlbum(string idparafoto)
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

                string nomeArquivo = "tipoitem_" + idparafoto + ".jpg";

                caminhoArquivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Fotos");
                if (!Directory.Exists(caminhoArquivo))
                    Directory.CreateDirectory(caminhoArquivo);

                caminhoArquivo = Path.Combine(caminhoArquivo, nomeArquivo);
                using (FileStream fileStream = new FileStream(caminhoArquivo, FileMode.Create))
                {
                    file.GetStream().CopyTo(fileStream);
                }

                fototipoitemcardapio.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };
        }

        private void RegistraClickBotaoCamera(string idparafoto)
        {
            BtnCamera.Clicked += async (sender, e) =>
            {
                await CrossMedia.Current.Initialize();

                if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Não existe camera", "A camera não está disponivel", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Fotos",
                    Name = "tipoitem_" + idparafoto.Trim() + ".jpg"
                });
                if (file == null)
                    return;

                fototipoitemcardapio.Source = ImageSource.FromFile(file.Path);
                caminhoArquivo = file.Path;
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
                this.tipoItemCardapio.CaminhoArquivoFoto = caminhoArquivo;
                dalTipoItemCardapio.Update(this.tipoItemCardapio);
                await Navigation.PopModalAsync();
            }
        }
    }
}

