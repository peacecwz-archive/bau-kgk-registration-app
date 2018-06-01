using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace KGKRegister
{
    public class CloudDataStore : IDataStore<Member>
    {
        MobileServiceClient client;
        IMobileServiceTable<Member> MemberTable;
        IEnumerable<Member> items;

        public CloudDataStore()
        {
            client = new MobileServiceClient(App.BackendUrl);
            MemberTable = client.GetTable<Member>();
            items = new List<Member>();
        }

        public async Task<IEnumerable<Member>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                items = await MemberTable.ToListAsync();
            }

            return items;
        }

        public async Task<Member> GetItemAsync(string id)
        {
            if (id != null && CrossConnectivity.Current.IsConnected)
            {
                return await MemberTable.LookupAsync(id);
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Member item)
        {
            if (item == null || !CrossConnectivity.Current.IsConnected)
                return false;
            item.CreatedOn = DateTime.Now;
            await MemberTable.InsertAsync(item);

            return !string.IsNullOrEmpty(item.Id);
        }

        public async Task<bool> UpdateItemAsync(Member item)
        {
            if (item == null || item.Id == null || !CrossConnectivity.Current.IsConnected)
                return false;
            try{
                await MemberTable.UpdateAsync(item);
            }catch{
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var item = await GetItemAsync(id);
            if (item == null) return false;
            try{
                await MemberTable.DeleteAsync(item);
            }
            catch{
                return false;
            }
            return true;
        }
    }
}
