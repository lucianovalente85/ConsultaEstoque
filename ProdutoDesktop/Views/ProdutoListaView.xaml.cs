using Dominio.Models;
using ProdutoDesktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProdutoDesktop.Views
{
    /// <summary>
    /// Lógica interna para ProdutoListaView.xaml
    /// </summary>
    public partial class ProdutoListaView : Window
    {
        public ProdutoListaView()
        {
            InitializeComponent();

            DataContext = new ProdutoViewModel(new TelaCadastroApresentacao<Produto, ProdutoView>());
        }
    }
}
