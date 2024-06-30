using Gulayan.DataContexts;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Windows;

namespace Gulayan
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DatabaseFacade facade = new DatabaseFacade(new AdminDataContext());
            facade.EnsureCreated();

            DatabaseFacade productdb = new DatabaseFacade(new ProductDataContext());
            productdb.EnsureCreated();
        }
    }
}
