using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace PROYECTO_LFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int numero_estados = 0;
        int estado_inicial = 0;
        int contadorlineas = 0;
        List<Transicion> transicions = new List<Transicion>();

        private void btn_archivo_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                var reader = new StreamReader(openFileDialog1.FileName);
                string linea = reader.ReadLine();
                contadorlineas = 0;

                while (linea!= null)
                {
                    if (contadorlineas == 0) //lee la cantidad de estados
                    {
                        numero_estados = Convert.ToInt32(linea);
                        contadorlineas++;
                        linea = reader.ReadLine();
                    }
                    else if (contadorlineas == 1) //lee el estado inicial
                    {
                        estado_inicial = Convert.ToInt32(linea);
                        contadorlineas++;
                        linea = reader.ReadLine();
                    }
                    else if (contadorlineas == 2) //lee el conjunto de estados finales
                    {
                        var estados_finales = linea.Split(',');
                        contadorlineas++;
                        linea = reader.ReadLine();
                    }
                    else
                    {
                        var transicion = linea.Split(',');
                        Transicion obj = new Transicion();
                        obj.Inicial = transicion[0];
                        obj.Leido = transicion[1];
                        obj.Pop = transicion[2];
                        obj.Push = transicion[3];
                        obj.Final=transicion[4];
                        transicions.Add(obj);

                        linea = reader.ReadLine();
                    }
                    
                }
            }
        }
    }
}
