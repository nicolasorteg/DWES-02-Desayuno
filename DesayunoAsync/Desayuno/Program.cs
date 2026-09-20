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