using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCode_First.DataModel
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public int SupplierName { get; set;}
        public int? ContactNum { get; set; }
        public string? Email { get; set; }

        public List<ItemOrder>? ItemOrders { get; set; }
    }
}
