using System;
using System.ComponentModel.DataAnnotations;
using DDD.Domain.Base;
using DDD.Domain.Interfaces;

namespace DDD.Domain.Entities
{
    public class Product : IEntity , IProduct
    {
        public Product(decimal price, string name, long code)
        {
            Price = price;
            Name = name;
            Code = code;
            CreationDate = DateTime.Now;
        }

        [Key]
        public long Id { get; set; }

        [Required]
        public decimal Price { get; private set; }

        [Required]
        public string Name { get; private set; }

        public long Code { get; private set; }

        public DateTime CreationDate { get; set; }

        public void UpdatePrice(decimal newPrice)
        {
            Price = newPrice;
        }
    }
}
