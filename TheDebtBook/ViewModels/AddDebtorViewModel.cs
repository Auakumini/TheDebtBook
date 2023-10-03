using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    public class AddDebtorViewModel : BaseViewModel
    {
        private string _debtorName;
        private double _amountOwed;

        public ICommand AddDebtorCommand { get; }

        public string DebtorName
        {
            get => _debtorName;
            set => SetProperty(ref _debtorName, value);
        }

        public double AmountOwed
        {
            get => _amountOwed;
            set => SetProperty(ref _amountOwed, value);
        }

        public AddDebtorViewModel()
        {
            AddDebtorCommand = new Command(OnAddDebtor);
        }

        private void OnAddDebtor()
        {
            if (string.IsNullOrWhiteSpace(DebtorName) || AmountOwed <= 0)
            {
                // Handle validation errors, e.g., show a message to the user
                return;
            }

            // Create a new Debtor object
            Debtor newDebtor = new Debtor
            {
                Name = DebtorName,
                TotalAmountOwed = AmountOwed
            };

            // TODO: Add the new debtor to a collection or database

            // Optionally, reset the input fields
            DebtorName = string.Empty;
            AmountOwed = 0;
        }

    }

}
