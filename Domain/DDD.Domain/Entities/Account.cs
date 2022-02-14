using DDD.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace DDD.Domain.Entities
{
    public class Account : IEntity
    {
        public Account(decimal balance, string holderCPF)
        {
            Balance = balance;
            HolderCPF = holderCPF;
        }

        [Key]
        public long Id { get; set; }

        [Required]
        public decimal Balance { get; private set; }

        [Required]
        public string HolderCPF { get; set; }

        public DateTime CreationDate { get ; set ; }


    }
}