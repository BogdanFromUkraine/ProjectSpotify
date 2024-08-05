using Hangfire;
using Microsoft.EntityFrameworkCore;
using ProjectTrackingSpotify.DataAccess.Data;
using ProjectTrackingSpotify.DataAccess.Repository;
using ProjectTrackingSpotify.DataAccess.Repository.IRepository;
using ProjectTrackingSpotify.Services;
using ProjectTrackingSpotify.Services.GetUserIsTopItems;
using NetTopologySuite.Geometries;
using ProjectTrackingSpotify.Services.GetUserData;
using ProjectTrackingSpotify.Services.GetArtist;

namespace ProjectTrackingSpotify
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			//добавл€ю connection string 
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			//добавл€ю hangfire до проЇкту
			builder.Services.AddHangfire(h => 
			h.UseSqlServerStorage("Server=DESKTOP-AP74R5B;Database=ProjectTrackingSpotify;Trusted_Connection=True;TrustServerCertificate=True"));
			builder.Services.AddHangfireServer();

			


			builder.Services.AddHttpClient<ISpotifyAccountService, SpotifyAccountService>(c =>
			{
				


            });

            builder.Services.AddHttpClient<IGetUserIsTopItems, GetUserIsTopItems>(c =>
			{
				c.BaseAddress = new Uri("https://api.spotify.com/v1/");
				c.DefaultRequestHeaders.Add("Accept", "application/.json");
				});

			builder.Services.AddScoped<ITokenResultRepository, TokenResultRepository>(); //заЇстрував серв≥с, щоб можна було використовувати в homeController
			builder.Services.AddScoped<ITopItemsRepository, TopItemsRepository>();
			builder.Services.AddScoped<IUrlSpotifyRepository, UrlSpotifyRepository>();
			builder.Services.AddScoped<IGetUserData, GetUserData>();
			builder.Services.AddScoped<IGetArtist, GetArtist>();

			builder.Services.AddControllersWithViews();

            builder.Services.AddSession();

            //добавл€ю CORS

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("reactProject",
                    policy =>
                    {
						policy.WithOrigins("http://localhost:5173");
						policy.AllowAnyHeader();
						policy.AllowAnyMethod();
						policy.AllowCredentials();

                    });
            });


            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseSession();

            

            app.UseHttpsRedirection();

			app.UseStaticFiles();

			app.UseRouting();
            app.UseAuthorization();

			app.UseHangfireDashboard("/dashboard");

			

			app.MapControllerRoute(
				name: "default",
                pattern: "api/{controller=Home}/{action=AuthScreen}/{id?}");

			app.UseCors("reactProject");

            app.Run();
		}
	}
}
