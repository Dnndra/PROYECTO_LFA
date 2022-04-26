using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LFA
{
     public class Transicion
    {
        public string inicial { get; set; }

        public string leido { get; set; }
        
        public string simbolo_pop { get; set; }

        public string simbolo_push { get; set; }
    
        public string final { get; set; }    
    }
}
