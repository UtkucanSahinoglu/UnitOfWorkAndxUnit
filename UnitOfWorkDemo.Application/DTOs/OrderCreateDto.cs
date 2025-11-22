using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkAndxUnit.Application.DTOs
{
    public class OrderCreateDto
    {
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public List<int> ProductIds { get; set; } = new();
    }
}
