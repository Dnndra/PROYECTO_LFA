using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LFA
{
    public class Transicion
    {
        private string inicial;

        private string leido;

        private string simbolo_pop;

        private string simbolo_push;

        private string final;

        public Transicion(){
            inicial = "";
            leido = "";
            simbolo_pop = "";
            simbolo_push = "";
            final = "";
        }

        public string Inicial
        {
            get { return inicial; }
            set { inicial = value; }
        }
        public string Leido
        {
            get { return leido; }   
            set { leido = value; }  
        }
        public string Pop
        {
            get { return simbolo_pop; } 
            set { simbolo_pop = value;}
        }
        public string Push
        {
            get { return simbolo_push; }
            set { simbolo_push = value;}
        }
        public string Final
        {
            get { return final; }  
            set { final = value; }
        }
     }
}
