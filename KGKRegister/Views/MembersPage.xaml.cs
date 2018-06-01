using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace KGKRegister
{
    public partial class MembersPage : ContentPage
    {
        private readonly MembersViewModel _viewModel;

        public MembersPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new MembersViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is Member item))
                return;

            await Navigation.PushAsync(new MemberDetailPage(new MemberDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewMemberPage());
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var member = mi.CommandParameter as Member;
            MessagingCenter.Send(this, "DeleteItem", member);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.Items.Count == 0)
                _viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
