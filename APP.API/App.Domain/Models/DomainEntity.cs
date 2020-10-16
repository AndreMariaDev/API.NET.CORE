using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models
{
    public abstract class DomainEntity
    {
        public Guid Id { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? DateUpdate { get; set; }

        public String UserCode { get; set; }
    }
}
