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
await EjecutarAsyncSecuencialAsync();
cont.Stop();

Console.WriteLine($"\nDesayuno listo (async secuencial) en {cont.ElapsedMilliseconds} ms");



Console.WriteLine("\n-- PREPARACIÓN PARALELISMO --");
cont.Restart();
await EjecutarParaleloAsync();
cont.Stop();

Console.WriteLine($"\nDesayuno listo (paralelo) en {cont.ElapsedMilliseconds} ms");



Console.WriteLine("\n-- SECUENCIAL CON TIMEOUT --");
cont.Restart();

var tareaSecuencial = Task.Run(() => {
    
    DesayunoSync.HacerCafe();
    DesayunoSync.CalentarSarten();
    DesayunoSync.FreirHuevos();
    DesayunoSync.FreirBacon();
    DesayunoSync.TostarPan();
    DesayunoSync.UntarMantequilla();
    DesayunoSync.HacerZumo();
});

var ganadorSecuencial = await Task.WhenAny(tareaSecuencial, Task.Delay(500)); // 500ms delay
cont.Stop();

// si acaba la tarea el desayuno se completo, sino se enfrió el café
Console.WriteLine(ganadorSecuencial == tareaSecuencial
    ? $"\n✅  Desayuno listo a tiempo en {cont.ElapsedMilliseconds} ms"
    : $"\n☕  ¡El café se ha enfriado! Timeout tras {cont.ElapsedMilliseconds} ms");



Console.WriteLine("\n-- ASYNC/AWAIT CON TIMEOUT --");
cont.Restart();

var tareaAsync = EjecutarAsyncSecuencialAsync();
var ganadorAsync = await Task.WhenAny(tareaAsync, Task.Delay(500));
cont.Stop();

Console.WriteLine(ganadorAsync == tareaAsync
    ? $"\n✅  Desayuno listo a tiempo en {cont.ElapsedMilliseconds} ms"
    : $"\n☕  ¡El café se ha enfriado! Timeout tras {cont.ElapsedMilliseconds} ms");



Console.WriteLine("\n-- PARALELO CON TIMEOUT --");
cont.Restart();

var tareaParalela = EjecutarParaleloAsync();
var ganadorParalelo = await Task.WhenAny(tareaParalela, Task.Delay(500));
cont.Stop();

Console.WriteLine(ganadorParalelo == tareaParalela
    ? $"\n✅  Desayuno listo a tiempo en {cont.ElapsedMilliseconds} ms"
    : $"\n☕  ¡El café se ha enfriado! Timeout tras {cont.ElapsedMilliseconds} ms");

return;



// funciones para agrupar acciones que dependen de otras
async Task EjecutarAsyncSecuencialAsync() {
    
    await DesayunoAsync.HacerCafe();
    await DesayunoAsync.CalentarSarten();
    await DesayunoAsync.FreirHuevos();
    await DesayunoAsync.FreirBacon();
    await DesayunoAsync.TostarPan();
    await DesayunoAsync.UntarMantequilla();
    await DesayunoAsync.HacerZumo();
}

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

async Task EjecutarParaleloAsync() {
    
    var cafe = DesayunoAsync.HacerCafe();
    var tostada = PrepararTostadaAsync();
    var fritos = PrepararFritosAsync();
    var zumo = DesayunoAsync.HacerZumo();
    await Task.WhenAll(cafe, tostada, fritos, zumo);
}