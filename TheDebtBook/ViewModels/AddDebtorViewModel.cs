using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheDebtBook.Data;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    public class AddDebtorViewModel : BaseViewModel
    {
        private string _debtorName;
        private double _amountOwed;

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

        public ICommand AddDebtorCommand { get; }

        public AddDebtorViewModel()
        {
            AddDebtorCommand = new RelayCommand(OnAddDebtor);
        }

        private void OnAddDebtor()
        {
            if (string.IsNullOrWhiteSpace(DebtorName) || AmountOwed <= 0)
            {
                return;
            }

            Debtor newDebtor = new Debtor
            {
                Name = DebtorName,
                TotalAmountOwed = AmountOwed
            };
            // Save the new debtor to the database
            DataBaseHelper.AddDebtorAsync(newDebtor);

            // Navigate back to the main page after adding
            Shell.Current.GoToAsync("//MainPage");
        }
    }
}