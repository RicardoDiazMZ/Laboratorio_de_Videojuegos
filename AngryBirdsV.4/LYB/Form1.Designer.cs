namespace LYB
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LBL_STATUS = new System.Windows.Forms.Label();
            this.TIMER = new System.Windows.Forms.Timer(this.components);
            this.PCT_CANVAS = new System.Windows.Forms.PictureBox();
            this.Dtimer = new System.Windows.Forms.Timer(this.components);
            this.CHK_GENERATE = new System.Windows.Forms.CheckBox();
            this.BTN_EXE = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            this.SuspendLayout();
            // 
            // LBL_STATUS
            // 
            this.LBL_STATUS.AutoSize = true;
            this.LBL_STATUS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(190)))), ((int)(((byte)(210)))));
            this.LBL_STATUS.Font = new System.Drawing.Font("Comic Sans MS", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_STATUS.ForeColor = System.Drawing.Color.Transparent;
            this.LBL_STATUS.Location = new System.Drawing.Point(1710, 25);
            this.LBL_STATUS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_STATUS.Name = "LBL_STATUS";
            this.LBL_STATUS.Size = new System.Drawing.Size(228, 65);
            this.LBL_STATUS.TabIndex = 2;
            this.LBL_STATUS.Text = "Score: 0";
            // 
            // TIMER
            // 
            this.TIMER.Enabled = true;
            this.TIMER.Interval = 15;
            this.TIMER.Tick += new System.EventHandler(this.TIMER_Tick);
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.PCT_CANVAS.BackgroundImage = global::LYB.Resource1.Background;
            this.PCT_CANVAS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PCT_CANVAS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PCT_CANVAS.Location = new System.Drawing.Point(0, 0);
            this.PCT_CANVAS.Margin = new System.Windows.Forms.Padding(4);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(1548, 662);
            this.PCT_CANVAS.TabIndex = 2;
            this.PCT_CANVAS.TabStop = false;
            this.PCT_CANVAS.UseWaitCursor = true;
            this.PCT_CANVAS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PCT_CANVAS_MouseClick);
            this.PCT_CANVAS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PCT_CANVAS_MouseDown);
            this.PCT_CANVAS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PCT_CANVAS_MouseMove);
            this.PCT_CANVAS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PCT_CANVAS_MouseUp);
            // 
            // Dtimer
            // 
            this.Dtimer.Tick += new System.EventHandler(this.Dtimer_Tick);
            // 
            // CHK_GENERATE
            // 
            this.CHK_GENERATE.AutoSize = true;
            this.CHK_GENERATE.Checked = true;
            this.CHK_GENERATE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_GENERATE.Enabled = false;
            this.CHK_GENERATE.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHK_GENERATE.ForeColor = System.Drawing.Color.Silver;
            this.CHK_GENERATE.Location = new System.Drawing.Point(159, 20);
            this.CHK_GENERATE.Margin = new System.Windows.Forms.Padding(4);
            this.CHK_GENERATE.Name = "CHK_GENERATE";
            this.CHK_GENERATE.Size = new System.Drawing.Size(171, 36);
            this.CHK_GENERATE.TabIndex = 1;
            this.CHK_GENERATE.Text = "GENERATE ";
            this.CHK_GENERATE.UseVisualStyleBackColor = true;
            this.CHK_GENERATE.Visible = false;
            // 
            // BTN_EXE
            // 
            this.BTN_EXE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BTN_EXE.FlatAppearance.BorderSize = 0;
            this.BTN_EXE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_EXE.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_EXE.ForeColor = System.Drawing.Color.White;
            this.BTN_EXE.Location = new System.Drawing.Point(13, 13);
            this.BTN_EXE.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_EXE.Name = "BTN_EXE";
            this.BTN_EXE.Size = new System.Drawing.Size(85, 85);
            this.BTN_EXE.TabIndex = 0;
            this.BTN_EXE.Text = "EXE";
            this.BTN_EXE.UseVisualStyleBackColor = false;
            this.BTN_EXE.Click += new System.EventHandler(this.BTN_EXE_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1548, 662);
            this.Controls.Add(this.CHK_GENERATE);
            this.Controls.Add(this.BTN_EXE);
            this.Controls.Add(this.LBL_STATUS);
            this.Controls.Add(this.PCT_CANVAS);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Angry Birds";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer TIMER;
        private System.Windows.Forms.Label LBL_STATUS;
        private System.Windows.Forms.PictureBox PCT_CANVAS;
        private System.Windows.Forms.Timer Dtimer;
        private System.Windows.Forms.CheckBox CHK_GENERATE;
        private System.Windows.Forms.Button BTN_EXE;
    }
}

