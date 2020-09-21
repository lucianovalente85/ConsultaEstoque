using Dominio.Models;

namespace ProdutoDesktop.ViewModels
{
    public interface ITelaCadastro<T> where T : Model, new()
    {
        void Abrir(BaseViewModel<T> viewModel);
        void Fechar();
    }
}