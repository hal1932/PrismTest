using System;
using System.Windows;
using System.Windows.Interactivity;

namespace PrismTest.Behaviors
{
    class InvokeMethodAction : TriggerAction<DependencyObject>
    {
        #region InstanceObj
        public object InstanceObj
        {
            get { return (object)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Target.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("InstanceObj", typeof(object), typeof(InvokeMethodAction), new PropertyMetadata(null));
        #endregion

        #region MethodName
        public string MethodName
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("MethodName", typeof(string), typeof(InvokeMethodAction), new PropertyMetadata(null));
        #endregion


        #region
        public object MethodParameter
        {
            get { return (object)GetValue(MethodParameterProperty); }
            set { SetValue(MethodParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MethodParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MethodParameterProperty =
            DependencyProperty.Register("MethodParameter", typeof(object), typeof(InvokeMethodAction), new PropertyMetadata(null));
        #endregion


        protected override void Invoke(object parameter)
        {
            if (InstanceObj == null) throw new ArgumentNullException("InstanceObj");
            if (MethodName == null) throw new ArgumentNullException("MethodName");

            // TODO: エラーハンドリング
            var method = InstanceObj.GetType().GetMethod(MethodName);
            if (MethodParameter == null)
            {
                method.Invoke(InstanceObj, null);
            }
            else
            {
                method.Invoke(InstanceObj, new object[] { MethodParameter });
            }
        }
    }
}
