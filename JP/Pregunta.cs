using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP
{
    public class Pregunta
    { 
        public int Id { get; set; }
        public string PreguntaTexto { get; set; }

        public List<Opcion> Opcion { get; set; } 

    }
}
