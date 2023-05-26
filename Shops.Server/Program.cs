
using Microsoft.EntityFrameworkCore;
using Shops.DataAccess;
using Shops.InitData;
using Shops.InitData.Configs;
using Shops.Server.Interfaces;
using Shops.Server.Mapper;
using Shops.Server.Services;
using System.Reflection;

namespace Shops.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var initDataSection = builder.Configuration.GetSection(InitDataConfig.KeyElement);
            builder.Services.Configure<InitDataConfig>(initDataSection);

            builder.Services.AddScoped<IShopService, ShopService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICountryService, CountryService>();
            builder.Services.AddScoped<FillerData>();

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connection, b => b.MigrationsAssembly("Shops.Server")));

            builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen( options =>
            {
                var xmlFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                options.IncludeXmlComments(xmlFilePath);
            });

            var app = builder.Build();

            using (var serviceScope = ((IApplicationBuilder)app).ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope())
            {
                if (serviceScope != null)
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
                    context.Database.Migrate();
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors();
            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}