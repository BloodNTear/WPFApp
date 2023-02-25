using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Implement;
using Repository.Interface;
using Services.Implement;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAPP
{
    public class IOCProvider
    {
        private ServiceCollection _services;
        private ServiceProvider _provider;

        public ServiceProvider Provider { get => _provider;}
        public IOCProvider()
        {
            _services = new ServiceCollection();
            _services.AddDbContext<EStoreDBContext>();
            _services.AddAutoMapper(typeof(IOCProvider));

            _services.AddScoped<IUserRepository, UserRepository>();
            _services.AddScoped<IUserService, UserService>();

            _services.AddSingleton<LoginPage>();

            _provider = _services.BuildServiceProvider();
        }
    }
}
