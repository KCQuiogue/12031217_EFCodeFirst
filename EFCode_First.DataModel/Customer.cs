using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCode_First.DataModel
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public int? ContactNum { get; set; }
        public string? Email { get; set; }

        public List<CustomerOrder>? CustomerOrders { get; set; }
    }
}
