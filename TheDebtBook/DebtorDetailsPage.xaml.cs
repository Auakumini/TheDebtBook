using TheDebtBook.ViewModels;
using Microsoft.Maui.Controls;
using TheDebtBook.Data;
using TheDebtBook.Models;

namespace TheDebtBook
{
    public partial class DebtorDetailsPage : ContentPage
    {
        // Property to hold the selected debtor
        public Debtor SelectedDebtor { get; set; }

        public DebtorDetailsPage()
        {
            InitializeComponent();
        }

        public DebtorDetailsPage(Debtor selectedDebtor)
        {
            InitializeComponent();

            // Set the selected debtor
            SelectedDebtor = selectedDebtor;

            // Initialize the ViewModel with the debtor's Id
            BindingContext = new DebtorDetailsViewModel(selectedDebtor.Id);

            // Load transactions when the page is created
            (BindingContext as DebtorDetailsViewModel)?.LoadTransactionsAsync();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve the selected debtor using async method
            SelectedDebtor = await DataBaseHelper.GetDebtorByIdAsync((BindingContext as DebtorDetailsViewModel)?.DebtorId ?? 0);

            // Load transactions asynchronously when the page appears
            await (BindingContext as DebtorDetailsViewModel)?.LoadTransactionsAsync();
        }


    }
}