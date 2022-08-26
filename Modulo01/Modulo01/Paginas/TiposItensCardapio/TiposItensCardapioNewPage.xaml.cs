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
        private TipoItemCardapioDAL dalTipoItensCardapio = TipoItemCardapioDAL.GetInstance();
        private string caminhoArquivo;

        public TiposItensCardapioNewPage()
        {
            InitializeComponent();
            PreparaParaNovoTipoItemCardapio();
            RegistraClickBotaoCamera(idtipoitemcardapio.Text.Trim());
            RegitraClickBotaoAlbum(idtipoitemcardapio.Text.Trim());
        }

        private void PreparaParaNovoTipoItemCardapio()
        {
            var novoId = dalTipoItensCardapio.GetAll().OrderBy(i => i.Id).Max(i => i.Id) + 1;
            idtipoitemcardapio.Text = novoId.ToString().Trim();
            nome.Text = String.Empty;
            fototipoitemcardapio.Source = null;
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

                var file = await CrossMedia.Current.TakePhotoAsync(
                    new Plugin.Media.Abstractions.StoreCameraMediaOptions
                        {
                            Directory = "Fotos",
                            Name = "tipoitem_" + idparafoto + ".jpg",
                            SaveToAlbum = true
                        }
                );

                if (file == null)
                    return;

                caminhoArquivo = file.Path;

                fototipoitemcardapio.Source = ImageSource.FromStream(() => {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };
        }

        private void RegitraClickBotaoAlbum(string idparafoto)
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

                string nomeArquivo = "tipoitem_" + idparafoto + ".jpeg";

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

        public void BtnGravarClick(object sender, EventArgs e)
        {
            if(nome.Text.Trim() == String.Empty)
            {
                this.DisplayAlert("Error", "Voce precisa informar o nome para o novo arquivo tipo de item cardápio.", "OK");
            } else
            {
                dalTipoItensCardapio.Add(new TipoItemCardapio()
                {
                    Id = Convert.ToInt32(idtipoitemcardapio.Text),
                    Nome = nome.Text,
                    CaminhoArquivoFoto = caminhoArquivo
                });
                PreparaParaNovoTipoItemCardapio();
            }
        }
    }
}

