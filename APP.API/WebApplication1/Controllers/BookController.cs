using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Interfaces;
using App.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;

namespace Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : BaseController<Book>
    {
        private readonly IBookService appService;

        public BookController(IBookService appService) : base(appService)
        {
            this.appService = appService;
        }
    }
}
