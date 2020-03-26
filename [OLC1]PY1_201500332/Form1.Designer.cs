namespace _OLC1_PY1_201500332
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pestañas = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nombrepic = new System.Windows.Forms.Label();
            this.picsig = new System.Windows.Forms.Button();
            this.picant = new System.Windows.Forms.Button();
            this.boxtrans = new System.Windows.Forms.PictureBox();
            this.boxafn = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirPestañaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarThompsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lexicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.consola = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cargarAFDsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.pestañas.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxtrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxafn)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pestañas);
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 438);
            this.panel1.TabIndex = 0;
            // 
            // pestañas
            // 
            this.pestañas.Controls.Add(this.tabPage1);
            this.pestañas.Location = new System.Drawing.Point(3, 1);
            this.pestañas.Name = "pestañas";
            this.pestañas.SelectedIndex = 0;
            this.pestañas.Size = new System.Drawing.Size(588, 437);
            this.pestañas.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(580, 408);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nueva Pestaña";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(574, 402);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nombrepic);
            this.panel2.Controls.Add(this.picsig);
            this.panel2.Controls.Add(this.picant);
            this.panel2.Controls.Add(this.boxtrans);
            this.panel2.Controls.Add(this.boxafn);
            this.panel2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.panel2.Location = new System.Drawing.Point(597, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(479, 695);
            this.panel2.TabIndex = 1;
            // 
            // nombrepic
            // 
            this.nombrepic.AutoSize = true;
            this.nombrepic.Location = new System.Drawing.Point(90, 336);
            this.nombrepic.Name = "nombrepic";
            this.nombrepic.Size = new System.Drawing.Size(61, 17);
            this.nombrepic.TabIndex = 9;
            this.nombrepic.Text = "Ninguna";
            // 
            // picsig
            // 
            this.picsig.Location = new System.Drawing.Point(359, 325);
            this.picsig.Name = "picsig";
            this.picsig.Size = new System.Drawing.Size(93, 35);
            this.picsig.TabIndex = 8;
            this.picsig.Text = "Siguiente";
            this.picsig.UseVisualStyleBackColor = true;
            this.picsig.Click += new System.EventHandler(this.picsig_Click);
            // 
            // picant
            // 
            this.picant.Location = new System.Drawing.Point(250, 325);
            this.picant.Name = "picant";
            this.picant.Size = new System.Drawing.Size(94, 35);
            this.picant.TabIndex = 7;
            this.picant.Text = "Anterior";
            this.picant.UseVisualStyleBackColor = true;
            this.picant.Click += new System.EventHandler(this.picant_Click);
            // 
            // boxtrans
            // 
            this.boxtrans.Location = new System.Drawing.Point(3, 370);
            this.boxtrans.Name = "boxtrans";
            this.boxtrans.Size = new System.Drawing.Size(473, 313);
            this.boxtrans.TabIndex = 6;
            this.boxtrans.TabStop = false;
            // 
            // boxafn
            // 
            this.boxafn.Location = new System.Drawing.Point(3, 3);
            this.boxafn.Name = "boxafn";
            this.boxafn.Size = new System.Drawing.Size(473, 316);
            this.boxafn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boxafn.TabIndex = 5;
            this.boxafn.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1077, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.añadirPestañaToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // añadirPestañaToolStripMenuItem
            // 
            this.añadirPestañaToolStripMenuItem.Name = "añadirPestañaToolStripMenuItem";
            this.añadirPestañaToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.añadirPestañaToolStripMenuItem.Text = "Añadir Pestaña";
            this.añadirPestañaToolStripMenuItem.Click += new System.EventHandler(this.añadirPestañaToolStripMenuItem_Click);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarThompsonToolStripMenuItem,
            this.guardarToolStripMenuItem1,
            this.guardarErroresToolStripMenuItem,
            this.cargarAFDsToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // cargarThompsonToolStripMenuItem
            // 
            this.cargarThompsonToolStripMenuItem.Name = "cargarThompsonToolStripMenuItem";
            this.cargarThompsonToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cargarThompsonToolStripMenuItem.Text = "Cargar Thompson";
            this.cargarThompsonToolStripMenuItem.Click += new System.EventHandler(this.cargarThompsonToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem1
            // 
            this.guardarToolStripMenuItem1.Name = "guardarToolStripMenuItem1";
            this.guardarToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.guardarToolStripMenuItem1.Text = "Guardar Tokens";
            this.guardarToolStripMenuItem1.Click += new System.EventHandler(this.guardarToolStripMenuItem1_Click);
            // 
            // guardarErroresToolStripMenuItem
            // 
            this.guardarErroresToolStripMenuItem.Name = "guardarErroresToolStripMenuItem";
            this.guardarErroresToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.guardarErroresToolStripMenuItem.Text = "Guardar Errores";
            this.guardarErroresToolStripMenuItem.Click += new System.EventHandler(this.guardarErroresToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lexicToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // lexicToolStripMenuItem
            // 
            this.lexicToolStripMenuItem.Name = "lexicToolStripMenuItem";
            this.lexicToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.lexicToolStripMenuItem.Text = "Errores lexicos";
            this.lexicToolStripMenuItem.Click += new System.EventHandler(this.lexicToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.consola);
            this.panel3.Location = new System.Drawing.Point(12, 495);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(575, 188);
            this.panel3.TabIndex = 4;
            // 
            // consola
            // 
            this.consola.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consola.Location = new System.Drawing.Point(0, 0);
            this.consola.Name = "consola";
            this.consola.Size = new System.Drawing.Size(575, 188);
            this.consola.TabIndex = 0;
            this.consola.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "ARCHIVOS ER(*.er)|*.er";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Archivos ER(*.er)|*.er";
            // 
            // cargarAFDsToolStripMenuItem
            // 
            this.cargarAFDsToolStripMenuItem.Name = "cargarAFDsToolStripMenuItem";
            this.cargarAFDsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cargarAFDsToolStripMenuItem.Text = "Cargar AFDs";
            this.cargarAFDsToolStripMenuItem.Click += new System.EventHandler(this.cargarAFDsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 695);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.pestañas.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxtrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxafn)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirPestañaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarThompsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem guardarErroresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lexicToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl pestañas;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox consola;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox boxafn;
        private System.Windows.Forms.Button picsig;
        private System.Windows.Forms.Button picant;
        private System.Windows.Forms.PictureBox boxtrans;
        private System.Windows.Forms.Label nombrepic;
        private System.Windows.Forms.ToolStripMenuItem cargarAFDsToolStripMenuItem;
    }
}

