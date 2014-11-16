using PrismTest.Models;

namespace PrismTest.ViewModels
{
    class SubWindowViewModel : ViewModelBase
    {
        public Context Context
        {
            get { return Context.Instance; }
        }


        public SubWindowViewModel()
        {
        }
    }
}
