using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Controls;
using System.Windows.Input;
using WPFMVVM.TabbingSample.ContorlUtilty;

namespace WPFMVVM.TabbingSample.ViewModels
{
    public class HomeViewModel
    {
        private readonly ObservableCollection<ITab> tabs;
        public HomeViewModel()
        {
            OpenScreenCommand = new RelayCommand(OpenScreen);
            tabs = new ObservableCollection<ITab>();

            tabs.CollectionChanged += Tabs_CollectionChanged;

            Tabs = tabs;
        }

        private void Tabs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ITab tab;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    tab = (ITab)e.NewItems[0];
                    tab.CloseRequested += OnTabCloseRequested;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    tab = (ITab)e.OldItems[0];
                    tab.CloseRequested -= OnTabCloseRequested;
                    break;
            }
        }

        private void OnTabCloseRequested(object sender, EventArgs e)
        {
            Tabs.Remove((ITab)sender);
        }

        public ICommand OpenScreenCommand { get; }
        public ObservableCollection<ITab> Tabs { get; set; }


        public void OpenScreen(object Screen)
        {
            switch (Screen)
            {
                case "Product":
                    Tabs.Add(new ProductViewModel());
                    break;
                case "Product Details":
                    Tabs.Add(new ProductDetailViewModel());
                    break;
                default:
                    break;
            }
        }

    }

    public class RelayCommand : ICommand
    {
        Action<object> _execteMethod;
        Func<object, bool> _canexecuteMethod;


        public RelayCommand(Action<object> execteMethod)
        {
            _execteMethod = execteMethod;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            _execteMethod(parameter);
        }
    }

}
