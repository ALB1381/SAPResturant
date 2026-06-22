using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Inner.Data.Entities.Menus
{
    public class ItemUnit
    {
        [Key]
        public int ItemUnitId { get; set; }

        [MaxLength(30)]
        public string UnitName { get; set; }

        public List<Item> Items { get; set; }
    }
}
