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
        AnalisisArchivo lexico = new AnalisisArchivo();
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
            if (!this.pestañas.SelectedTab.Controls[0].Text.Equals(""))
            {
                this.consola.Text = lexico.analizar((RichTextBox)this.pestañas.SelectedTab.Controls[0]);
                foreach(Token tok in lexico.errores)
                {
                    consola.Text += "\n" + tok.getLexema() + "  , linea: " + tok.getLinea();
                }
            }
        }

        private void lexicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrincipalAFN afn = new PrincipalAFN();
            SubAFN afnf = afn.crearKleene(afn.crearBasico("a"));
            foreach(Estado edo in afnf.getEstados())
            {
                foreach(TransicionThompson trans in edo.getTransiciones())
                {
                    this.consola.Text += trans.getInicio().getId().ToString() + "--" + trans.getLexema() + "--" + trans.getFinal().getId().ToString() + "\n";
                }
            }
        }
    }

    
}
