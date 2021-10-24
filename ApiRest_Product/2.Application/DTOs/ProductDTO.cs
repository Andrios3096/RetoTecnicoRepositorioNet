using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest_Product._2.Application.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string cProductName { get; set; }
        public decimal nPrice { get; set; }
        public int nStock { get; set; }
    }
}
