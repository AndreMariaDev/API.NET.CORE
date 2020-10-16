using App.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infra.Data.Interfaces
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
    }
}
