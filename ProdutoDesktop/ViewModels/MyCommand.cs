using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProdutoDesktop.ViewModels
{
    public class MyCommand : ICommand
    {
        public MyCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public MyCommand(Action execute) : this(execute, () => true) { }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => canExecute();

        public void Execute(object parameter) => execute();

        private Action execute;
        private Func<bool> canExecute;
    }
}
