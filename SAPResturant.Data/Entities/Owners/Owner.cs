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
using System.Threading.Tasks.Dataflow;
using System.Transactions;

namespace SAPResturant.Data.Entities.Owners
{
    public class Owner
    {
        #region Columns
        [Key]
        public int OwnerId { get; set; }

        [MaxLength(100)]
        public string OwnerName { get; set; }

        [MaxLength(20)]
        public string? OwnerPhoneNumber { get; set; }

        [MaxLength(100)]
        public string? OwnerEmail { get; set; }


        [MaxLength(100)]
        public string? OwnerUserName { get; set; }

        public DateTime OwnerRegisterDate { get; set; }

        public byte[]? OwnerPasswordHash { get; set; }

        public byte[]? OwnerPasswordSalt { get; set; }

        [MaxLength(30)]
        public string? OwnerEmailActiveCode { get; set; }

        [MaxLength(8)]
        public string? OwnerPhoneNumberActiveCode { get; set; }

        public DateTime? LastEmailActiveCodeSent { get; set; }

        public DateTime? LastPhoneNumberActiveCodeSent { get; set; }

        public Boolean IsEmailActive { get; set; }

        public Boolean IsPhoneNumberActive { get; set; }

        public bool IsOwnerActive { get; set; }
        #endregion



        #region Rel   
        public List<Resturant>? Resturants { get; set; }
        public List<OwnerTransaction>? Transactions { get; set; }
        public List<OwnerNotification>? OwnerNotifications { get; set; }
        public List<Ticket>? Tickets { get; set; }


        #endregion

    }
}
