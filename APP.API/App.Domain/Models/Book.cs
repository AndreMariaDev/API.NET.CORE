using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models
{
    public class Book: DomainEntity
    {
        public Book() 
        {
        }
        public Guid AuthorId { get; set; }

        public string Name { get; set; }

        public string ISBN { get; set; }

        public string Publisher { get; set; }

        public virtual Author Author { get; set; }

    }
}
