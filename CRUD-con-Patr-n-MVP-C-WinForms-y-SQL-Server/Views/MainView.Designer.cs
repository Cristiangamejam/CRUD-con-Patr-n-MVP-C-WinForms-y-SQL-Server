namespace CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Views
{
    partial class MainView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnPets = new System.Windows.Forms.Button();
            this.BtnPantalla = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnPantalla);
            this.panel1.Controls.Add(this.BtnPets);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 450);
            this.panel1.TabIndex = 0;
            // 
            // BtnPets
            // 
            this.BtnPets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPets.Location = new System.Drawing.Point(3, 32);
            this.BtnPets.Name = "BtnPets";
            this.BtnPets.Size = new System.Drawing.Size(194, 31);
            this.BtnPets.TabIndex = 0;
            this.BtnPets.Text = "Pets";
            this.BtnPets.UseVisualStyleBackColor = true;
            // 
            // BtnPantalla
            // 
            this.BtnPantalla.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPantalla.Location = new System.Drawing.Point(6, 80);
            this.BtnPantalla.Name = "BtnPantalla";
            this.BtnPantalla.Size = new System.Drawing.Size(194, 31);
            this.BtnPantalla.TabIndex = 1;
            this.BtnPantalla.Text = "Pantalla";
            this.BtnPantalla.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "MainView";
            this.Text = "MainView";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnPets;
        private System.Windows.Forms.Button BtnPantalla;
    }
}