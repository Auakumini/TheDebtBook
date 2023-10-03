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

        private void OnDebtorSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Debtor selectedDebtor)
            {
                (BindingContext as MainPageViewModel)?.NavigateToDebtorDetailsCommand.Execute(selectedDebtor.Id);
            }

            // Deselect the item in the ListView
            ((ListView)sender).SelectedItem = null;
        }
    }
}