
namespace PROYECTO_LFA
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_archivo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CadenaEntrante = new System.Windows.Forms.TextBox();
            this.Load = new System.Windows.Forms.Button();
            this.ShowAP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_archivo
            // 
            this.btn_archivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(251)))), ((int)(((byte)(236)))));
            this.btn_archivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_archivo.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_archivo.Location = new System.Drawing.Point(55, 103);
            this.btn_archivo.Margin = new System.Windows.Forms.Padding(2);
            this.btn_archivo.Name = "btn_archivo";
            this.btn_archivo.Size = new System.Drawing.Size(245, 78);
            this.btn_archivo.TabIndex = 0;
            this.btn_archivo.Text = "Cargar Autómata";
            this.btn_archivo.UseVisualStyleBackColor = false;
            this.btn_archivo.Click += new System.EventHandler(this.btn_archivo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(78)))), ((int)(((byte)(103)))));
            this.label1.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(251)))), ((int)(((byte)(236)))));
            this.label1.Location = new System.Drawing.Point(295, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "AUTÓMATAS DE PILA";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CadenaEntrante
            // 
            this.CadenaEntrante.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CadenaEntrante.Location = new System.Drawing.Point(451, 103);
            this.CadenaEntrante.Name = "CadenaEntrante";
            this.CadenaEntrante.Size = new System.Drawing.Size(400, 26);
            this.CadenaEntrante.TabIndex = 2;
            // 
            // Load
            // 
            this.Load.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(231)))), ((int)(((byte)(227)))));
            this.Load.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Load.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Load.Location = new System.Drawing.Point(528, 147);
            this.Load.Margin = new System.Windows.Forms.Padding(2);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(232, 34);
            this.Load.TabIndex = 3;
            this.Load.Text = "Comprobar cadena";
            this.Load.UseVisualStyleBackColor = false;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // ShowAP
            // 
            this.ShowAP.Location = new System.Drawing.Point(107, 221);
            this.ShowAP.Multiline = true;
            this.ShowAP.Name = "ShowAP";
            this.ShowAP.Size = new System.Drawing.Size(653, 242);
            this.ShowAP.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(907, 491);
            this.Controls.Add(this.ShowAP);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.CadenaEntrante);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_archivo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Proyecto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_archivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox CadenaEntrante;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.TextBox ShowAP;
    }
}

