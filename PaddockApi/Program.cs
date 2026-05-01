using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using PaddockAPI.Infrastructure.Database;
using PaddockAPI.Infrastructure.Repositories;

namespace PaddockApi;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers();

		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo
			{
				Title = "PaddockAPI",
				Version = "v1"
			});
		});

		builder.Services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

		builder.Services.AddScoped<IConstructorRepository        , ConstructorRepository        >();
		builder.Services.AddScoped<IDriverRepository             , DriverRepository             >();
		builder.Services.AddScoped<ILocationRepository           , LocationRepository           >();
		builder.Services.AddScoped<IPointByPositionRepository    , PointByPositionRepository    >();
		builder.Services.AddScoped<IPositionRepository           , PositionRepository           >();
		builder.Services.AddScoped<IRaceRepository               , RaceRepository               >();
		builder.Services.AddScoped<ISeasonRepository             , SeasonRepository             >();
		builder.Services.AddScoped<IStandingConstructorRepository, StandingConstructorRepository>();
		builder.Services.AddScoped<IStandingDriverRepository     , StandingDriverRepository     >();
		builder.Services.AddScoped<ITrackRepository              , TrackRepository              >();

		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaddockAPI v1");
				c.RoutePrefix = string.Empty;
			});
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}