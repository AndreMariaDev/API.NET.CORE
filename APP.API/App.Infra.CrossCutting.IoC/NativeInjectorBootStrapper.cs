using App.Application.Interfaces;
using App.Application.Services;
using App.Infra.Data.Interfaces;
using App.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Repository
            //services.AddScoped(typeof(IRepository<>), typeof(PostgreSQLRepository<>));
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            #endregion

            #region Services
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            #endregion
        }
    }
}
