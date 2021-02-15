using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsCleanArchitectureSample.Api.Middleware
{
    public abstract class BaseMiddleware
    {
        private IActionResult _actionResult;

        public BaseMiddleware() { }

        public BaseMiddleware(BaseMiddleware next)
        {
            Next = next;
        }

        public BaseMiddleware Next { get; set; }

        public abstract Task InvokeAsync(HttpContext context);

        protected IActionResult ActionResult
        {
            get
            {
                return _actionResult;
            }

            set
            {
                _actionResult = value;
                OnResultChanged();
            }
        }

        public Action<IActionResult> ResultChangedHandler { get => resultChangedHandler; set => resultChangedHandler = value; }

        private Action<IActionResult> resultChangedHandler;

        private void OnResultChanged()
        {
            ResultChangedHandler?.Invoke(_actionResult);
        }
    }
}
