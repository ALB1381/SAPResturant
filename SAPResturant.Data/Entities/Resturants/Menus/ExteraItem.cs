using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities.Resturants.Menus
{
    public class ExteraItem
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string ExteraOnItemTitle { get; set; }

        public int Price { get; set; }

        public List<ItemExteraConnection>? ItemExteraConnections { get; set; }



        public int MenuId { get; set; }

        [ForeignKey("MenuId")]
        public Menu Menu { get; set; }
    }
}
