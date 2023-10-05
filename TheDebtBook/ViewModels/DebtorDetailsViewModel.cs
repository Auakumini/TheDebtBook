using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheDebtBook.Data;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    public partial class DebtorDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<DebtTransaction> _transactionsList;

        [ObservableProperty]
        private string _newTransactionDescription;

        [ObservableProperty]
        private double _newTransactionAmount;

        private int _debtorId;

        public ICommand AddTransactionCommand { get; }

        public DebtorDetailsViewModel(int debtorId)
        {
            _debtorId = debtorId;
            LoadTransactions();
            AddTransactionCommand = new RelayCommand(OnAddTransaction);
        }

        private async void LoadTransactions()
        {
            TransactionsList = new ObservableCollection<DebtTransaction>(await DataBaseHelper.GetTransactionsForDebtorAsync(_debtorId));
        }

        private void OnAddTransaction()
        {
            if (string.IsNullOrWhiteSpace(NewTransactionDescription) || NewTransactionAmount == 0)
            {
                return;
            }

            DebtTransaction newTransaction = new DebtTransaction
            {
                Description = NewTransactionDescription,
                Amount = NewTransactionAmount,
                Date = DateTime.Now,
                Type = NewTransactionAmount > 0 ? TransactionType.Credit : TransactionType.Debit,
                DebtorId = _debtorId
            };

            // Save the new transaction to the database
            DataBaseHelper.AddDebtTransactionAsync(newTransaction);

            // Reload the transactions
            LoadTransactions();

            // Clear the input fields
            NewTransactionDescription = string.Empty;
            NewTransactionAmount = 0;
        }
    }
}
