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
            if (!this.pestañas.SelectedTab.Controls[0].Text.Equals(""))
            {
                sint = new AnalisisSintArch();
                sint.analizar((RichTextBox)this.pestañas.SelectedTab.Controls[0], ejecutar.conjuntos, ejecutar.expresiones, ejecutar.cadenas);
                foreach(ExpresionRegular exp in ejecutar.expresiones)
                {
                    graph = archivo.graficar("AFNs", exp.getId(), exp.getAFN().dibujar());
                    if (graph.Equals("exito")) MessageBox.Show("AFN creado");
                    else MessageBox.Show("No se pudo crear el AFN");
                }

            }
        }

        private void lexicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ejecutar.crearAFD();
            foreach(ExpresionRegular exp in ejecutar.expresiones)
                archivo.graficar("AFDs", exp.getId(), exp.afd.dibujar());

        }
    }

    
}
