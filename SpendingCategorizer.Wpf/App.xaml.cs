using SpendingCategorizer.Core.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SpendingCategorizer.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static TransactionCatagoryLibrary CategoryLibrary { get; set; }

    
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        CategoryLibrary = new TransactionCatagoryLibrary();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        CategoryLibrary.SaveCategoriesToJson();
        base.OnExit(e);
    }
}

}
