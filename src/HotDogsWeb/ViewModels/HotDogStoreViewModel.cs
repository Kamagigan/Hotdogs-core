using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotDogsWeb.ViewModels
{
    public class HotDogStoreViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Location { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string ManagerName { get; set; }
    }
}
