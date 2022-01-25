using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAPI.Entities
{
    public class Income
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        [ForeignKey("IdCategory")]
        public Category Category { get; set; }
    }
}
