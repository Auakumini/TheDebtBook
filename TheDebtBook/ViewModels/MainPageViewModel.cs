﻿using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheDebtBook.Data;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Debtor> _debtorsList;

        public ICommand NavigateToAddDebtorCommand { get; }
        public ICommand NavigateToDebtorDetailsCommand { get; }

        public MainPageViewModel()
        {
            _ = LoadDebtors();
            NavigateToAddDebtorCommand = new RelayCommand(OnNavigateToAddDebtor);
            NavigateToDebtorDetailsCommand = new RelayCommand<int>(OnNavigateToDebtorDetails);
        }

        public async Task LoadDebtors()
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

        private void OnNavigateToAddDebtor()
        {
            Shell.Current.GoToAsync("//AddDebtorPage");
        }

        private void OnNavigateToDebtorDetails(int debtorId)
        {
            Shell.Current.GoToAsync($"//DebtorDetailsPage?debtorId={debtorId}");
        }
    }
}