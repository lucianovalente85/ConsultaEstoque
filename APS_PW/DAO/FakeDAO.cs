using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.DAO
{
    public class FakeDAO<T> : IDAO<T> where T : Model
    {
        public void Inserir(T obj)
        {
            if (obj.Id == null)
                obj.Id = Guid.NewGuid().ToString();

            registros.Insert(0, obj);
        }
        public void Atualizar(T obj)
        {
            Remover(obj);
            Inserir(obj);
        }

        public void Remover(T obj)
        {
            var reg = RetornarPorId(obj.Id);
            registros.Remove(reg);
        }

        public T RetornarPorId(string id) => registros.Where(x => x.Id.Equals(id)).FirstOrDefault();

        public List<T> RetornarTodos() => registros;

        private List<T> registros = new List<T>();
    }
}
