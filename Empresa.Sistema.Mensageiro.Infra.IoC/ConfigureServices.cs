using AutoMapper;
using Empresa.Sistema.Cadastro.Application.Interface;
using Empresa.Sistema.Cadastro.Application.Servico;
using Empresa.Sistema.Cadastro.Domain.Interface.Services;
using Empresa.Sistema.Cadastro.Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Infra.IoC
{
    public class ConfigureService
    {
        //.AddTransient => Para cada operação que tiver uma injeção de dependência ele vai criar uma instância de User 
        //.AddScoped => Ele entrou na aplicação e em 10 requisições ele poderá reaproveitar a mensa instância (ciclo de vida)
        //.AddSingleton -> apartir do start da aplicação, ele não vai mudar (se o serviço for executar a nível de servidor uma única vez)
        public static void ConfigureDependenciesServices(IServiceCollection serviceCollection)
        {
            //Service Domain
            serviceCollection.AddTransient<IParametroSistemaService, ParametroSistemaService>();
            serviceCollection.AddTransient<IPostService, PostService>();

            //Service Application
            serviceCollection.AddTransient<IParametroSistemaApplication, ParametroSistemaServicoApplication>();
            serviceCollection.AddTransient<IPostApplication, PostApplication>();
        }
    }
}
