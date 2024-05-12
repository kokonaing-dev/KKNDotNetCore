using KKNDotNetCore.ConsoleAppHttpClientExamples;

// Console App - Client (Frontend)
// ASP.NET Core Web API - Server  (Backend)

Console.WriteLine("Hello, World!");

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.RunAsync();

Console.ReadLine();
