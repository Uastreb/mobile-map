using Client.Interfaces.System;
using Client.Pages;
using Client.Pages.Login;
using Client.ViewModels;
using Client.ViewModels.Base;

namespace Client.Services.System
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;

        private INavigation _navigation;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc/>
        public void SetMenuPageAsRoot()
        {
            var view = _serviceProvider.GetRequiredService<AppFlyout>();

            Application.Current.MainPage = view;
            _navigation = Application.Current.MainPage.Navigation;
        }

        /// <inheritdoc/>
        public void SetLoadingPageAsRoot()
        {
            var view = _serviceProvider.GetRequiredService<LoadingPage>();
            var viewModal = _serviceProvider.GetRequiredService<LoadingPageViewModel>();

            view.BindingContext = viewModal;
            viewModal.OnInitialized();

            Application.Current.MainPage = new NavigationPage(view);
            _navigation = Application.Current.MainPage.Navigation;
        }

        /// <inheritdoc/>
        public void SetLoginPageAsRoot()
        {
            var view = _serviceProvider.GetRequiredService<EnterNumberPage>();
            var viewModal = _serviceProvider.GetRequiredService<EnterNumberViewModel>();

            view.BindingContext = viewModal;
            viewModal.OnInitialized();

            Application.Current.MainPage = new NavigationPage(view);
            _navigation = Application.Current.MainPage.Navigation;
        }

        /// <inheritdoc/>
        public async Task NavigateToPage<TView, TViewModal>()
            where TView : ContentPage
            where TViewModal : BaseViewModel
        {
            var view = _serviceProvider.GetRequiredService<TView>();
            var viewModal = _serviceProvider.GetRequiredService<TViewModal>();

            view.BindingContext = viewModal;
            viewModal.OnInitialized();

            await _navigation.PushAsync(view);
        }

        /// <inheritdoc/>
        public async Task NavigateToPage<TView, TViewModal, TParam>(TParam param)
            where TView : ContentPage
            where TViewModal : BaseViewModel
        {
            var view = _serviceProvider.GetRequiredService<TView>();
            var viewModal = _serviceProvider.GetRequiredService<TViewModal>();
            viewModal.SetParam(param);

            view.BindingContext = viewModal;
            viewModal.OnInitialized();

            await _navigation.PushAsync(view);
        }

        /// <inheritdoc/>
        public async Task NavigateToModalPage<TView, TViewModal>()
            where TView : ContentPage
            where TViewModal : BaseViewModel
        {
            var view = _serviceProvider.GetRequiredService<TView>();
            var viewModal = _serviceProvider.GetRequiredService<TViewModal>();

            view.BindingContext = viewModal;
            viewModal.OnInitialized();

            await _navigation.PushModalAsync(view);
        }

        /// <inheritdoc/>
        public async Task NavigateBackFromPage()
        {
            await _navigation.PopAsync();
        }

        /// <inheritdoc/>
        public async Task NavigateBackFromModalPage()
        {
            await _navigation.PopModalAsync();
        }
    }
}
