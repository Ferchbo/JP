using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP
{
    public class Pregunta
    { 
        public int id { get; set; }
        public string PreguntaT { get; set; }

        public List<Opciones> opciones { get; set; } 

    }
}
