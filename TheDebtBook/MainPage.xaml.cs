using TheDebtBook.ViewModels;
using Microsoft.Maui.Controls;
using TheDebtBook.Models;

namespace TheDebtBook
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnDebtorSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Debtor selectedDebtor)
            {
                // Pass the selected debtor object when navigating to the DebtorDetailsPage
                await Navigation.PushAsync(new DebtorDetailsPage(selectedDebtor));
            }

            // Deselect the item in the ListView
            ((ListView)sender).SelectedItem = null;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as MainPageViewModel)?.LoadDebtors();
        }
    }

}