using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCode_First.DataModel
{
    public class ItemOrder
    {
        public int Id { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public int Quantity { get; set; }
        public DateTime OrderDate { get; set;}
    }
}
