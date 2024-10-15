using Microsoft.EntityFrameworkCore;
using ProyectoAplicado.Components;
using ProyectoAplicado.DAL;
using ProyectoAplicado.Models;
using ProyectoAplicado.Services;

namespace ProyectoAplicado
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            //La Inyeccion del contexto
            var ConStr = builder.Configuration.GetConnectionString("ConStr");
            builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlite(ConStr));

            //La Inyeccion del services CocineroServices
            builder.Services.AddScoped<CocineroServices>();

            //La Inyeccion del services ComidaServices
            builder.Services.AddScoped<ComidaServices>();

            //La Inyeccion del services BebidasServices
            builder.Services.AddScoped<BebidasServices>();
            //La Inyeccion del services ComandaServices
            builder.Services.AddScoped<ComandaServices>();
            //La Inyeccion del services MesaServices
            builder.Services.AddScoped<MesaServices>();
            //La Inyeccion del services MeseraServices
            builder.Services.AddScoped <MeseraServices>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
