using App.Domain.Models;
using App.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Interfaces
{
    public interface IBookService : IBaseService<Book>
    {
    }
}
