using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService (IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>(); //Transient -> Cria uma nova instância para cada chamada do Serviço. | Scoped -> Usa uma mesma instância para todas as chamadas 
            serviceCollection.AddTransient<ILoginService, LoginService>();
        }
    }
}
