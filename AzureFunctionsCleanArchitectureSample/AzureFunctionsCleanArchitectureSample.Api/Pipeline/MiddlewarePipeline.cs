﻿using AzureFunctionsCleanArchitectureSample.Api.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsCleanArchitectureSample.Api.Pipeline
{
    public class MiddlewarePipeline : BaseMiddlewarePipeline, IPipeline
    {
        private List<BaseMiddleware> _middlewares;
        private IActionResult _result;

        public MiddlewarePipeline(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor.HttpContext)
        {
            _middlewares = new List<BaseMiddleware>();
        }

        public async Task<IActionResult> RunAsync(Func<HttpContext, Task<IActionResult>> func)
        {
            AddMiddleware(new FunctionMiddleware(func));

            await _middlewares.First().InvokeAsync(HttpContext);

            return _result;
        }

        public IPipeline Use(BaseMiddleware middleware)
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

            middleware.ResultCreated += GetCurrentResult;
        }

        private void GetCurrentResult(object sender, IActionResult e)
        {
            _result = e;
        }
    }
}