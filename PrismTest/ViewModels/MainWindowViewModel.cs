using PrismTest.Models;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using System.Diagnostics;

namespace PrismTest.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        public Context Context
        {
            get { return Context.Instance; }
        }

        public InteractionRequest<Notification> TestRequest
        {
            get { return _testRequest; }
        }
        private InteractionRequest<Notification> _testRequest = new InteractionRequest<Notification>();

        public ViewModelBase SubWindowViewModel
        {
            get { return _subWindowViewModel; }
        }
        private ViewModelBase _subWindowViewModel = new SubWindowViewModel();


        public MainWindowViewModel()
        {
        }


        public override void Dispose()
        {
            _subWindowViewModel.Dispose();
            base.Dispose();
        }

        public void RaiseTestRequest()
        {
            var notification = new Notification()
            {
                Title = "title",
                Content = "hoge",
            };
            TestRequest.Raise(notification, (item) => Debug.WriteLine(item.Title));
        }
    }
}
