using System;

using Xamarin.Forms;

namespace KGKRegister
{
    public partial class MemberDetailPage : ContentPage
    {
        private readonly MemberDetailViewModel _viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public MemberDetailPage()
        {
            InitializeComponent();

            var item = new Member();

            _viewModel = new MemberDetailViewModel(item);
            BindingContext = _viewModel;
        }

        public MemberDetailPage(MemberDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this._viewModel = viewModel;
        }
    }
}
