﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Debtor> _debtorsList;

        public ICommand NavigateToAddDebtorCommand { get; }

        public ObservableCollection<Debtor> DebtorsList
        {
            get => _debtorsList;
            set => SetProperty(ref _debtorsList, value);
        }

        public MainPageViewModel()
        {
            NavigateToAddDebtorCommand = new Command(OnNavigateToAddDebtor);
        }

        private void OnNavigateToAddDebtor()
        {
            // TODO: Implement navigation logic to go to the AddDebtorPage
        }

    }

}
