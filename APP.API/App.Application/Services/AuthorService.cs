using App.Application.Interfaces;
using App.Domain.Models;
using App.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Services
{
    public class AuthorService : BaseService<Author>, IAuthorService
    {
        private readonly IAuthorRepository _AuthorRepository;

        public AuthorService(IAuthorRepository AuthorRepository) : base(AuthorRepository)
        {
            _AuthorRepository = AuthorRepository;
        }
    }
}
