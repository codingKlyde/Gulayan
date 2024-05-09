using FontAwesome.Sharp;
using System.Windows.Input;

namespace Gulayan.ViewModels
{
    public class ViewModelMenu : ViewModelBase
    {
        private IconChar _icon;
        private string _caption;
        private ViewModelBase _currentChildView;

        public IconChar Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }
        public string Caption 
        {
            get { return _caption; }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public ViewModelBase CurrentChildView 
        {
           get { return _currentChildView; }
           set 
            { 
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }


        public ICommand ShowCatalogCommand { get; }
        public ICommand ShowDashboardCommand { get; }

        public ViewModelMenu()
        {
            ExecuteShowDashboardCommand(null);

            ShowCatalogCommand = new RelayCommand(ExecuteShowCatalogCommand);
            ShowDashboardCommand = new RelayCommand(ExecuteShowDashboardCommand);
        }

        private void ExecuteShowCatalogCommand(object obj)
        {
            ViewModelCatalog viewModel = new ViewModelCatalog(); 
            CurrentChildView = viewModel;
            Caption = "Catalog";
            Icon = IconChar.BoxesStacked;
        }

        private void ExecuteShowDashboardCommand(object obj)
        {
            ViewModelDashboard viewModel = new ViewModelDashboard();
            CurrentChildView = viewModel;
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }
    }
}
