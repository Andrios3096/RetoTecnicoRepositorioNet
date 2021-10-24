using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest_Product._3.Persistence
{
    public class ProductDOM
    {
        public Guid Id { get; set; }
        public string cProductName { get; set; }
        public decimal nPrice { get; set; }
        public int nStock { get; set; }
        public DateTime dRegistrationDate { get; set; }
    }
}
