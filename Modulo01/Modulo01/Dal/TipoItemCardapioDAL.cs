using Modulo01.Infrastructure;
using Modulo01.Modelo;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Modulo01.Dal
{
	public class TipoItemCardapioDAL
	{
		private SQLiteConnection sqlConnection;

		public TipoItemCardapioDAL()
		{
			this.sqlConnection = DependencyService.Get<IDatabaseConnection>().DbConnection();
			this.sqlConnection.CreateTable<TipoItemCardapio>();
		}

		public IEnumerable<TipoItemCardapio> GetAll()
        {
			return (from t in sqlConnection.Table<TipoItemCardapio>() select t).OrderBy(i => i.Nome).ToList();
        }

		public TipoItemCardapio GetItemById(long id)
        {
			return sqlConnection.Table<TipoItemCardapio>().FirstOrDefault(t => t.TipoItemCardapioId == id);
        }

		public void DeleteById(long id)
        {
			sqlConnection.Delete<TipoItemCardapio>(id);
        }

		public void Add(TipoItemCardapio tipoItemCardapio)
        {
			sqlConnection.Insert(tipoItemCardapio);
        }

		public void Udpate(TipoItemCardapio tipoItemCardapio)
        {
			sqlConnection.Update(tipoItemCardapio);
        }

	}
}

