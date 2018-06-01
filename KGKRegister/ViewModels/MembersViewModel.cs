using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace KGKRegister
{
    public class MembersViewModel : BaseViewModel
    {
        public ObservableCollection<Member> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public MembersViewModel()
        {
            Title = "Members";
            Items = new ObservableCollection<Member>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewMemberPage, Member>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Member;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });

            MessagingCenter.Subscribe<MembersPage, Member>(this, "DeleteItem", async (obj, item) =>
            {
                var _item = item as Member;
                Items.Remove(_item);
                await DataStore.DeleteItemAsync(_item.Id);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
