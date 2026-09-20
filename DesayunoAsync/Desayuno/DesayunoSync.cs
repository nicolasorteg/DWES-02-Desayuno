namespace Desayuno;

/// <summary>
/// Clase con métodos estáticos para simular
/// la preparación síncrona del desayuno.
/// </summary>
public static class DesayunoSync {
    
    public static void HacerCafe() {
        
        Console.WriteLine("🟢 Empezando: Hacer café");
        Thread.Sleep(200);
        Console.WriteLine("🔴 Terminado: Hacer café");
    }

    public static void CalentarSarten() {
        
        Console.WriteLine("🟢 Empezando: Calentar sartén");
        Thread.Sleep(200);
        Console.WriteLine("🔴 Terminado: Calentar sartén");
    }

    public static void FreirHuevos() {
        
        Console.WriteLine("🟢 Empezando: Freír huevos");
        Thread.Sleep(300);
        Console.WriteLine("🔴 Terminado: Freír huevos");
    }

    public static void FreirBacon() {
        
        Console.WriteLine("🟢 Empezando: Freír bacon");
        Thread.Sleep(300);
        Console.WriteLine("🔴 Terminado: Freír bacon");
    }

    public static void TostarPan() {
        
        Console.WriteLine("🟢 Empezando: Tostar pan");
        Thread.Sleep(200);
        Console.WriteLine("🔴 Terminado: Tostar pan");
    }

    public static void UntarMantequilla() {
        
        Console.WriteLine("🟢 Empezando: Untar mantequilla");
        Thread.Sleep(100);
        Console.WriteLine("🔴 Terminado: Untar mantequilla");
    }

    public static void HacerZumo() {
        
        Console.WriteLine("🟢 Empezando: Hacer zumo");
        Thread.Sleep(200);
        Console.WriteLine("🔴 Terminado: Hacer zumo");
    }
}