using AzureFunctionsCleanArchitectureSample.Api.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsCleanArchitectureSample.Api.Pipeline
{
    public class CreateItemPipelineFactory : BasePipelineFactory, IPipelineFactory
    {
        private List<BaseMiddleware> _middlewares;
        public CreateItemPipelineFactory(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor.HttpContext)
        {
            _middlewares = new List<BaseMiddleware>();
        }

        public async Task<IActionResult> Run(Func<HttpContext, Task<IActionResult>> func)
        {
            AddMiddleware(new FunctionMiddleware(func));

            await _middlewares.First().InvokeAsync(HttpContext);
            return _middlewares.Last(x => x.ActionResult != null).ActionResult;
        }

        public IPipelineFactory Use(BaseMiddleware middleware)
        {
            AddMiddleware(middleware);

            return this;
        }

        private void AddMiddleware(BaseMiddleware middleware)
        {
            if (_middlewares.Any())
            {
                _middlewares.Last().Next = middleware;
            }

            _middlewares.Add(middleware);
        }
    }
}