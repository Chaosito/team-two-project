namespace KartowkaMarkowkaHub.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var startup = new Startup(builder.Configuration);

            // Add services to the container.
            //builder.Services.AddControllersWithViews();
            startup.DependencyInjectionRegistration(builder.Services); 
            //startup.ConfigureServices(builder.Services);

            var app = builder.Build();

            startup.Configure(app, app.Environment, app.Services);

            #region Первичный вариант без Startup
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion

            app.Run();
        }
    }
}
