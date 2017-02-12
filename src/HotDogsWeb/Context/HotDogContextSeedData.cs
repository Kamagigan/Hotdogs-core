using HotDogsWeb.Models;
using Microsoft.AspNetCore.Identity;
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
        private UserManager<HotDogUser> _userManager;

        public HotDogContextSeedData(HotDogContext context, UserManager<HotDogUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task SeedSampleData()
        {
            if (await _userManager.FindByEmailAsync("lcudini@klanik.com") == null)
            {
                var user = new HotDogUser("lcudini")
                {
                    Email = "lcudini@klanik.com"
                };

                await _userManager.CreateAsync(user, "Qbgtph88!");
            }

            if (await _userManager.FindByEmailAsync("dkadaboom@klanik.com") == null)
            {
                var user = new HotDogUser("dkadaboom")
                {
                    Email = "dkadaboom@klanik.com"
                };

                await _userManager.CreateAsync(user, "Qbgtph88!");
            }

            if (!_context.Stores.Any())
            {
                var tommys = new HotDogStore()
                {
                    Name = "Tommy's Dinner",
                    Location = "Avignon",
                    ManagerName = "lcudini", // TODO Add UserName
                    Latitude = 43.9786091,
                    Longitude = 4.8712175,
                };

                _context.Stores.Add(tommys);

                var hotdogfather = new HotDogStore()
                {
                    Name = "The Hot Dog Father",
                    Location = "Lyon",
                    ManagerName = "lcudini", // TODO Add UserName
                    Latitude = 45.7634609,
                    Longitude = 4.8427191,
                };

                _context.Stores.Add(hotdogfather);

                var emilys = new HotDogStore()
                {
                    Name = "Emily's American Diner",
                    Location = "Grenoble",
                    ManagerName = "dkadaboom", // TODO Add UserName
                    Latitude = 45.1921764,
                    Longitude = 5.7304209,
                };

                _context.Stores.Add(emilys);

                await _context.SaveChangesAsync();

                tommys.HotDogs = new List<HotDog>()
                {
                    new HotDog () {
                        Name = "The Classic",
                        Description = "Avec Pain, Saucisse Jumbo et Moutarde",
                        Available =true,
                        DateCreated = new DateTime(2016, 11, 19),
                        PrepTime =10,
                        Price =8,
                        HotDogStoreId = tommys.Id
                    },
                    new HotDog()
                    {
                        Name = "Chili Hot Dog",
                        Description = "Avec Pain, Saucisse, Chili Con Carne et Fromage",
                        Available = true,
                        PrepTime= 15,
                        Price = 10,
                        HotDogStoreId = tommys.Id
                    },
                    new HotDog()
                    {
                        Name = "Pastrami'n Hot Dog",
                        Description = "Avec Pain, Saucisse, Pastrami et Fromage",
                        Available = true,
                        PrepTime= 15,
                        Price = 10,
                        HotDogStoreId = tommys.Id
                    }
                };
 
                _context.HotDogs.AddRange(tommys.HotDogs);

                hotdogfather.HotDogs = new List<HotDog>()
                {
                    new HotDog()
                    {
                        Name = "The Original",
                        Description = "Avec Pain, Saucisse et Moutarde US",
                        Available = true,
                        PrepTime= 10,
                        Price = 8,
                        HotDogStoreId = hotdogfather.Id
                    },
                    new HotDog()
                    {
                        Name = "BBQ Dog",
                        Description = "Avec Pain, Saucisse, Sauce BBQ, Oigons Frits",
                        Available = true,
                        PrepTime= 12,
                        Price = 8,
                        HotDogStoreId = hotdogfather.Id
                    },
                    new HotDog()
                    {
                        Name = "Spicy Dog",
                        Description = "Avec Pain, Saucisse, Sauce Cheddar, Hot Sauce, Jalapeno",
                        Available = true,
                        PrepTime= 15,
                        Price = 8,
                        HotDogStoreId = hotdogfather.Id
                    }
                };

                _context.HotDogs.AddRange(hotdogfather.HotDogs);

                emilys.HotDogs = new List<HotDog>()
                    {
                        new HotDog()
                        {
                            Name = "Classic Hot Dog",
                            Description = "Avec Pain, Saucisse, Ketchup & Moutarde au miel",
                            Available = true,
                            PrepTime= 10,
                            Price = 8,
                            HotDogStoreId = emilys.Id
                        },
                        new HotDog()
                        {
                            Name = "Manhattan Hot Dog",
                            Description = "Avec Pain, Saucisse, Bacon, Chedar sauce, Ketchup & Moutarde au miel ",
                            Available = true,
                            PrepTime= 12,
                            Price = 11,
                            HotDogStoreId = emilys.Id
                        },
                        new HotDog()
                        {
                            Name = "Hot Dog Park",
                            Description = "Avec Pain, Saucisse, champignons Sauce Cheddar, Ketchup & Moutarde au miel",
                            Available = true,
                            PrepTime= 10,
                            Price = 11,
                            HotDogStoreId = emilys.Id
                        }
                    };

                _context.HotDogs.AddRange(emilys.HotDogs);

                await _context.SaveChangesAsync();
            }
        }
    }
}
