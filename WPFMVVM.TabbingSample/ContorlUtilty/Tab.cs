using Microsoft.Expression.Interactivity.Core;
using System;
using System.Windows.Input;

namespace WPFMVVM.TabbingSample.ContorlUtilty
{
    public abstract class Tab : ITab
    {
        public Tab()
        {
            CloseCommand = new ActionCommand(e => CloseRequested?.Invoke(this, EventArgs.Empty));
        }
        public string Name { get; set ; }

        public ICommand CloseCommand { get;  }

        public event EventHandler CloseRequested;
    }
}
