using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheDebtBook.Data;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    public class DebtorDetailsViewModel : BaseViewModel
    {
        private ObservableCollection<DebtTransaction> _transactionsList;
        private string _newTransactionDescription;
        private double _newTransactionAmount;
        private int _debtorId;

        private string _debtorName;
        private double _totalAmountOwed;

        private Debtor _selectedDebtor;

        public int DebtorId
        {
            get => _debtorId;
            set => SetProperty(ref _debtorId, value);
        }
        public Debtor SelectedDebtor
        {
            get => _selectedDebtor;
            set => SetProperty(ref _selectedDebtor, value);
        }

        public string DebtorName
        {
            get => _debtorName;
            set => SetProperty(ref _debtorName, value);
        }

        public double TotalAmountOwed
        {
            get => _totalAmountOwed;
            set => SetProperty(ref _totalAmountOwed, value);
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

        public ObservableCollection<DebtTransaction> TransactionsList { get; }
        public ICommand AddTransactionCommand { get; }

        private bool _transactionsLoaded;

        public bool TransactionsLoaded
        {
            get => _transactionsLoaded;
            set => SetProperty(ref _transactionsLoaded, value);
        }


        public async Task LoadTransactionsAsync()
        {
            if (!TransactionsLoaded)
            {
                var transactions = await DataBaseHelper.GetTransactionsForDebtorAsync(_debtorId);

                foreach (var transaction in transactions)
                {
                    TransactionsList.Add(transaction);
                }

                TransactionsLoaded = true; // Set the flag to indicate that transactions have been loaded
            }
        }

        public DebtorDetailsViewModel(int debtorId)
        {
            _debtorId = debtorId;
            TransactionsList = new ObservableCollection<DebtTransaction>();
            LoadTransactionsAsync();
            AddTransactionCommand = new RelayCommand(OnAddTransaction);
            //DataBaseHelper.ClearAllTransactionsAsync(); //uncomment to remove all transactions, DANGEROUS!
        }

        private async void OnAddTransaction()
        {
            if (string.IsNullOrEmpty(NewTransactionDescription) || NewTransactionAmount == 0)
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

            // Add the new transaction to the list
            TransactionsList.Add(newTransaction);

            // Save the new transaction to the database
            await DataBaseHelper.AddDebtTransactionAsync(newTransaction);

            NewTransactionDescription = string.Empty;
            NewTransactionAmount = 0;
        }

    }
}