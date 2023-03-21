using JP;

Console.WriteLine("Juego de preguntas!");

var preguntas = new List<Pregunta>();
var respuestas = new List<Respuesta>();

var puntajes = new Dictionary<string, int>();


Semilla();

Iniciar();

void Iniciar()
{
    Console.WriteLine("Estas listo?");

    Console.WriteLine("Cual es tu nombre?");

    var jugador = Console.ReadLine();
    Console.WriteLine($"EntendIdo {jugador} hagamoslo!");

    foreach (var item in preguntas)
    {
        Console.WriteLine(item.PreguntaTexto);
        Console.WriteLine("Porfavor seleccione la Opcion 1, 2, 3 o 4");
        foreach (var opcion in item.Opcion)
        {
            Console.WriteLine($"{opcion.Id}. {opcion.Texto}");
        }

        var respuesta = RespuestaSeleccionada();
        AgregarRespuesta(respuesta, item);
    }

    int puntaje = Puntaje();
    Console.WriteLine($"Buen intento {jugador}, has respondido bien {puntaje} preguntas!");
    ActualizarPuntaje(jugador, puntaje);
    MostrarPuntajes();

    respuestas = new List<Respuesta>();

    Console.WriteLine("Quieres Jugar otra vez?");
    Console.WriteLine("Ingrese SI para jugar de nuevo o otra letra para terminar de jugar.");

    var juegoNuevo = Console.ReadLine();
    if (juegoNuevo?.ToLower().Trim() == "si")
        Iniciar();


}

string RespuestaSeleccionada()
{

    var respuesta = Console.ReadLine();

    if (respuesta != null && (respuesta == "1") || (respuesta == "2") || (respuesta == "3") || (respuesta == "4"))
        return respuesta;
    else
    {
        Console.WriteLine("Esta no es una Opcion valIda, porfavor pruebe de nuevo");
        respuesta = RespuestaSeleccionada();
    }
    return respuesta;
}

void AgregarRespuesta(string respuesta, Pregunta pregunta)
{
    respuestas.Add(new Respuesta
    {
        PreguntaId = pregunta.Id,
        SeleccionOpcion = SeleccionOpciones( respuesta, pregunta)
    });
}

Opcion SeleccionOpciones(string respuesta, Pregunta pregunta)
{
    var opcionSeleccionada = new Opcion();

    foreach (var item in pregunta.Opcion)
    {
        if (item.Id == int.Parse(respuesta))
            opcionSeleccionada = item;
    }

    return opcionSeleccionada;

}

void Semilla()
{
    preguntas.Add(new Pregunta
    {
        Id = 1,
        PreguntaTexto = "Cual es el pais mas grande del mundo",
        Opcion = new List<Opcion>()
        {
            new Opcion(){Id = 1, Texto = "Australia"},
            new Opcion(){Id = 2, Texto = "China"},
            new Opcion(){Id = 3, Texto = "Canada"},
            new Opcion(){Id = 4, Texto = "Rusia", Valido = true}
        }

    });
    preguntas.Add(new Pregunta
    {
        Id = 2,
        PreguntaTexto = "Cual es el pais con mas poblacion en el mundo",
        Opcion = new List<Opcion>()
        {
            new Opcion(){Id = 1, Texto = "india"},
            new Opcion(){Id = 2, Texto = "China", Valido = true},
            new Opcion(){Id = 3, Texto = "Estados UnIdos"},
            new Opcion(){Id = 4, Texto = "Indonesia"}
        }

    });
    preguntas.Add(new Pregunta
    {
        Id = 3,
        PreguntaTexto = "Cual es el pais con menos corrupcion en el mundo en 2023",
        Opcion = new List<Opcion>()
        {
            new Opcion(){Id = 1, Texto = "Finlandia"},
            new Opcion(){Id = 2, Texto = "Nueva Zelanda"},
            new Opcion(){Id = 3, Texto = "Dinamarca", Valido = true},
            new Opcion(){Id = 4, Texto = "Noruega"}
        }

    });
    preguntas.Add(new Pregunta
    {
        Id = 3,
        PreguntaTexto = "Cual es el pais calIdad de vIda en el mundo en 2023",
        Opcion = new List<Opcion>()
        {
            new Opcion(){Id = 1, Texto = "Suecia"},
            new Opcion(){Id = 2, Texto = "Belgica"},
            new Opcion(){Id = 3, Texto = "Suiza"},
            new Opcion(){Id = 4, Texto = "Noruega", Valido = true}
        }

    });
}

int Puntaje() 
{
    int puntaje = 0;

    foreach (var item in respuestas)
    {
        if (item.SeleccionOpcion.Valido)
            puntaje++;
    }
    return puntaje;
}

void ActualizarPuntaje(string jugador, int puntaje)
{
    bool actualizar = false;
    foreach (var item in puntajes)
    {
        
        if(item.Key == jugador)
        {
            puntajes[item.Key] = puntaje;
            actualizar = true;

        }
        
    }
    if (!actualizar)
        puntajes.Add(jugador, puntaje);
}

void MostrarPuntajes()
{
    Console.WriteLine("Puntajes");

    foreach (var item in puntajes)
    {
        Console.WriteLine($"{item.Key}, puntaje: {item.Value}");
    }
}