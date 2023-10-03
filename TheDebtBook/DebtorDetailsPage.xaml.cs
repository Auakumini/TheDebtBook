using TheDebtBook.ViewModels;

namespace TheDebtBook;

public partial class DebtorDetailsPage : ContentPage
{
    public DebtorDetailsPage(int debtorId)
    {
        InitializeComponent();
        BindingContext = new DebtorDetailsViewModel(debtorId);
    }

}