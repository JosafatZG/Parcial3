namespace Parcial3
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
            this.btnvertice = new System.Windows.Forms.Button();
            this.btnarista = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtvertice = new System.Windows.Forms.TextBox();
            this.cmbvertice = new System.Windows.Forms.ComboBox();
            this.cmbarista = new System.Windows.Forms.ComboBox();
            this.cmbinicio = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoVérticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(24, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1192, 409);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // btnvertice
            // 
            this.btnvertice.Location = new System.Drawing.Point(242, 46);
            this.btnvertice.Name = "btnvertice";
            this.btnvertice.Size = new System.Drawing.Size(75, 27);
            this.btnvertice.TabIndex = 1;
            this.btnvertice.Text = "Eliminar";
            this.btnvertice.UseVisualStyleBackColor = true;
            this.btnvertice.Click += new System.EventHandler(this.btnvertice_Click);
            // 
            // btnarista
            // 
            this.btnarista.Location = new System.Drawing.Point(242, 115);
            this.btnarista.Name = "btnarista";
            this.btnarista.Size = new System.Drawing.Size(75, 24);
            this.btnarista.TabIndex = 2;
            this.btnarista.Text = "Eliminar";
            this.btnarista.UseVisualStyleBackColor = true;
            this.btnarista.Click += new System.EventHandler(this.btnarista_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(216, 109);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 26);
            this.button3.TabIndex = 4;
            this.button3.Text = "Anchura";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(44, 109);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 26);
            this.button4.TabIndex = 3;
            this.button4.Text = "Profundidad";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(100, 109);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 24);
            this.button5.TabIndex = 5;
            this.button5.Text = "Buscar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Vértice";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Arista";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nodo de inicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Vértice";
            // 
            // txtvertice
            // 
            this.txtvertice.Location = new System.Drawing.Point(131, 43);
            this.txtvertice.Name = "txtvertice";
            this.txtvertice.Size = new System.Drawing.Size(100, 22);
            this.txtvertice.TabIndex = 10;
            // 
            // cmbvertice
            // 
            this.cmbvertice.FormattingEnabled = true;
            this.cmbvertice.Location = new System.Drawing.Point(100, 49);
            this.cmbvertice.Name = "cmbvertice";
            this.cmbvertice.Size = new System.Drawing.Size(121, 24);
            this.cmbvertice.TabIndex = 11;
            // 
            // cmbarista
            // 
            this.cmbarista.FormattingEnabled = true;
            this.cmbarista.Location = new System.Drawing.Point(100, 115);
            this.cmbarista.Name = "cmbarista";
            this.cmbarista.Size = new System.Drawing.Size(121, 24);
            this.cmbarista.TabIndex = 12;
            // 
            // cmbinicio
            // 
            this.cmbinicio.FormattingEnabled = true;
            this.cmbinicio.Location = new System.Drawing.Point(156, 43);
            this.cmbinicio.Name = "cmbinicio";
            this.cmbinicio.Size = new System.Drawing.Size(121, 24);
            this.cmbinicio.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnvertice);
            this.groupBox1.Controls.Add(this.btnarista);
            this.groupBox1.Controls.Add(this.cmbarista);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbvertice);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(41, 460);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 174);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eliminar elementos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbinicio);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(440, 460);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 174);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recorridos";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.txtvertice);
            this.groupBox3.Location = new System.Drawing.Point(822, 460);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(273, 174);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buscar vértice";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoVérticeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 56);
            // 
            // nuevoVérticeToolStripMenuItem
            // 
            this.nuevoVérticeToolStripMenuItem.Name = "nuevoVérticeToolStripMenuItem";
            this.nuevoVérticeToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.nuevoVérticeToolStripMenuItem.Text = "Nuevo Vértice";
            this.nuevoVérticeToolStripMenuItem.Click += new System.EventHandler(this.nuevoVérticeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 664);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnvertice;
        private System.Windows.Forms.Button btnarista;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtvertice;
        private System.Windows.Forms.ComboBox cmbvertice;
        private System.Windows.Forms.ComboBox cmbarista;
        private System.Windows.Forms.ComboBox cmbinicio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoVérticeToolStripMenuItem;
    }
}

