using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotDogsWeb.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace HotDogsWeb.Context
{
    public class HotDogRepository : IHotDogRepository
    {
        private HotDogContext _context;
        private ILogger<HotDogRepository> _logger;

        public HotDogRepository(HotDogContext context, ILogger<HotDogRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddStore(HotDogStore store)
        {
            _context.Add<HotDogStore>(store);
        }

        public IEnumerable<HotDogStore> GetAllStores()
        {
            return _context.Stores.ToList();
        }

        public IEnumerable<HotDogStore> GetStoresByUsername(string name)
        {
            return _context.Stores
                .Where(s => s.ManagerName == name)
                .ToList();
        }

        public HotDogStore GetStoreById(int storeId)
        {
            if (storeId <= 0)
                throw new ArgumentOutOfRangeException("StoreId doit être superieur à 0");

            return _context.Stores
                    .Where(s => s.Id == storeId)
                    .Include(s => s.HotDogs)
                    .FirstOrDefault();
        }

        public void AddHotDog(int storeId, HotDog newHotDog)
        {
            var store = GetStoreById(storeId);

            if (store != null)
            {
                newHotDog.HotDogStoreId = store.Id;
                store.HotDogs.Add(newHotDog);
            }
        }

        public IEnumerable<HotDog> GetHotDogsByStoreId(int storeId)
        {
            if (storeId <= 0)
                throw new ArgumentOutOfRangeException("StoreId doit être superieur à 0");

            return _context.HotDogs
                .Where(h => h.HotDogStoreId == storeId)
                .ToList();
        }

        public HotDog GetHotDogById(int hotdogId)
        {
            if (hotdogId <= 0)
                throw new ArgumentOutOfRangeException("HotDogId doit être superieur à 0");

            return (from h in _context.HotDogs
                    where h.Id == hotdogId
                    select h).SingleOrDefault();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
