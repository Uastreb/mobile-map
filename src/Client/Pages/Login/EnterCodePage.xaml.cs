using Client.Constants.AppConstants;
using Client.ViewModels;

namespace Client.Pages.Login;

public partial class EnterCodePage : ContentPage
{
    private IDispatcherTimer _timer;

    private EnterCodeViewModel _enterCodeViewModel;

    public EnterCodePage()
    {
        InitializeComponent();

        this.Appearing += EnterCodePage_Appearing;
        this.Loaded += EnterCodePage_Loaded;
        this.Unloaded += EnterCodePage_Unloaded;
    }

    private void EnterCodePage_Appearing(object sender, EventArgs e)
    {
        _enterCodeViewModel = BindingContext as EnterCodeViewModel;
    }

    private void EnterCodePage_Unloaded(object sender, EventArgs e)
    {
        DisposeTimer();
    }

    private void EnterCodePage_Loaded(object sender, EventArgs e)
    {
        InitTimer();
        StartTimer();
    }

    private void InitTimer()
    {
        _timer = Application.Current.Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += (s, e) => 
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _enterCodeViewModel.TimerValue -= TimeSpan.FromSeconds(1);
                timerLable.Text = _enterCodeViewModel.TimerValue.ToString("mm\\:ss");
                _enterCodeViewModel.ValidateForm();
                if (_enterCodeViewModel.TimerValue == TimeSpan.Zero)
                {
                    StopTimer();
                }
            });
        };
    }

    public void StopTimer()
    {
        _timer.Stop();
        enterCodeTimerStack.IsVisible = false;
        requestNewCodeLink.IsVisible = true;
    }

    public void StartTimer()
    {
        _enterCodeViewModel.TimerValue = EnterCodeConstants.TimerValue;
        requestNewCodeLink.IsVisible = false;
        enterCodeTimerStack.IsVisible = true;
        _timer.Start();
    }

    public void DisposeTimer()
    {
        _timer.Stop();
        _timer = null;
    }

    private async void RequestNewCodeLink_Tapped(object sender, TappedEventArgs e)
    {
        await _enterCodeViewModel.SendCode();
        StartTimer();
    }

    private void CodeEntry_ValueChanged(object sender, Syncfusion.Maui.Inputs.MaskedEntryValueChangedEventArgs e)
    {
        _enterCodeViewModel.ValidateForm();
    }
}