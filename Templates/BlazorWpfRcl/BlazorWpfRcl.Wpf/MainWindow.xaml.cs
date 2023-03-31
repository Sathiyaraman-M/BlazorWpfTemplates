using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BlazorWpfRcl.App;
using Microsoft.AspNetCore.Components.WebView.Wpf;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWpfRcl.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();var webView = new BlazorWebView
            {
                HostPage = @"wwwroot\index.html"
            };
            var services = new ServiceCollection();
            services.AddWpfBlazorWebView();
            services.AddBlazorWebViewDeveloperTools();
            webView.Services = services.BuildServiceProvider();
            webView.RootComponents.Add(new RootComponent
            {
                ComponentType = typeof(Root),
                Selector = "#app"
            });
            Content = webView;
            AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
            {
                MessageBox.Show(error.ExceptionObject.ToString(), "Unhandled Exception", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            };
        }
    }
}
