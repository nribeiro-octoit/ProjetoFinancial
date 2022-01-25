﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialAPI.Entities
{
    public class Expense
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
