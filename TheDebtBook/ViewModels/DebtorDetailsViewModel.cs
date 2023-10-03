using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Transactions;
using System.Windows.Input;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    public class DebtorDetailsViewModel : BaseViewModel
    {
        private ObservableCollection<Transaction> _transactionsList;
        private string _newTransactionDescription;
        private double _newTransactionAmount;

        public ICommand AddTransactionCommand { get; }

        public ObservableCollection<Transaction> TransactionsList
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

        public DebtorDetailsViewModel()
        {
            AddTransactionCommand = new Command(OnAddTransaction);
        }

        private void OnAddTransaction()
        {
            if (string.IsNullOrWhiteSpace(NewTransactionDescription) || NewTransactionAmount == 0)
            {
                // Handle validation errors, e.g., show a message to the user
                return;
            }

            // Create a new Transaction object
            Transaction newTransaction = new Transaction
            {
                Description = NewTransactionDescription,
                Amount = NewTransactionAmount,
                Date = DateTime.Now,
                Type = NewTransactionAmount > 0 ? TransactionType.Credit : TransactionType.Debit
            };

            // TODO: Add the new transaction to the selected debtor's transactions list or database

            // Optionally, reset the input fields
            NewTransactionDescription = string.Empty;
            NewTransactionAmount = 0;
        }

    }

}
