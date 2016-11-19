using HotDogsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDogsWeb.Context
{
    public class HotDogContextSeedData
    {
        private HotDogContext _context;

        public HotDogContextSeedData(HotDogContext context)
        {
            _context = context;
        }

        public async Task SeedSampleData()
        {
            if (!_context.Stores.Any())
            {
                var tommys = new Store()
                {
                    Name = "Tommy's Dinner",
                    Location = "Avignon",
                    ManagerName = "", // TODO Add UserName
                    Latitude = 43.9786091,
                    Longitude = 4.8712175,
                    HotDogs = new List<HotDog>()
                    {
                        new HotDog () {
                            Name = "The Classic",
                            ShortDescription = "Avec Pain, Saucisse Jumbo et Moutarde",
                            Available =true,
                            DateCreated = new DateTime(2016, 11, 19),
                            PrepTime =10,
                            Price =8
                        },
                        new HotDog()
                        {
                            Name = "Chili Hot Dog",
                            ShortDescription = "Avec Pain, Saucisse, Chili Con Carne et Fromage",
                            Available = true,
                            PrepTime= 15,
                            Price = 10,
                        },
                        new HotDog()
                        {
                            Name = "Pastrami'n Hot Dog",
                            ShortDescription = "Avec Pain, Saucisse, Pastrami et Fromage",
                            Available = true,
                            PrepTime= 15,
                            Price = 10,
                        }
                    }
                };

                _context.Stores.Add(tommys);
                _context.HotDogs.AddRange(tommys.HotDogs);

                var hotdogfather = new Store()
                {
                    Name = "The Hot Dog Father",
                    Location = "Lyon",
                    ManagerName = "", // TODO Add UserName
                    Latitude = 45.7634609,
                    Longitude = 4.8427191,
                    HotDogs = new List<HotDog>()
                    {
                        new HotDog()
                        {
                            Name = "The Original",
                            ShortDescription = "Avec Pain, Saucisse et Moutarde US",
                            Available = true,
                            PrepTime= 10,
                            Price = 8,
                        },
                        new HotDog()
                        {
                            Name = "BBQ Dog",
                            ShortDescription = "Avec Pain, Saucisse, Sauce BBQ, Oigons Frits",
                            Available = true,
                            PrepTime= 12,
                            Price = 8,
                        },
                        new HotDog()
                        {
                            Name = "Spicy Dog",
                            ShortDescription = "Avec Pain, Saucisse, Sauce Cheddar, Hot Sauce, Jalapeno",
                            Available = true,
                            PrepTime= 15,
                            Price = 8,
                        }
                    }
                };

                _context.Stores.Add(hotdogfather);
                _context.HotDogs.AddRange(hotdogfather.HotDogs);

                var emilys = new Store()
                {
                    Name = "Emily's American Diner",
                    Location = "Grenoble",
                    ManagerName = "", // TODO Add UserName
                    Latitude = 45.1921764,
                    Longitude = 5.7304209,
                    HotDogs = new List<HotDog>()
                    {
                        new HotDog()
                        {
                            Name = "Classic Hot Dog",
                            ShortDescription = "Avec Pain, Saucisse, Ketchup & Moutarde au miel",
                            Available = true,
                            PrepTime= 10,
                            Price = 8,
                        },
                        new HotDog()
                        {
                            Name = "Manhattan Hot Dog",
                            ShortDescription = "Avec Pain, Saucisse, Bacon, Chedar sauce, Ketchup & Moutarde au miel ",
                            Available = true,
                            PrepTime= 12,
                            Price = 11,
                        },
                        new HotDog()
                        {
                            Name = "Hot Dog Park",
                            ShortDescription = "Avec Pain, Saucisse, champignons Sauce Cheddar, Ketchup & Moutarde au miel",
                            Available = true,
                            PrepTime= 10,
                            Price = 11,

                        }
                    }
                };

                _context.Stores.Add(emilys);
                _context.HotDogs.AddRange(emilys.HotDogs);

                await _context.SaveChangesAsync();
            }
        }
    }
}
