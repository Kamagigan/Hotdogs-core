using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDogsWeb.Models
{
    public class HotDog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public int Price { get; set; }
        public bool Available { get; set; }
        public DateTime DateCreated { get; set; }
        public int PrepTime { get; set; }


        //public string Description { get; set; }
        //public string ImagePath { get; set; }
        //public bool IsFavorite { get; set; }
        //public string GroupName { get; set; }
    }
}
