using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PrismTest.Models;

namespace PrismTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Context.Instance.CategoryArray = new Category[]
            {
                new Category()
                {
                    Name = "category1",
                    ItemArray = new string[] { "item1" }
                },
                new Category()
                {
                    Name = "category2",
                    ItemArray = new string[] { "item2-1", "item2-2"}
                },
                new Category()
                {
                    Name = "category3"
                }
            };
        }
    }
}
