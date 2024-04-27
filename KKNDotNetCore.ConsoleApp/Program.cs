using KKNDotNetCore.ConsoleApp.AdoDotNetExamples;
using KKNDotNetCore.ConsoleApp.DapperExamples;


#region AdoDotNet
//Console.WriteLine("CRUD With AdoDotNet");
//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

//adoDotNetExample.Read();
//adoDotNetExample.Create("demo title", "demo author", "demo content");
//adoDotNetExample.Update(9, "demo update", "demo update", "updating in progress");
//adoDotNetExample.Delete(11);
//adoDotNetExample.Edit(2);
//adoDotNetExample.Edit(7);
#endregion

#region Dapper
DapperExample dapperExample = new DapperExample();
dapperExample.Run();
#endregion

Console.ReadKey();
