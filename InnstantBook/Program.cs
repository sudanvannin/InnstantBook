using InnstantBook.Data;
using InnstantBook.Repositorios;
using InnstantBook.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InnstantBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<SistemaDeReservasDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

            builder.Services.AddScoped<IAvaliacaoRepositorio, AvaliacaoRepositorio>();
            builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            builder.Services.AddScoped<IHotelRepositorio, HotelRepositorio>();
            builder.Services.AddScoped<IQuartoRepositorio, QuartoRepositorio>();
            builder.Services.AddScoped<IReservaRepositorio, ReservaRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}