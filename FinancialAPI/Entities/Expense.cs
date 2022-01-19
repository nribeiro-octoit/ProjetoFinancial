using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAPI.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
    }
}
