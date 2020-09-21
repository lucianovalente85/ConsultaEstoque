using Dominio.DAO;
using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoDesktop.ViewModels
{
    class ProdutoViewModel : BaseViewModel<Produto>
    {
        public ProdutoViewModel(ITelaCadastro<Produto> telaCadastro) : base(telaCadastro)
        {
            PreencherLista();
        }

        protected override IDAO<Produto> GetDAO()
        {
            return dao;
        }

        private FakeDAO<Produto> dao = new FakeDAO<Produto>();
    }
}
