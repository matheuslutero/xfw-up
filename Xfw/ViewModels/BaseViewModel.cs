using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xfw.ViewModels
{
    public abstract class BaseViewModel : BindableObject
    {
        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set { isBusy = value; OnPropertyChanged(); }
        }

        public bool IsNotBusy => !IsBusy;

        public async Task ExecuteBusyAction(Func<Task> theBusyAction)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                await theBusyAction();
            }
            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(ex);
#endif
            }
            finally
            {
                IsBusy = false;
            }
        }

        public virtual Task Initialize()
            => Task.CompletedTask;
    }
}
