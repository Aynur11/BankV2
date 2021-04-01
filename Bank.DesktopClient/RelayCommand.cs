using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bank.DesktopClient
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Проверяет возможность выполнения.
        /// </summary>
        /// <param name="parameter">Делегат.</param>
        /// <returns>Результат проверки.</returns>
        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        /// <summary>
        /// Запустить выполнение.
        /// </summary>
        /// <param name="parameter">Делегат.</param>
        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
