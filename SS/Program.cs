
using Microsoft.EntityFrameworkCore;
using SS.Generic;
using SS.Generic.Interfaces;
using SS.Generic.Repos;
using SS.Models;

namespace SS
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

            builder.Services.AddScoped(typeof(IGeneric<>), typeof(Generic<>));
            builder.Services.AddScoped<ICustomer,CustomerRepo>();
            builder.Services.AddScoped<IArtPiece,ArtpieceRepo>();
            builder.Services.AddScoped<ICategory,CategoryRepo>();
            builder.Services.AddScoped<ILoyaltyCard,LoyaltyCardRepo>();

            builder.Services.AddDbContext<AppDbContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));

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
