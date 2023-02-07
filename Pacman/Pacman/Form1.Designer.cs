namespace Pacman
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.player = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.G1 = new System.Windows.Forms.PictureBox();
            this.G2 = new System.Windows.Forms.PictureBox();
            this.G3 = new System.Windows.Forms.PictureBox();
            this.G4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.G1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.G2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.G3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.G4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(50, 50);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(760, 1000);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("ROG Fonts", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Score: 0 ";
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Enabled = false;
            this.player.Location = new System.Drawing.Point(416, 620);
            this.player.Margin = new System.Windows.Forms.Padding(4);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(20, 20);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.player.TabIndex = 2;
            this.player.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("ROG Fonts", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(290, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("ROG Fonts", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(481, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("ROG Fonts", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(568, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Total Score: 00000 ";
            // 
            // G1
            // 
            this.G1.BackColor = System.Drawing.Color.Transparent;
            this.G1.Enabled = false;
            this.G1.Location = new System.Drawing.Point(416, 303);
            this.G1.Margin = new System.Windows.Forms.Padding(4);
            this.G1.Name = "G1";
            this.G1.Size = new System.Drawing.Size(20, 20);
            this.G1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.G1.TabIndex = 6;
            this.G1.TabStop = false;
            // 
            // G2
            // 
            this.G2.BackColor = System.Drawing.Color.Transparent;
            this.G2.Enabled = false;
            this.G2.Location = new System.Drawing.Point(416, 364);
            this.G2.Margin = new System.Windows.Forms.Padding(4);
            this.G2.Name = "G2";
            this.G2.Size = new System.Drawing.Size(20, 20);
            this.G2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.G2.TabIndex = 7;
            this.G2.TabStop = false;
            // 
            // G3
            // 
            this.G3.BackColor = System.Drawing.Color.Transparent;
            this.G3.Enabled = false;
            this.G3.Location = new System.Drawing.Point(416, 392);
            this.G3.Margin = new System.Windows.Forms.Padding(4);
            this.G3.Name = "G3";
            this.G3.Size = new System.Drawing.Size(20, 20);
            this.G3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.G3.TabIndex = 8;
            this.G3.TabStop = false;
            // 
            // G4
            // 
            this.G4.BackColor = System.Drawing.Color.Transparent;
            this.G4.Enabled = false;
            this.G4.Location = new System.Drawing.Point(416, 407);
            this.G4.Margin = new System.Windows.Forms.Padding(4);
            this.G4.Name = "G4";
            this.G4.Size = new System.Drawing.Size(20, 20);
            this.G4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.G4.TabIndex = 9;
            this.G4.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(862, 1055);
            this.Controls.Add(this.G4);
            this.Controls.Add(this.G3);
            this.Controls.Add(this.G2);
            this.Controls.Add(this.G1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.player);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.G1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.G2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.G3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.G4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox G1;
        private System.Windows.Forms.PictureBox G2;
        private System.Windows.Forms.PictureBox G3;
        private System.Windows.Forms.PictureBox G4;
    }
}

