using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using _OLC1_PY1_201500332.Logica;

namespace _OLC1_PY1_201500332
{
    public partial class Form1 : Form
    {
        Archivo archivo = new Archivo();
        AnalisisSintArch sint;
        Ejecutar ejecutar = new Ejecutar();
        ArrayList erroresLex;
        public Form1()
        {
            InitializeComponent();
        }


        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pestañas.SelectedTab.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);
                string texto = archivo.abrirArchivo(openFileDialog1.FileName);
                if (!texto.Equals("Error al abrir el archivo")) this.pestañas.SelectedTab.Controls[0].Text = texto;
                else MessageBox.Show(texto);
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string texto = this.pestañas.SelectedTab.Controls[0].Text;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pestañas.SelectedTab.Text = System.IO.Path.GetFileName(saveFileDialog1.FileName);
                MessageBox.Show(archivo.guardarArchivo(saveFileDialog1.FileName, texto));
            }
        }

        private void añadirPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox rtb1 = new RichTextBox();
            rtb1.Dock = DockStyle.Fill;
            TabPage nueva = new TabPage("Nueva Pestaña");
            nueva.Controls.Add(rtb1);
            this.pestañas.TabPages.Add(nueva);
            this.pestañas.SelectedTab = nueva;
        }

        private void cargarThompsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string graph;
            ejecutar.expresiones.Clear();
            ejecutar.cadenas.Clear();
            ejecutar.conjuntos.Clear();
            if (!this.pestañas.SelectedTab.Controls[0].Text.Equals(""))
            {
                sint = new AnalisisSintArch();
                sint.analizar((RichTextBox)this.pestañas.SelectedTab.Controls[0], ejecutar.conjuntos, ejecutar.expresiones, ejecutar.cadenas);
                erroresLex = sint.lexico.errores;
                foreach(ExpresionRegular exp in ejecutar.expresiones)
                {
                    graph = archivo.graficar("AFNs", exp.getId(), exp.getAFN().dibujar());
                }
                ejecutar.crearAFD();
                foreach (ExpresionRegular exp in ejecutar.expresiones)
                {
                    archivo.graficar("AFDs", exp.getId(), exp.afd.dibujar());
                    archivo.graficar("Transiciones", exp.getId(), exp.afd.dibujarTrans(exp.simbolos));
                }
                foreach (CadenaAValidar c in ejecutar.cadenas)
                {
                    string val = ejecutar.validarLexema(c);
                    consola.Text += c.getId() + ": " + val + "\n";
                }
            }
        }

        private void lexicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivo.generarPDF(erroresLex);
        }

        private void guardarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
             for(int i = 0; i < ejecutar.expresiones.Count; i++)
            {
                ExpresionRegular exp = (ExpresionRegular) ejecutar.expresiones[i];
                archivo.generarXMLTok(ejecutar.cadenas, exp, "Tokens" + exp.getId());
            }
        }

        private void guardarErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ejecutar.expresiones.Count; i++)
            {
                ExpresionRegular exp = (ExpresionRegular)ejecutar.expresiones[i];
                archivo.generarXMLFail(ejecutar.cadenas, exp, "Errores" + exp.getId());
            }
        }
    }

    
}
