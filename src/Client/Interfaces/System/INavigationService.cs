using Client.ViewModels.Base;

namespace Client.Interfaces.System
{
    public interface INavigationService : IService
    {
        /// <summary>
        /// Задает экранз агрузки стартовой страницей
        /// </summary>
        void SetLoadingPageAsRoot();

        /// <summary>
        /// Задает меню начальной страницей
        /// </summary>
        void SetMenuPageAsRoot();

        /// <summary>
        /// Задает авторизвацию начальной страницей
        /// </summary>
        void SetLoginPageAsRoot();

        /// <summary>
        /// Выполняет навигацию на страницу
        /// </summary>
        /// <typeparam name="TView">Тип вью</typeparam>
        /// <typeparam name="TViewModal">Тип вью модели</typeparam>
        Task NavigateToPage<TView, TViewModal>()
            where TView : ContentPage
            where TViewModal : BaseViewModel;

        /// <summary>
        /// Выполняет навигацию на страницу, при этом передается параметр
        /// </summary>
        /// <typeparam name="TView">Тип вью</typeparam>
        /// <typeparam name="TViewModal">Тип вью модели</typeparam>
        /// <typeparam name="TParam">Тип параметра</typeparam>
        Task NavigateToPage<TView, TViewModal, TParam>(TParam param)
            where TView : ContentPage
            where TViewModal : BaseViewModel;

        /// <summary>
        /// Выполняет навигацию на модальную страницу
        /// </summary>
        /// <typeparam name="TView">Тип вью</typeparam>
        /// <typeparam name="TViewModal">Тип вью модели</typeparam>
        Task NavigateToModalPage<TView, TViewModal>()
            where TView : ContentPage
            where TViewModal : BaseViewModel;

        /// <summary>
        /// Выполняет навигацию назад со страницы
        /// </summary>
        Task NavigateBackFromPage();

        /// <summary>
        /// Выполняет навигацию назад с модалки
        /// </summary>
        Task NavigateBackFromModalPage();
    }
}
