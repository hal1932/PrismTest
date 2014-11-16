using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace PrismTest.Behaviors
{
    class ShowWindowAction : TriggerAction<DependencyObject>
    {
        public enum Mode
        {
            Show,
            ShowDialog,
        }


        #region Type
        public Type Type
        {
            get { return (Type)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Type.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(Type), typeof(ShowWindowAction), new PropertyMetadata(null));
        #endregion

        #region ConstuctorArg
        public object ConstructorArg
        {
            get { return (object)GetValue(ConstuctorArgProperty); }
            set { SetValue(ConstuctorArgProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConstuctorArg.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConstuctorArgProperty =
            DependencyProperty.Register("ConstuctorArg", typeof(object), typeof(ShowWindowAction), new PropertyMetadata(null));
        #endregion

        #region DataContext
        public ViewModels.ViewModelBase DataContext
        {
            get { return (ViewModels.ViewModelBase)GetValue(DataContextProperty); }
            set { SetValue(DataContextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataContext.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataContextProperty =
            DependencyProperty.Register("DataContext", typeof(ViewModels.ViewModelBase), typeof(ShowWindowAction), new PropertyMetadata(null));
        #endregion

        #region OpenMode
        public Mode OpenMode
        {
            get { return (Mode)GetValue(OpenModeProperty); }
            set { SetValue(OpenModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenModeProperty =
            DependencyProperty.Register("OpenMode", typeof(Mode), typeof(ShowWindowAction), new PropertyMetadata(Mode.Show));
        #endregion


        protected override void Invoke(object parameter)
        {
            if (Type == null) throw new ArgumentNullException("Type");

            var windowObj = (ConstructorArg != null) ?
                Activator.CreateInstance(Type, ConstructorArg) : Activator.CreateInstance(Type);
            var window = windowObj as Window;
            if (window == null) return;

            window.DataContext = DataContext;
            window.Owner = Window.GetWindow(AssociatedObject);

            switch(OpenMode)
            {
                case ShowWindowAction.Mode.Show:
                    window.Show();
                    break;

                case ShowWindowAction.Mode.ShowDialog:
                    window.ShowDialog();
                    break;
            }
        }
    }
}
