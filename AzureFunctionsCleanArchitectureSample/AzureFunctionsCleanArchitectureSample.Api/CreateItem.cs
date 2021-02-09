using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MediatR;
using AzureFunctionsCleanArchitectureSample.Api.Command;
using AzureFunctionsCleanArchitectureSample.Api.Middleware;
using AzureFunctionsCleanArchitectureSample.Api.Pipeline;

namespace AzureFunctionsCleanArchitectureSample.Api
{
    public class ApiService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPipelineFactory _pipeline;

        public ApiService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IPipelineFactory pipeline)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _pipeline = pipeline;
        }
        [FunctionName("CreateItem")]
        public async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ExecutionContext context,
            ILogger log)
        {
            /*log.LogInformation("C# HTTP trigger function processed a request.");
            ActionResult result = new OkObjectResult("empty");
            
            var middleware = new ExceptionHandlerMiddleware(new FunctionMiddleware(async (ctx) =>
            {
                
                var res = await _mediator.Send(new CreateItemCommand(ctx.Request.Query["name"], ctx.Request.Body));

                return await Task.FromResult(new OkObjectResult(res));


            }));
            await middleware.InvokeAsync(_httpContextAccessor.HttpContext);   */

            return await _pipeline
                            .Use(new ExceptionHandlerMiddleware())
                          .Run(async ctx => new OkObjectResult(await _mediator.Send(new CreateItemCommand(ctx.Request.Query["name"], ctx.Request.Body))));
        }

        [FunctionName("UpdateItem")]
        public async Task<IActionResult> Update(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {


            log.LogInformation("C# HTTP trigger function processed a request.");
            string name = string.Empty;
            try
            {
                name = req.Query["name"];

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                name = name ?? data?.name;
            }
            catch (Exception ex)
            {

            }
            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("DeleteItem")]
        public async Task<IActionResult> Delete(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("GetItemById")]
        public async Task<IActionResult> GetById(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("GetAllItems")]
        public async Task<IActionResult> GetAll(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
