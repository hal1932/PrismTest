using Microsoft.Practices.Prism.Mvvm;
using System;

namespace PrismTest.ViewModels
{
    class ViewModelBase : BindableBase, IDisposable
    {
        public virtual void Dispose() { }
    }
}
