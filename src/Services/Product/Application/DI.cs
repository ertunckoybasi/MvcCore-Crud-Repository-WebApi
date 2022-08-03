using System.Reflection;
using Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ProductSrv.Application;
public static class DI
{
    public static IServiceCollection AddApplicationRegister(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return serviceCollection;
    }
}
