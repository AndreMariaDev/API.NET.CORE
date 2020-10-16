using App.Domain.Models;
using App.Infra.Data.Context;
using App.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infra.Data.Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        #region Constructor
        public AuthorRepository(PostgreDbContext context) : base(context)
        {

        }
        #endregion
    }
}
