using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LFA
{
    public class Automata
    {
        string num_estados { get; set; }

        string estado_inicial { get; set; }

        string[] conjunto_finales { get; set; }

        List<Transicion> transiciones { get; set; }
    }
}
