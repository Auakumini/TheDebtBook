using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheDebtBook.Data;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Debtor> _debtorsList;

        public ObservableCollection<Debtor> DebtorsList
        {
            get => _debtorsList;
            set => SetProperty(ref _debtorsList, value);
        }

        public ICommand NavigateToAddDebtorCommand { get; }
        public ICommand NavigateToDebtorDetailsCommand { get; }

        public MainPageViewModel()
        {
            LoadDebtors();
            NavigateToAddDebtorCommand = new RelayCommand(OnNavigateToAddDebtor);
            NavigateToDebtorDetailsCommand = new RelayCommand<int>(OnNavigateToDebtorDetails);
        }

        internal async Task LoadDebtors()
        {
            try
            {
                DebtorsList = new ObservableCollection<Debtor>(await DataBaseHelper.GetAllDebtorsAsync());
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Debug.WriteLine(ex.Message);
            }
        }


        private static void OnNavigateToAddDebtor()
        {
            Shell.Current.GoToAsync("//AddDebtorPage");
        }

        private static void OnNavigateToDebtorDetails(int debtorId)
        {
            Shell.Current.GoToAsync($"//DebtorDetailsPage?debtorId={debtorId}");
        }


    }
}