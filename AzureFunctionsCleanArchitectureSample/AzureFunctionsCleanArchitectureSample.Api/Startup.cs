using MediatR;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

[assembly: FunctionsStartup(typeof(AzureFunctionsCleanArchitectureSample.Api.Startup))]
namespace AzureFunctionsCleanArchitectureSample.Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
