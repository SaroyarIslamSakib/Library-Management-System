using LMS.Infrastructure.Data;
using LMS.Infrastructure.Extensions;
using LMS.Worker;
using Serilog;
using System.Reflection;

//----Create Configuration Object-----
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
    .AddEnvironmentVariables()
    .Build();
//----Serilog Configuration-----
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();
try
{
    var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    var migrationAssembly = Assembly.GetAssembly(typeof(ApplicationDbContext));

    Log.Information("Application Starting...");

    IHost host = Host.CreateDefaultBuilder(args)
        .UseWindowsService()
        // Open if configure autofac (After installing nuget package)
        //.UseServiceProviderFactory(new AutofacServiceProviderFactory())
        //.ConfigureContainer<ContainerBuilder>(builder =>
        //{
        //    builder.RegisterModule(new WorkerModule(connectionString, migrationAssemblyName));
        //})
        .UseSerilog()
        .ConfigureServices(services =>
        {
            services.AddHostedService<Worker>();
            services.AddDependencyInjection();
            services.AddDbContext(connectionString, migrationAssembly);
        })
        .Build();

    await host.RunAsync();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application Crushed");
}
finally
{
    Log.CloseAndFlush();
}