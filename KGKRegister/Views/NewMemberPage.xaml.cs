using System;

using Xamarin.Forms;

namespace KGKRegister
{
    public partial class NewMemberPage : ContentPage
    {
        public Member Item { get; set; }

        public NewMemberPage()
        {
            InitializeComponent();

            Item = new Member();

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopToRootAsync();
        }
    }
}
