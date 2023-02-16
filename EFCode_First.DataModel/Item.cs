using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCode_First.DataModel
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Stock { get; set; }

        public List<CustomerOrder>? CustomerOrders { get; set; }
        public List<ItemOrder>? ItemOrders { get; set; }
    }
}
