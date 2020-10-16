using App.Application.Interfaces;
using App.Domain.Models;
using App.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Services
{
    public class BookService : BaseService<Book>, IBookService
    {
        private readonly IBookRepository _BookRepository;

        public BookService(IBookRepository BookRepository) : base(BookRepository)
        {
            _BookRepository = BookRepository;
        }
    }
}
