using DS.ClientControllSystem;
using DS.Domain.ClientControll;
using DS.Infrastructure.ClientControll.Repository.Interface;
using DS.Infrastructure.ClientControll.Repository;
using DS.Infrastructure.ClientControll.Validators;
using DS.Service.ClientControll.Interface;
using DS.Service.ClientControll;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using DS.Infrastructure.ClientControll.Repository.Config;

namespace IntegrationTest.DS.ClientControllSystem.Mocks
{
    public class StartupMock : Startup
    {
        public StartupMock(IConfiguration configuration) : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            // Service
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClientePessoaFisicaService, ClientePessoaFisicaService>();

            // Validator
            services.AddScoped<IValidator<User>, UserValidator>();
            services.AddScoped<IValidator<ClientePessoaFisica>, ClientePessoaFisicaValidator>();

            // Repository
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IClientePessoaFisicaRepository, ClientePessoaFisicaRepository>();
           // services.AddScoped<IUserRepository, UserRepository>();

            // Notifications
            services.AddScoped<NotificationContext>();

           /* services.AddDbContext<ApplicationDBContext>(options =>
            {
               // options.UseInMemoryDatabase("TestDatabase"); // Use a unique name for each test
            });*/

            services.AddAuthentication("teste").AddScheme<AuthenticationSchemeOptions,
                TestAuthHandler>("teste", options => { });
        }
    }
}
