using System.Collections.Generic;
using HotDogsWeb.Models;

namespace HotDogsWeb.Context
{
    public interface IHotDogsRepository
    {
        IEnumerable<Store> GetAllStores();
    }
}