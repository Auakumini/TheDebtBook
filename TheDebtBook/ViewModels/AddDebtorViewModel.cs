using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheDebtBook.Data;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    public partial class AddDebtorViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _debtorName;

        [ObservableProperty]
        private double _amountOwed;

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

            Debtor newDebtor = new()
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