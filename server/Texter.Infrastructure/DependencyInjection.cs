using Microsoft.Extensions.DependencyInjection;
using Texter.App.Services;
using Texter.Infrastructure.Services;

namespace Texter.Infrastructure;

public static class DependencyInjection{

    public static IServiceCollection AddDomainServices(this IServiceCollection services){
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }    
}