using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace KGKRegister
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://twitter.com/peacecwz")));
        }

        public ICommand OpenWebCommand { get; }
    }
}
