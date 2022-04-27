using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LFA
{
    public class Automata
    {
        private int num_estados;

        private int estado_inicial;

        private List<string> conjunto_finales;

        private List<Transicion> transiciones;

        public Automata()
        {
            num_estados = 0;
            estado_inicial = 0;
            transiciones = new List<Transicion>();
            conjunto_finales = new List<string>();
        }
        public int N_Estados
        {
            get { return num_estados; }
            set { num_estados = value;}
        }
        public int E_Inicial
        {
            get { return estado_inicial; }
            set { estado_inicial = value;}
        }
        public List<string> C_Finales
        {
            get { return conjunto_finales; }
            set { conjunto_finales = value;}
        }
        public List<Transicion> Transiciones
        {
            get { return transiciones; }
            set { transiciones = value;}
        }
    }
}
