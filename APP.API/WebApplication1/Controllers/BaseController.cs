using App.Application.Interfaces;
using App.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class BaseController<T> : ControllerBase where T : class
    {
        #region Properts
        private readonly IBaseService<T> _service;
        #endregion

        #region Constructor
        public BaseController(IBaseService<T> service)
        {
            _service = service;
        }
        #endregion

        #region Actions
        [HttpGet]
        public virtual async Task<IActionResult> GetAll(int _offset = 1, int _limit = 10)
        {
            return await TryExecuteAction(async () =>
            {
                if (_offset > _limit)
                    return StatusCode((int)HttpStatusCode.PreconditionFailed, "Bad Request!");

                var result = await _service.GetAllAsyncMultipleIncludes();

                var skip = (_offset - 1) * _limit;

                var list = result.Skip(skip).Take(_limit);

                if (null == result)
                {
                    return StatusCode((int)HttpStatusCode.NotFound);
                }

                return StatusCode((int)HttpStatusCode.OK, list);

            });
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await _service.GetByIdAsync(id);

                if (null == result)
                {
                    return StatusCode((int)HttpStatusCode.NotFound);
                }
                return StatusCode((int)HttpStatusCode.OK, result);
            });
        }

        [HttpPost]
        public virtual async Task<IActionResult> Insert([FromBody] T register)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await _service.Create(register);

                return StatusCode((int)HttpStatusCode.Created, result);

            });
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(Guid id, [FromBody] T register)
        {
            return await TryExecuteAction(async () =>
            {
                var result = await _service.Update(register);

                return StatusCode((int)HttpStatusCode.Created, result);

            });
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteById(Guid id)
        {
            return await TryExecuteAction(async () =>
            {
                var entity = await _service.GetByIdAsync(id);
                _service.Delete(entity);

                return StatusCode((int)HttpStatusCode.OK, true);
            });
        }
        #endregion

        #region Methods
        protected string GetClaim(string type)
        {
            if (Request == null)
                return string.Empty;

            return Request.HttpContext.User?.Claims?.FirstOrDefault(c => c.Type == type)?.Value;
        }
        //protected virtual void SetPagedHeader<TResult>(Domain.Models.PagedResult<TResult> pagedResult)
        //{
        //    Request.HttpContext.Response.Headers.Add("_offset", pagedResult.Offset.ToString());
        //    Request.HttpContext.Response.Headers.Add("_limit", pagedResult.Limit.ToString());
        //    Request.HttpContext.Response.Headers.Add("_total", pagedResult.Total.ToString());
        //}

        protected async Task<IActionResult> TryExecuteAction(Func<Task<IActionResult>> myMetho)
        {
            try
            {
                return await myMetho();
            }
            catch (BadRequestException ex)
            {
                return LogBadRequest(ex);
            }
            catch (Exception ex)
            {
                return LogExeption(ex);
            }
        }

        private IActionResult LogBadRequest(BadRequestException ex)
        {
            return StatusCode((int)HttpStatusCode.PreconditionFailed, $"Bad Request! : {ex.Message}");
        }

        private IActionResult LogExeption(Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, $"Erro interno! : {ex.Message}");
        }
        #endregion

    }
}
