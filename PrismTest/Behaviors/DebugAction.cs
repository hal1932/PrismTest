using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using System.Diagnostics;
using System.Windows;
using System.Windows.Interactivity;

namespace PrismTest.Behaviors
{
    class DebugAction : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
#if DEBUG
            Debugger.Break();
#endif
        }
    }
}
