using AzureFunctionsCleanArchitectureSample.Api.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzureFunctionsCleanArchitectureSample.Api.Handler
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, string>
    {
        public async Task<string> Handle(CreateItemCommand command, CancellationToken cancellationToken)
        {

            string name = command.Query;

            string requestBody = await new StreamReader(command.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return await Task.FromResult(responseMessage);
        }
    }
}