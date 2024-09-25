using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Interface
{
    //public class RelayCommand : ICommand
    //{
    //    readonly Action<object> _execute;
    //    readonly Predicate<object> _canExecute;

    //    //cоздает новую команду, которую всегда можно выполнить
    //    /// <param name="execute">The execution logic.</param>
    //    public RelayCommand(Action<object> execute)
    //       : this(execute, null)
    //    {
    //    }

    //    //Создает новую команду
    //    /// <param name="execute">The execution logic.</param>
    //    /// <param name="canExecute">The execution status logic.</param>
    //    public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    //    {
    //        if (execute == null)
    //            throw new ArgumentNullException("execute");

    //        _execute = execute;
    //        _canExecute = canExecute;
    //    }

    //    //Члены команды ICommand
    //    [DebuggerStepThrough]
    //    public bool CanExecute(object parameter)
    //    {
    //        return _canExecute == null ? true : _canExecute(parameter);
    //    }

    //    public event EventHandler CanExecuteChanged
    //    {
    //        //add { CommandParameter.RequerySuggested += value; }
    //        //remove { CommandManager.RequerySuggested -= value; }
    //    }

    //    public void Execute(object parameter)
    //    {
    //        _execute(parameter);
    //    }
    //}
}
