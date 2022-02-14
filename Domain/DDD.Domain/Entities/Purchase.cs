using DDD.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDD.Domain.Entities
{
    public class Purchase : IEntity
    {
        public Purchase(DateTime buyDate, decimal value)
        {
            BuyDate = buyDate;
            Value = value;
            Products = new List<Product>();
        }

        [Key]
        public long Id { get; set; }

        [Required]
        public decimal Value { get; private set; }

        [Required]
        public long ProductId { get; private set; }

        [Required]
        public IEnumerable<Product> Products { get; set; }

        [Required]
        public long AccountId { get; set; }

        [Required]
        public Account Account { get; set; }

        [Required]
        public DateTime BuyDate { get; private set; }

        public DateTime CreationDate { get; set; }
    }
}