using Client.ViewModels;

namespace Client.Pages.Login;

public partial class EnterNumberPage : ContentPage
{
    private EnterNumberViewModel _enterNumberViewModel;

    public EnterNumberPage()
    {
        InitializeComponent();

        this.Appearing += EnterNumberPage_Appearing;
    }

    private void EnterNumberPage_Appearing(object sender, EventArgs e)
    {
        _enterNumberViewModel = BindingContext as EnterNumberViewModel;
    }

    private void PhoneEntry_ValueChanged(object sender, Syncfusion.Maui.Inputs.MaskedEntryValueChangedEventArgs e)
    {
        _enterNumberViewModel.ValidateForm();
    }

    private void PrivaciPolicyCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _enterNumberViewModel.ValidateForm();
    }
}