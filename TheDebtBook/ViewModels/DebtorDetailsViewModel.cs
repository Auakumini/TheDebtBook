using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Transactions;
using System.Windows.Input;
using TheDebtBook.Models;
using TheDebtBook.Data; 

namespace TheDebtBook.ViewModels
{
    public class DebtorDetailsViewModel : BaseViewModel
    {
        private ObservableCollection<DebtTransaction> _transactionsList;
        private string _newTransactionDescription;
        private double _newTransactionAmount;
        private int _debtorId;

        public ICommand AddTransactionCommand { get; }

        public ObservableCollection<DebtTransaction> TransactionsList
        {
            get => _transactionsList;
            set => SetProperty(ref _transactionsList, value);
        }

        public string NewTransactionDescription
        {
            get => _newTransactionDescription;
            set => SetProperty(ref _newTransactionDescription, value);
        }

        public double NewTransactionAmount
        {
            get => _newTransactionAmount;
            set => SetProperty(ref _newTransactionAmount, value);
        }

        public DebtorDetailsViewModel(int debtorId)
        {
            _debtorId = debtorId;
            LoadTransactions();
            AddTransactionCommand = new Command(OnAddTransaction);
        }

        private async void LoadTransactions()
        {
            TransactionsList = new ObservableCollection<DebtTransaction>(await DataBaseHelper.GetTransactionsForDebtorAsync(_debtorId));
        }

        private void OnAddTransaction()
        {
            if (string.IsNullOrWhiteSpace(NewTransactionDescription) || NewTransactionAmount == 0)
            {
                // Handle validation errors, e.g., show a message to the user
                return;
            }

            DebtTransaction newTransaction = new DebtTransaction
            {
                Description = NewTransactionDescription,
                Amount = NewTransactionAmount,
                Date = DateTime.Now,
                Type = NewTransactionAmount > 0 ? TransactionType.Credit : TransactionType.Debit,
                DebtorId = _debtorId  // Associate the transaction with the debtor
            };

            // Save the new transaction to the SQLite database
            DataBaseHelper.AddDebtTransactionAsync(newTransaction);

            // Refresh the transactions list
            LoadTransactions();

            // Optionally, reset the input fields
            NewTransactionDescription = string.Empty;
            NewTransactionAmount = 0;
        }


    }

}
