using Reflection.Logic;
using Reflection.Sample;
using Reflection.Utils;

Console.WriteLine("Press any key to start Stopwatch with REFLECTION...");
Console.ReadLine();

var fobj = new F() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };

#region CSV serialization
Console.WriteLine("1.Start CSV serialization");

string csvString = string.Empty;

Stopwatch.Start();
for (var i = 0; i < 1000; i++)
{
    csvString = CsvConvert.SerializeObject<F>(fobj);
}
Stopwatch.Stop();

var serdur = Stopwatch.Duration;

Stopwatch.Start();
Console.WriteLine($"[2.Stop] CSV serialization. The duration is : {serdur}");
Console.WriteLine($"[2.CSV] string : \n{csvString}");
Stopwatch.Stop();
Console.WriteLine($"[2.FINISH] The duration of console writeline is : {Stopwatch.Duration}");

Stopwatch.Start();
var obj = CsvConvert.DeserializeObject<F>(csvString);
Stopwatch.Stop();

Console.WriteLine($"[3.Convert] CSV to object: {obj}. The duration is : {Stopwatch.Duration}");
#endregion


//--=========================================================================================--

#region JSON serialization
Console.WriteLine("--------------------");

Console.WriteLine("[2.Start] JSON serialization");

string jsonString = string.Empty;

Stopwatch.Start();
for (var i = 0; i < 1000; i++)
{
    jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(fobj);
}
Stopwatch.Stop();

serdur = Stopwatch.Duration;

Stopwatch.Start();
Console.WriteLine($"[2.Stop] JSON serialization. The duration is : {serdur}");
Console.WriteLine($"[2.JSON] string : \n{jsonString}");
Stopwatch.Stop();
Console.WriteLine($"[2.FINISH] The duration of console writeline is : {Stopwatch.Duration}");

Stopwatch.Start();
obj = Newtonsoft.Json.JsonConvert.DeserializeObject<F>(jsonString);
Stopwatch.Stop();

Console.WriteLine($"[3.Convert] JSON to object: {obj}. The duration is : {Stopwatch.Duration}");
#endregion

Console.WriteLine("FINISH!!!");
Console.ReadKey();

