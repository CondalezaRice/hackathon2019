using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MKUltra
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
    }

    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _executeAction;
        private readonly Func<object, bool> _canExecuteAction;

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        public void Execute(object parameter) => _executeAction(parameter);

        public bool CanExecute(object parameter) => _canExecuteAction?.Invoke(parameter) ?? true;

        public event EventHandler CanExecuteChanged;

        public void InvokeCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    class GameViewModel : ViewModelBase
    {
        private bool playerHasWon;
        public bool PlayerHasWon
        {
            get => playerHasWon;
            set => SetProperty(ref playerHasWon, value);
        }

        private ICommand togglePlayerHasWon;
        public ICommand TogglePlayerHasWon
        {
            get => togglePlayerHasWon;
            set => SetProperty(ref togglePlayerHasWon, value);
        }

        public GameViewModel()
        {
           togglePlayerHasWon = new DelegateCommand(OnTogglePlayerHasWon, null);
        }

        private void OnTogglePlayerHasWon(object o)
        {
            PlayerHasWon = !PlayerHasWon;
        }
    }
}
