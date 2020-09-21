using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.DAO
{
    public interface IDAO<T> where T : Model
    {
        void Inserir(T obj);

        void Remover(T obj);

        void Atualizar(T obj);

        T RetornarPorId(string id);

        List<T> RetornarTodos();
    }
}
