using System;
using System.ComponentModel.DataAnnotations;

namespace FinancialAPI.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
    }
}
