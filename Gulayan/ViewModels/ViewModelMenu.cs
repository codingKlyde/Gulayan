using MahApps.Metro.IconPacks;
using System.Windows.Input;

namespace Gulayan.ViewModels
{
    public class ViewModelMenu : ViewModelBase
    {
        public ViewModelMenu()
        {
            ExecuteShowDashboardCommand(null);

            ShowCatalogCommand = new RelayCommand(ExecuteShowCatalogCommand);
            ShowDashboardCommand = new RelayCommand(ExecuteShowDashboardCommand);
            ShowMemberCommand = new RelayCommand(ExecuteShowMemberCommand);
            ShowSettingsCommand = new RelayCommand(ExecuteShowSettingsCommand);
        }

        // Window Header (WH)
        #region 
        private PackIconMaterialKind _whIcon;
        private string _whTitle;
        public PackIconMaterialKind WHIcon
        {
            get { return _whIcon; }
            set
            {
                _whIcon = value;
                OnPropertyChanged(nameof(WHIcon));
            }
        }
        public string WHTitle
        {
            get { return _whTitle; }
            set
            {
                _whTitle = value;
                OnPropertyChanged(nameof(WHTitle));
            }
        }

        public ICommand ShowCatalogCommand { get; }
        public ICommand ShowDashboardCommand { get; }
        public ICommand ShowMemberCommand { get; }
        public ICommand ShowSettingsCommand { get; }
        #endregion

        // Window Content (WC)
        #region
        private ViewModelBase _wcCurrentView;
        public ViewModelBase WCCurrentView
        {
            get { return _wcCurrentView; }
            set
            {
                _wcCurrentView = value;
                OnPropertyChanged(nameof(WCCurrentView));
            }
        }
        #endregion

        private void ExecuteShowCatalogCommand(object obj)
        {
            ViewModelCatalog viewModel = new ViewModelCatalog();
            WCCurrentView = viewModel;
            WHTitle = "CATALOG";
            WHIcon = PackIconMaterialKind.FoodApple;
        }
        private void ExecuteShowDashboardCommand(object obj)
        {
            ViewModelDashboard viewModel = new ViewModelDashboard();
            WCCurrentView = viewModel;
            WHTitle = "DASHBOARD";
            WHIcon = PackIconMaterialKind.ViewDashboard;
        }
        private void ExecuteShowMemberCommand(object obj)
        {
            ViewModelMember viewModel = new ViewModelMember();
            WCCurrentView = viewModel;
            WHTitle = "MEMBER";
            WHIcon = PackIconMaterialKind.AccountGroup;
        }
        private void ExecuteShowSettingsCommand(object obj)
        {
            ViewModelSettings viewModel = new ViewModelSettings();
            WCCurrentView = viewModel;
            WHTitle = "SETTINGS";
            WHIcon = PackIconMaterialKind.Cog;
        }
    }
}