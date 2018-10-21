using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repaso
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //int[] v1 = { 1, 2, 3, 4, 5, 6, 7, 8 };
            //int[] v2 = { 4, 2, 3, 1, 5, 6, 7, 8 };
            //int[] v3 = { 10, 9, 8, 3, 2, 1, 0, -1 };

            //MessageBox.Show(evaluarOrden(v1).ToString());
            //MessageBox.Show(evaluarOrden(v2).ToString());
            //MessageBox.Show(evaluarOrden(v3).ToString());

            txtAmigos.Text = muestraAmigos();
        }

        private int evaluarOrden(int[] vector)
        {
            int aux = vector[0];
            int orden = 0;

            for (int i = 1; i < vector.Length; i++)
            {
                if (aux <= vector[i])
                    orden++;
                else if (aux >= vector[i])
                    orden--;
                aux = vector[i];
            }

            if (orden == vector.Length - 1)
                return 1;
            else if (orden == (vector.Length - 1) * -1)
                return -1;
            else
                return 0;
        }

        private string muestraAmigos()
        {
            string resultado = "";
            int[] pares = new int[3000 / 2];
            int divisoresA = 0;
            int divisoresB = 0;

            for (int i = 2; i <= 3000; i++)
            {
                if (i % 2 == 0)
                    pares[i / 2 - 1] = i;
            }

            foreach (int a in pares)
            {
                foreach(int b in pares)
                {
                    for (int divA = a/2; divA > 0; divA--)
                    {
                        if (a % divA == 0)
                            divisoresA += divA;
                    }

                    for (int divB = b/2; divB > 0; divB--)
                    {
                        if (b % divB == 0)
                            divisoresB += divB;
                    }

                    if (divisoresA == b && divisoresB == a && a != b)
                        resultado += a.ToString() + ", " + b.ToString() + Environment.NewLine;
                    divisoresA = 0;
                    divisoresB = 0;
                }
            }
            return resultado;
        }
    }
}