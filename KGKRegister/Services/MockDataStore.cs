using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KGKRegister
{
    public class MockDataStore : IDataStore<Member>
    {
        List<Member> items;

        public MockDataStore()
        {
            items = new List<Member>();
            var mockItems = new List<Member>
            {
                new Member { Id = Guid.NewGuid().ToString(), FirstName = "First item", LastName="This is an item description." },
                new Member { Id = Guid.NewGuid().ToString(), FirstName = "Second item", LastName="This is an item description." },
                new Member { Id = Guid.NewGuid().ToString(), FirstName = "Third item", LastName="This is an item description." },
                new Member { Id = Guid.NewGuid().ToString(), FirstName = "Fourth item", LastName="This is an item description." },
                new Member { Id = Guid.NewGuid().ToString(), FirstName = "Fifth item", LastName="This is an item description." },
                new Member { Id = Guid.NewGuid().ToString(), FirstName = "Sixth item", LastName="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Member item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Member item)
        {
            var _item = items.Where((Member arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Member arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Member> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Member>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
