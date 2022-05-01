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
            //lectura de cadena entrante
            string cadena = CadenaEntrante.Text;
            //definición de estado inicial 
            int estadoA = PushDown.E_Inicial;
            //buscamos transiciones del estado inicial 
            List<Transicion> Tactual = FindT(estadoA);  
            //si alguna lee vacio, ingresamos a esa primero
            foreach (Transicion t in Tactual)
            {
                if(t.Leido == " ")
                {
                    estadoA = t.Final;
                    //encontramos trancisiones del estado actual
                    Tactual = FindT(estadoA);
                    // si el push no está vacío, se mete su contenido a la pila
                    if (t.Push != " ") Pila.Push(t.Push);
                    break;
                }
            }
            //realizamos proceso con cadena
            for (int i = 0; i < cadena.Length; i++)
            {
                //si la pila tiene algo, buscamos transicion que saque lo que está en la pila primero 
                if (Pila.Any())
                {
                    foreach(Transicion t in Tactual)
                    {
                        if(t.Pop == Pila.Peek() && t.Leido == cadena)
                        {
                            Validacion(t, cadena[i].ToString(), ref estadoA);
                            //encontramos trancisiones del estado actual
                            Tactual = FindT(estadoA);
                            continue; // puse el continue aquí suponiendo que regrese el for, si no lo hace hay que hacer un bool que se vaya a un continue afuera del foreach
                        }
                    }
                    //si no hay ninguna transicion que saque lo último que tiene, unicamente válida que lea lo de la cadena
                    foreach (Transicion t in Tactual)
                    {
                        if (t.Leido == cadena)
                        {
                            Validacion(t, cadena[i].ToString(), ref estadoA);
                        }
                    }
                }
                else //si no tiene nada, mete la transición que lea el caracter
                {
                    foreach (Transicion t in Tactual)
                    {
                        if (t.Leido == cadena)
                        {
                            Validacion(t, cadena[i].ToString(), ref estadoA);
                        }
                    }
                }
                //encontramos trancisiones del estado actual
                Tactual = FindT(estadoA);
            }
            //una vez hecho todo esto, se válida que la pila esté vacía 
            if (Pila.Any())
            {
                DialogResult result  = MessageBox.Show("Cadena no aceptada por grámatica ingresada.\nIntente de nuevo.", "Error en grámatica", MessageBoxButtons.OK);
            }
        }
        List<Transicion> FindT(int estado)
        {
            List<Transicion> TFind;
            return TFind = PushDown.Transiciones.FindAll(
                //delegado para encontrar todas las transiciones 
                delegate (Transicion t)
                {
                    return t.Inicial == estado;
                }
            );
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
