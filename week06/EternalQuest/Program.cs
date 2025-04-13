using System;

class Program
{
    static void Main(string[] args)
    {
        // Crear una instancia del GoalManager y comenzar el programa
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}

/*
    Creatividad y requisitos adicionales:
    
    1. Se ha implementado un sistema de bonificación para los objetivos de tipo checklist,
       donde el usuario recibe puntos adicionales al completar el objetivo el número de veces requerido.
    
    2. Se ha mejorado la interfaz de usuario con mensajes claros y formateo adecuado para
       facilitar la comprensión y uso del programa.
    
    3. Se ha implementado un sistema robusto de guardado y carga que permite al usuario
       mantener su progreso entre sesiones.
*/