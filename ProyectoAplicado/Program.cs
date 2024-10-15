using Microsoft.EntityFrameworkCore;
using ProyectoAplicado.Components;
using ProyectoAplicado.DAL;
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

            //La Inyeccion del services CocineroService
            builder.Services.AddScoped<CocineroServices>();

            //La Inyeccion del services ComidaService
            builder.Services.AddScoped<ComidaServices>();

            //La Inyeccion del services BebidasService
            builder.Services.AddScoped<BebidasServices>();

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
