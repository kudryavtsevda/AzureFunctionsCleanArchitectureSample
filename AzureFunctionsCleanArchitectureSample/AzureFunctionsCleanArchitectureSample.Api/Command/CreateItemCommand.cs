using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsCleanArchitectureSample.Api.Command
{
    public class CreateItemCommand : IRequest<string>
    {
        public CreateItemCommand(string query, Stream body)
        {           
            Query = query;
            Body = body;
        }

        public string Query { get; }
        public Stream Body { get; }
    }
}
