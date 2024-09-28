using Serilog;
using System;

Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/KKNDotNetCore.ConsoleAppLogging.txt", rollingInterval: RollingInterval.Hour)
            .CreateLogger();

Log.Information("Hello, world! , Info Log");

int a = 10, b = 0;
try
{
    Log.Debug("Dividing {A} by {B}", a, b);
    Console.WriteLine(a / b);
}
catch (Exception ex)
{
    Log.Error(ex, "Something went wrong");
    Console.ReadKey();
}
finally
{
    await Log.CloseAndFlushAsync();
}
