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
        Automata PushDown = new Automata();
        Stack<string> Pila = new Stack<string>();
        private void btn_archivo_Click(object sender, EventArgs e)
        {
            List<Transicion> transitions = new List<Transicion>();
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
                        PushDown.C_Finales = linea.Split(',').ToList();
                        contadorlineas++;
                        linea = reader.ReadLine();
                    }
                    else
                    {
                        var transicion = linea.Split(',');
                        Transicion obj = new Transicion();
                        obj.Inicial = int.Parse(transicion[0]);
                        obj.Leido = transicion[1];
                        obj.Pop = transicion[2];
                        obj.Push = transicion[3];
                        obj.Final= int.Parse(transicion[4]);
                        transitions.Add(obj);

                        linea = reader.ReadLine();
                    }
                    
                }
                PushDown.Transiciones = transitions;
                PushDown.N_Estados = numero_estados;
                PushDown.E_Inicial = estado_inicial;
               
            }
            //mostrar mensaje error
        }

        private void Load_Click(object sender, EventArgs e)
        {
            string cadena = CadenaEntrante.Text;
            int estadoA = PushDown.E_Inicial;
            bool aceptado = true, primera = true;
            for (int j = 0; j < cadena.Length; j++)
            {
                if (aceptado)
                {
                    aceptado = false;

                    for(int i = 0; i < PushDown.Transiciones.Count; i++)
                    {
                        if (PushDown.Transiciones[i].Inicial == estadoA)
                        {
                            if (j == cadena.Length - 1 || primera)
                            {
                                if (Validacion(PushDown.Transiciones[i], " ", ref estadoA))
                                {
                                    i = -1;
                                    primera = false;
                                    continue;
                                }
                            }
                            if(Validacion(PushDown.Transiciones[i], cadena[j].ToString(), ref estadoA))
                            {
                                aceptado = true;
                                primera = false;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            //mensaje de error
        }

        bool Validacion(Transicion t, string c, ref int estadoA)
        {
            if (t.Leido == c)
            {
                if (Pila.Count != 0)
                {
                    if (t.Pop == Pila.Peek())
                    {
                        if (t.Pop != " ")
                        {
                            Pila.Pop();
                        }
                        if (t.Push != " ")
                        {
                            for (int i = t.Push.Length-1; i >= 0; i--)
                            {
                                Pila.Push(t.Push[i].ToString());
                            }
                        }
                        estadoA = t.Final;
                        return true;
                    }
                    else
                    {
                        if (t.Pop == " ")
                        {
                            if (t.Push != " ")
                            {
                                for (int i = t.Push.Length - 1; i >= 0; i--)
                                {
                                    Pila.Push(t.Push[i].ToString());
                                }
                            }
                            estadoA = t.Final;
                            return true;
                        }
                        return false; 
                    }
                }
                else
                {
                    if (t.Pop == " ")
                    {
                        if (t.Push != " ")
                        {
                            for (int i = t.Push.Length-1; i >= 0; i--)
                            {
                                Pila.Push(t.Push[i].ToString());
                            }
                        }
                        estadoA = t.Final;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
