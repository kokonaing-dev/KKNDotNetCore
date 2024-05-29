// See https://aka.ms/new-console-template for more information
using KKNDotNetCore.ConsoleAppRefitExamples;

Console.WriteLine("Hello, World!");

//try
//{
//    RefitExample refitExample = new RefitExample();
//    await refitExample.RunAsync();
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.ToString());
//}

RefitExample refitExample = new RefitExample();
await refitExample.RunAsync();