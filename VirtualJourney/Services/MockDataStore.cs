using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualJourney.Models;

namespace VirtualJourney.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Moodle", Description="This is Moodle item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "SISU", Description="This is SISU description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "News ", Description="This is News description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Study Space", Description="This is Study Space description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Course Information", Description="This is Course Information description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Events", Description="This is Events description." }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}