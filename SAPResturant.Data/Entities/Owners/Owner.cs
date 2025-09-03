using SAPResturant.Data.Entities.Owners.Tickets;
using SAPResturant.Data.Entities.Resturants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SAPResturant.Data.Entities.Owners
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }

        [MaxLength(100)]
        public string OwnerName { get; set; }

        [MaxLength(20)]
        public string? OwnerPhoneNumber { get; set; }

        [MaxLength(100)]
        public string? OwnerEmail { get; set; }

        [Required]
        [MaxLength(100)]
        public string OwnerUserName { get; set; }

        public DateTime OwnerRegisterDate { get; set; }

        [Required]
        public byte[] OwnerPasswordHash { get; set; }

        [Required]
        public byte[] OwnerPasswordSalt { get; set; }

        public bool IsOwnerActive { get; set; }

        // An Owner can have multiple Restaurants and a restaurant can have multiple Sections
        public List<Resturant>? Resturants { get; set; }

        public List<OwnerTransaction>? Transactions { get; set; }

        public List<OwnerNotification>? OwnerNotifications { get; set; }
        public List<Ticket>? Tickets { get; set; }

    }
}
