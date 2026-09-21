using System.Diagnostics;
using System.Text;
using Desayuno;

Console.OutputEncoding = Encoding.UTF8;
var cont = Stopwatch.StartNew();

Console.WriteLine("-- PREPARACIÓN SÍNCRONA --");
cont.Restart();
DesayunoSync.HacerCafe();
DesayunoSync.CalentarSarten();
DesayunoSync.FreirHuevos();
DesayunoSync.FreirBacon();
DesayunoSync.TostarPan();
DesayunoSync.UntarMantequilla();
DesayunoSync.HacerZumo();
cont.Stop();

Console.WriteLine($"\nDesayuno listo (secuencial) en {cont.ElapsedMilliseconds} ms");



Console.WriteLine("\n-- PREPARACIÓN ASYNC/AWAIT --");
cont.Restart();
await DesayunoAsync.HacerCafe();
await DesayunoAsync.CalentarSarten();
await DesayunoAsync.FreirHuevos();
await DesayunoAsync.FreirBacon();
await DesayunoAsync.TostarPan();
await DesayunoAsync.UntarMantequilla();
await DesayunoAsync.HacerZumo();
cont.Stop();

Console.WriteLine($"\nDesayuno listo (async secuencial) en {cont.ElapsedMilliseconds} ms");
