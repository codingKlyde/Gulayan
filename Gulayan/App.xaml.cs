using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Windows;

namespace Gulayan
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DatabaseFacade facade = new DatabaseFacade(new UserDataContext());
            facade.EnsureCreated();
        }
    }

}
