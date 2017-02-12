using System;
using System.Collections.Generic;

namespace HotDogsWeb.Models
{
    /// <summary>
    /// Represente une commande de hotdog
    /// </summary>
    public class HotDogOrder
    {
        public HotDogOrder()
        {
            HotDogs = new List<HotDog>();
            Status = HotDogOrderStatus.preparing;
            DateCreated = DateTime.Now;
        }

        /// <summary>
        /// id de la commande
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Magasin qui doit preparer la commande
        /// </summary>
        public HotDogStore Store { get; set; }

        /// <summary>
        /// liste des <see cref="HotDog"/> à preparer
        /// </summary>
        public virtual List<HotDog> HotDogs { get; set; }

        /// <summary>
        /// Client ayant commandé le HotDog
        /// </summary>
        public virtual HotDogUser Customer { get; set; }

        /// <summary>
        /// Statut de la commande
        /// </summary>
        public HotDogOrderStatus Status { get; set; }

        /// <summary>
        /// Date et heure de la commande
        /// </summary>
        public DateTime DateCreated { get; set; }
    }

    public enum HotDogOrderStatus
    {
        preparing = 0,
        Ready = 1,
        Finished = 2
    }
}