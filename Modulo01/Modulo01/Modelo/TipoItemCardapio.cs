using System;
using SQLite;

namespace Modulo01.Modelo
{
    public class TipoItemCardapio
    {
        [PrimaryKey, AutoIncrement]
        public long? TipoItemCardapioId { get; set; }
        public string Nome { get; set; }
        public byte[] Foto { get; set;}

        public override bool Equals(object obj)
        {
            TipoItemCardapio tipoItemCardapio = obj as TipoItemCardapio;
            if (tipoItemCardapio == null)
            {
                return false;
            }
            return (TipoItemCardapioId.Equals(tipoItemCardapio.TipoItemCardapioId));
        }

        public override int GetHashCode()
        {
            return TipoItemCardapioId.GetHashCode();
        }
    }
}

