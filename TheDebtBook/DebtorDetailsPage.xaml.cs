using TheDebtBook.ViewModels;
using Microsoft.Maui.Controls;

namespace TheDebtBook
{
    public partial class DebtorDetailsPage : ContentPage
    {
        public DebtorDetailsPage(int debtorId)
        {
            InitializeComponent();
            BindingContext = new DebtorDetailsViewModel(debtorId);
        }
    }
}