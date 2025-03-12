Console.WriteLine("El juego consta de 9 palabras");
Console.WriteLine("Al ingresar la letra, esta debe estar en mayuscula,"
                 + "caso contrario no se toma en cuenta y si descubrio la palabra puede ingresarla todo en mayuscula");
Console.WriteLine("Por palabra solo se debe escirbir una vez la letra, caso contrario se le restara la vida");
Console.WriteLine("Si necesitas ayuda escribe HELP");
Game juego = new Game(); 
int vida = 5;
int palabra_busqueda = 0;
Console.WriteLine("Tienes 5 vidas");
juego.persona(juego.vidas_restantes());
juego.mostrar_palabra();
while (juego.vidas_restantes() >= 0)
{
    if(juego.vidas_restantes() == 0)
    {
        Console.WriteLine("Fin del Juego");
        juego.persona(juego.vidas_restantes());
        break;
    }
    else if(juego.vidas_restantes() != vida)
    {
        vida = juego.vidas_restantes();
        juego.persona(juego.vidas_restantes());
        juego.mostrar_palabra();
    }
    else if (juego.obtener_cantidad_palabras()-1 == juego.obtener_palabra_aux()){
        Console.WriteLine("Fin del Juego");
        break;
    }
    else
    {
        string letra = Console.ReadLine();
        if (juego.verificador(letra) == true)
        {
            if(letra == "HELP")
            {
                AYUDA ayu = new AYUDA();
                ayu.mostrar_consejo();
            }
            else
            {
                juego.proceso(letra);
            }
        }
        else
        {
            continue;
        }
    }
}