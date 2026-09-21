namespace Desayuno;

/// <summary>
/// Clase con métodos estáticos para simular
/// la preparación del desayuno usando async/await.
/// </summary>
public static class DesayunoAsync {

    public static async Task HacerCafe() {
        
        Console.WriteLine("🟢 Empezando: Hacer café");
        await Task.Delay(200);
        Console.WriteLine("🔴 Terminado: Hacer café");
    }

    public static async Task CalentarSarten() {
        
        Console.WriteLine("🟢 Empezando: Calentar sartén");
        await Task.Delay(200);
        Console.WriteLine("🔴 Terminado: Calentar sartén");
    }

    public static async Task FreirHuevos() {
        
        Console.WriteLine("🟢 Empezando: Freír huevos");
        await Task.Delay(300);
        Console.WriteLine("🔴 Terminado: Freír huevos");
    }

    public static async Task FreirBacon() {
        
        Console.WriteLine("🟢 Empezando: Freír bacon");
        await Task.Delay(300);
        Console.WriteLine("🔴 Terminado: Freír bacon");
    }

    public static async Task TostarPan() {
        
        Console.WriteLine("🟢 Empezando: Tostar pan");
        await Task.Delay(200);
        Console.WriteLine("🔴 Terminado: Tostar pan");
    }

    public static async Task UntarMantequilla() {
        
        Console.WriteLine("🟢 Empezando: Untar mantequilla");
        await Task.Delay(100);
        Console.WriteLine("🔴 Terminado: Untar mantequilla");
    }

    public static async Task HacerZumo() {
        
        Console.WriteLine("🟢 Empezando: Hacer zumo");
        await Task.Delay(200);
        Console.WriteLine("🔴 Terminado: Hacer zumo");
    }
}