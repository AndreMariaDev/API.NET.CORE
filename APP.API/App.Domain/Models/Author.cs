using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models
{
    public class Author: DomainEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
