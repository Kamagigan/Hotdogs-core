using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotDogsWeb.Models;
using Microsoft.Extensions.Configuration;

namespace HotDogsWeb.Context
{
    public class HotDogContext : DbContext
    {
        private IConfigurationRoot _config;

        public HotDogContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            _config = config;
        }

        public DbSet<HotDogStore> Stores { get; set; }
        public DbSet<HotDog> HotDogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySql(_config["ConnectionStrings:HotDogContextConnection"]);
        }
    }
}
