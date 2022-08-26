using System;
using Modulo01.Modelo;
using System.Collections.ObjectModel;

namespace Modulo01.Dal
{
	public class TipoItemCardapioDAL
	{
		private ObservableCollection<TipoItemCardapio> TiposItensCardapio = new ObservableCollection<TipoItemCardapio>();
		private static TipoItemCardapioDAL TipoItemCardapioInstance = new TipoItemCardapioDAL();

		public TipoItemCardapioDAL()
		{
			TiposItensCardapio.Add(new TipoItemCardapio()
			{
				Id = 1,
				Nome = "Pizza",
				CaminhoArquivoFoto = "pizzas.png"
			});
			TiposItensCardapio.Add(new TipoItemCardapio()
			{
				Id = 2,
				Nome = "Bebidas",
				CaminhoArquivoFoto = "bebidas.png"
			});
			TiposItensCardapio.Add(new TipoItemCardapio()
			{
				Id = 3,
				Nome = "Saladas",
				CaminhoArquivoFoto = "saladas.png"
			});
		}

		public static TipoItemCardapioDAL GetInstance()
        {
			return TipoItemCardapioInstance;
        }

		public ObservableCollection<TipoItemCardapio> GetAll()
        {
			return TiposItensCardapio;
        }

		public void Add(TipoItemCardapio tipoItemCardapio)
        {
			this.TiposItensCardapio.Add(tipoItemCardapio);
        }

		public void Remove(TipoItemCardapio tipoItemCardapio)
        {
			this.TiposItensCardapio.Remove(tipoItemCardapio);
        }

		public void Update(TipoItemCardapio tipoItemCardapio)
        {
			this.TiposItensCardapio[this.TiposItensCardapio.IndexOf(tipoItemCardapio)] = tipoItemCardapio;
        }
	}
}

