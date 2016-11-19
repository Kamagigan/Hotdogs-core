using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDogsWeb.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ManagerName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<HotDog> HotDogs { get; set; }
    }
}
