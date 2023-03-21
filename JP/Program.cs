using JP;

Console.WriteLine("Juego de preguntas!");

var pregunta = new List<Pregunta>();

void Semilla()
{
    pregunta.Add(new Pregunta
    {
        id = 1,
        PreguntaT = "Cual es el pais mas grande del mundo",
        opciones = new List<Opciones>
    })
}
