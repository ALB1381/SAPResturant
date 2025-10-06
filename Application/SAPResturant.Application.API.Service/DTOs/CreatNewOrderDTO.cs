using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Application.API.Service.DTOs
{
    public class CreatNewOrderDTO
    {
        public List<ShortItemInformation> ShortItemInformation { get; set; }
        public List<ShortGroupInformation> ShortGroupInformation { get; set; }
        public List<TableLittleInfo> TableLittleInfos { get; set; }
    }
    public class ShortItemInformation
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string? ItemImage { get; set; }
        public List<ShortItemOption>? ItemOptions { get; set; }
        public List<ShortExtraOnItem>? ShortExtraOnItems { get; set; }
        public int? Price { get; set; }
        public ShortGroupInformation ShortGroupInformation { get; set; }

    }
    public class ShortGroupInformation
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string? GroupColor { get; set; }


    }
    public class ShortItemOption
    {
        public int OptionId { get; set; }
        public string OptionTitle { get; set; }
        public int OptionPrice { get; set; }
    }
    public class ShortExtraOnItem
    {
        public int ExtraOnItemId { get; set; }
        public string ExtraOnItemName { get; set; }
        public int? ExtraOnItemPrice { get; set; }
    }
}
