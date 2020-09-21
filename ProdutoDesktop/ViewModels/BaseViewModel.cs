using Dominio.DAO;
using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace ProdutoDesktop.ViewModels
{
    public abstract class BaseViewModel<TObj> : INotifyPropertyChanged where TObj : Model, new()
    {
        public BaseViewModel(ITelaCadastro<TObj> telaCadastro)
        {
            this.telaCadastro = telaCadastro;
        }

        public ICommand Salvar
        {
            get
            {
                if (salvar == null)
                    salvar = new MyCommand(SalvarObjeto);

                return salvar;
            }
        }

        public ICommand Excluir
        {
            get
            {
                if (excluir == null)
                    excluir = new MyCommand(ExcluirObjeto);

                return excluir;
            }
        }

        public ICommand AbrirTelaConsultar
        {
            get
            {
                if (abrirTelaConsultar == null)
                    abrirTelaConsultar = new MyCommand(AbrirTelaConsultarObjeto);

                return abrirTelaConsultar;
            }
        }

        public ICommand AbrirTelaAlterar
        {
            get
            {
                if (abrirTelaAlterar == null)
                    abrirTelaAlterar = new MyCommand(AbrirTelaAlterarObjeto);

                return abrirTelaAlterar;
            }
        }

        public ICommand AbrirTelaIncluir
        {
            get
            {
                if (abrirTelaIncluir == null)
                    abrirTelaIncluir = new MyCommand(AbrirTelaIncluirObjeto);

                return abrirTelaIncluir;
            }
        }

        public ICommand FecharTelaCadastro
        {
            get
            {
                if (fecharTelaCadastro == null)
                    fecharTelaCadastro = new MyCommand(() => { telaCadastro.Fechar(); status = EStatusCadastro.Listando; });

                return fecharTelaCadastro;
            }
        }

        public void Notificar<T>(ref T atributo, T valor, [CallerMemberName] string nomePropriedade = "")
        {
            if (atributo == null && valor == null)
                return;
            if (atributo != null && atributo.Equals(valor))
                return;
            atributo = valor;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
        }

        public bool PodeSalvar { get => status == EStatusCadastro.Incluindo || status == EStatusCadastro.Alterando; }

        public bool Consultando { get => status == EStatusCadastro.Consultando; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<TObj> Lista { get; set; } = new ObservableCollection<TObj>();

        public TObj Selecionado { get; set; }

        public TObj Cadastro { get => cadastro; set => Notificar(ref cadastro, value); }

        protected abstract IDAO<TObj> GetDAO();
        protected virtual void InserirObjeto()
        {
            GetDAO().Inserir(Cadastro);
            Cadastro = new TObj();
            PreencherLista();
        }
        protected virtual void AlterarObjeto()
        {
            GetDAO().Atualizar(Cadastro);
            Cadastro = new TObj();
            PreencherLista();
        }

        protected virtual void ExcluirObjeto()
        {
            GetDAO().Remover(Selecionado);
            PreencherLista();
        }

        protected void PreencherLista()
        {
            Lista.Clear();

            var registros = GetDAO().RetornarTodos();

            foreach (var obj in registros)
                Lista.Add(obj);
        }

        private void AbrirTelaIncluirObjeto()
        {
            status = EStatusCadastro.Incluindo;
            this.Cadastro = new TObj();
            telaCadastro.Abrir(this);
        }

        private void AbrirTelaConsultarObjeto()
        {
            status = EStatusCadastro.Consultando;
            this.Cadastro = Selecionado;
            telaCadastro.Abrir(this);
        }

        private void AbrirTelaAlterarObjeto()
        {
            status = EStatusCadastro.Alterando;
            this.Cadastro = Selecionado;
            telaCadastro.Abrir(this);
        }

        private void SalvarObjeto()
        {
            if (Cadastro.Id == null)
                InserirObjeto();
            else
                AlterarObjeto();

            Cadastro = new TObj();

            telaCadastro.Fechar();
            status = EStatusCadastro.Listando;
        }

        private ICommand abrirTelaConsultar = null;
        private ICommand salvar = null;
        private ICommand abrirTelaAlterar = null;
        private ICommand abrirTelaIncluir = null;
        private ICommand excluir = null;
        private ICommand fecharTelaCadastro = null;
        private EStatusCadastro status = EStatusCadastro.Listando;
        private TObj cadastro = new TObj();
        private ITelaCadastro<TObj> telaCadastro;
    }
}
