using HotDogsWeb.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDogsWeb.Context
{
    public class HotDogsRepository : IHotDogsRepository
    {
        private HotDogContext _context;
        private ILogger<HotDogsRepository> _logger;

        public HotDogsRepository(HotDogContext context, ILogger<HotDogsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Store> GetAllStores ()
        {
            _logger.LogInformation("Getting All Stores from the database");

            return _context.Stores.ToList();
        }
    }
}
