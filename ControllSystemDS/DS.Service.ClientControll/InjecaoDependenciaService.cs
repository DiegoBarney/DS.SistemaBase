using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using DS.Infrastructure.ClientControll.Repository.Interface;
using DS.Infrastructure.ClientControll.Repository;
using DS.Infrastructure.ClientControll.Validators;
using DS.Service.ClientControll.Interface;
using DS.Domain.ClientControll;

namespace DS.Service.ClientControll
{
    public class InjecaoDependenciaService
    {
        public static void Configure(IServiceCollection services)
        {
            // Service
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClientePessoaFisicaService, ClientePessoaFisicaService>();

            // Validator
            services.AddScoped<IValidator<User>, UserValidator>();
            services.AddScoped<IValidator<ClientePessoaFisica>, ClientePessoaFisicaValidator>();

            // Repository
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IClientePessoaFisicaRepository, ClientePessoaFisicaRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Notifications
            services.AddScoped<NotificationContext>();
        }
    }
}
