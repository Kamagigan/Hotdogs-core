using HotDogsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDogsWeb.Context
{
    public interface IHotDogRepository
    {
        void AddStore(HotDogStore store);

        IEnumerable<HotDogStore> GetAllStores();

        HotDogStore GetStoreById(int storeId);

        void AddHotDog(int storeId, HotDog newHotDog);

        HotDog GetHotDogById(int hotdogId);

        IEnumerable<HotDog> GetHotDogsByStoreId(int storeId);

        Task<bool> SaveChangesAsync();

    }
}
