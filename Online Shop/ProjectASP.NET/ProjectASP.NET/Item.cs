using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectASP.NET
{
    [MetadataType(typeof(ItemMetaData))]
    public partial class Item
    {
        public class ItemMetaData
        {
            [Required(ErrorMessage = "Item Title Required")]
            public object ItemTitle { get; set; }
            [Required(ErrorMessage = "Item Description Required")]
            public object ItemDescription { get; set; }
            [Required(ErrorMessage = "Price Required")]
            public double Price { get; set; }
            [Required(ErrorMessage = "Location Required")]
            public string Location { get; set; }

        }
    }
}