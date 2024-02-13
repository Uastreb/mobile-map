using Client.Interfaces.Entity;
using Client.Interfaces.System;
using ServerApi.Exceptions;
using ServerApi.Exceptions.Base;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Hashtable _params = new Hashtable();

        private readonly IDialogService _dialogService;
        private readonly IIdentityService _identityService;

        public BaseViewModel(IServiceProvider serviceProvider)
        {
            _dialogService = serviceProvider.GetRequiredService<IDialogService>();
            _identityService = serviceProvider.GetRequiredService<IIdentityService>();
        }

        public virtual void OnInitialized()
        {
        }

        protected void StateHasChanged()
        {
            var bindableProps = this.GetType().GetProperties().Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(BindableAttribute)));
            foreach (var bindableProp in bindableProps)
            {
                OnPropertyChanged(bindableProp.Name);
            }
        }

        public void SetParam<TParam>(TParam param)
        {
            _params.Add(param.GetType(), param);
        }

        protected TParam GetParam<TParam>()
        {
            var paramObj = _params[typeof(TParam)];
            var param = (TParam)paramObj;

            return param;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual async Task<bool> SafeExecuteAsync(Func<Task> execute)
        {
            try
            {
                await execute();

                return true;
            }
            catch (Exception ex)
            {
                if (ex is ApiException)
                {
                    switch (ex)
                    {
                        case UnauthorizedException:
                            {
                                await _identityService.RefreshToken();

                                break;
                            }
                        case BadRequestException badRequestException:
                            {
                                await _dialogService.DisplayAlert("Ошибка", badRequestException.Message, "Ок");

                                break;
                            }
                    }
                }

                return false;
            }
        }
    }

}
