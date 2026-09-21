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



Console.WriteLine("\n-- PREPARACIÓN PARALELISMO --");
cont.Restart();
var tCafe = DesayunoAsync.HacerCafe();
var tTostada = PrepararTostadaAsync();
var tFritos = PrepararFritosAsync();
var tZumo = DesayunoAsync.HacerZumo();
await Task.WhenAll(tCafe, tTostada, tFritos, tZumo);
cont.Stop();

Console.WriteLine($"\nDesayuno listo (paralelo) en {cont.ElapsedMilliseconds} ms");
return;

// funciones para agrupar acciones que dependen de otras
async Task PrepararTostadaAsync() {
    
    await DesayunoAsync.TostarPan();
    await DesayunoAsync.UntarMantequilla(); // necesita el pan tostado
}

async Task PrepararFritosAsync() { 
    
    await DesayunoAsync.CalentarSarten();          
    var tHuevos = DesayunoAsync.FreirHuevos();      
    var tBacon = DesayunoAsync.FreirBacon();
    await Task.WhenAll(tHuevos, tBacon);            // necesitan que la sartén esté caliente
}
