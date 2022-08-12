using System;
using Modulo01.Modelo;
using System.Collections.ObjectModel;

namespace Modulo01.Dal
{
    public class EntregadorDAL
    {
        private ObservableCollection<Entregador> Entregadores = new ObservableCollection<Entregador>();
        private static EntregadorDAL EntregadorInstance = new EntregadorDAL();

        public EntregadorDAL()
        {
            Entregadores.Add(new Entregador()
            {
                Id = 1,
                Nome = "Brauzio",
                Telefone = "Asdrugio"
            });
            Entregadores.Add(new Entregador()
            {
                Id = 2,
                Nome = "Entencius",
                Telefone = "Gesfredio"
            });
            Entregadores.Add(new Entregador()
            {
                Id = 3,
                Nome = "Cartucious",
                Telefone = "Gesfrundio"
            });
        }

        public static EntregadorDAL GetInstance()
        {
            return EntregadorInstance;
        }

        public ObservableCollection<Entregador> GetAll()
        {
            return Entregadores;
        }

        public void Add(Entregador entregador)
        {
            this.Entregadores.Add(entregador);
        }
    }
}

