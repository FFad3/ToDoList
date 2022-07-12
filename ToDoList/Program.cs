global using ILogger = NLog.ILogger;
using Infrastrucutre;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using ToDoList.Configuration;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("Application start");

try
{
    var builder = WebApplication.CreateBuilder(args);

    //dbcontext
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        var conn = builder.Configuration.GetConnectionString("DefaultConnectionString");
        options.UseSqlServer(conn);
    });
    //installing all config
    ServicesInstaller.InstallServicesInAsseembly(builder);

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}