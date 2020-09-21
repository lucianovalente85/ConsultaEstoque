using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ProdutoDesktop.ViewModels
{
    public class TelaCadastroApresentacao<TObj, TWindow> : ITelaCadastro<TObj> where TObj : Model, new () where TWindow : Window, new()
    {
        public void Abrir(BaseViewModel<TObj> viewModel)
        {
            form = new TWindow();
            form.DataContext = viewModel;
            form.ShowDialog();

        }

        public void Fechar()
        {
            if (form != null)
                form.Close();
        }

        private TWindow form = null;
    }
}
