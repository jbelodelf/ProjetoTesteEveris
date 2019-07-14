using AutoMapper;
using JBD.ProjetoTesteEveris.Data.Repositories;
using JBD.ProjetoTesteEveris.Data.Repositories.Base;
using JBD.ProjetoTesteEveris.Application.Interfaces;
using JBD.ProjetoTesteEveris.Application.Repositories;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Repository;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Repository.Base;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Service;
using JBD.ProjetoTesteEveris.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using JBD.ProjetoTesteEveris.Data.Contexts;
using JBD.ProjetoTesteEveris.CrossCutting;
using Microsoft.EntityFrameworkCore;
using JBD.ProjetoTesteEveris.Domain.Services.Validar;
using JBD.ProjetoTesteEveris.Domain.Services.Processar;

namespace JBD.ProjetoTesteEveris.WebApiAdmin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper();

            //var connectionString = Configuration.GetConnectionString("DefaultConnection");

            //services.AddDbContext<DataBaseContext>(options =>
            //{
            //    options.UseSqlServer(connectionString);
            //});

            //--------------------------------------------------------------------------
            services.AddSingleton(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddScoped<IContaRepositoryApp, ContaRepositoryApp>();
            services.AddScoped<IContaTransacaoRepositoryApp, ContaTransacaoRepositoryApp>();
            services.AddScoped<IContaMovimentoHistoricoRepositoryApp, ContaMovimentoHistoricoRepositoryApp>();

            services.AddScoped<IContaRepositoryService, ContaRepositoryService>();
            services.AddScoped<IContaTransacaoRepositoryService, ContaTransacaoRepositoryService>();
            services.AddScoped<IContaMovimentoHistoricoRepositoryService, ContaMovimentoHistoricoRepositoryService>();

            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IContaTransacaoRepository, ContaTransacaoRepository>();
            services.AddScoped<IContaMovimentoHistoricoRepository, ContaMovimentoHistoricoRepository>();

            services.AddScoped<IMapperEntityAndDto, MapperEntityAndDto>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IValidarTransacaoService, ValidarTransacao>();
            services.AddScoped<IProcessamentoDeTransacaoService, ProcessamentoDeTransacao>();
            //--------------------------------------------------------------------------

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.Use(async (context, next) =>
            //{
            //    try
            //    {
            //        await next.Invoke();

            //        var unitOfWork = (IUnitOfWork)context.RequestServices.GetService(typeof(IUnitOfWork));
            //        await unitOfWork.Commit();
            //    }
            //    catch (System.Exception ex)
            //    {
            //        throw;
            //    }
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
