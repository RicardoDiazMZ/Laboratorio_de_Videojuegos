namespace LIVE_DEMO
{
    partial class MAIN_FORM
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
            this.PCT_CANVAS = new System.Windows.Forms.PictureBox();
            this.PlayButton = new System.Windows.Forms.Button();
            this.TIMER = new System.Windows.Forms.Timer(this.components);
            this.OpenButton = new System.Windows.Forms.Button();
            this.OpenObj = new System.Windows.Forms.OpenFileDialog();
            this.RecordButton = new System.Windows.Forms.Button();
            this.Tree = new System.Windows.Forms.TreeView();
            this.TB_Trans_X = new System.Windows.Forms.TrackBar();
            this.X_L = new System.Windows.Forms.Label();
            this.TB_Trans_Y = new System.Windows.Forms.TrackBar();
            this.Y_L = new System.Windows.Forms.Label();
            this.Z_L = new System.Windows.Forms.Label();
            this.TB_Trans_Z = new System.Windows.Forms.TrackBar();
            this.RotateCB = new System.Windows.Forms.CheckBox();
            this.TranslateCB = new System.Windows.Forms.CheckBox();
            this.ScaleCB = new System.Windows.Forms.CheckBox();
            this.Time_L = new System.Windows.Forms.Label();
            this.TB_TIME = new System.Windows.Forms.TrackBar();
            this.Info = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Trans_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Trans_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Trans_Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_TIME)).BeginInit();
            this.SuspendLayout();
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PCT_CANVAS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.PCT_CANVAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCT_CANVAS.Location = new System.Drawing.Point(213, 84);
            this.PCT_CANVAS.Margin = new System.Windows.Forms.Padding(4);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(1204, 757);
            this.PCT_CANVAS.TabIndex = 0;
            this.PCT_CANVAS.TabStop = false;
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.PlayButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.PlayButton.ForeColor = System.Drawing.Color.White;
            this.PlayButton.Location = new System.Drawing.Point(13, 725);
            this.PlayButton.Margin = new System.Windows.Forms.Padding(4);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(135, 45);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.BTN_EXE_Click);
            // 
            // TIMER
            // 
            this.TIMER.Enabled = true;
            this.TIMER.Interval = 60;
            this.TIMER.Tick += new System.EventHandler(this.TIMER_Tick);
            // 
            // OpenButton
            // 
            this.OpenButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.OpenButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.OpenButton.ForeColor = System.Drawing.Color.White;
            this.OpenButton.Location = new System.Drawing.Point(13, 675);
            this.OpenButton.Margin = new System.Windows.Forms.Padding(4);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(135, 45);
            this.OpenButton.TabIndex = 18;
            this.OpenButton.Text = "Open .obj";
            this.OpenButton.UseVisualStyleBackColor = false;
            this.OpenButton.Click += new System.EventHandler(this.openFile_Click);
            // 
            // OpenObj
            // 
            this.OpenObj.FileName = "Open obj";
            this.OpenObj.Filter = "Archivos OBJ|*.obj";
            // 
            // RecordButton
            // 
            this.RecordButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.RecordButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.RecordButton.ForeColor = System.Drawing.Color.White;
            this.RecordButton.Location = new System.Drawing.Point(13, 775);
            this.RecordButton.Margin = new System.Windows.Forms.Padding(4);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(135, 45);
            this.RecordButton.TabIndex = 19;
            this.RecordButton.Text = "Record State";
            this.RecordButton.UseVisualStyleBackColor = false;
            this.RecordButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Tree
            // 
            this.Tree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.Tree.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Tree.ForeColor = System.Drawing.Color.White;
            this.Tree.Location = new System.Drawing.Point(13, 84);
            this.Tree.Margin = new System.Windows.Forms.Padding(4);
            this.Tree.Name = "Tree";
            this.Tree.Size = new System.Drawing.Size(194, 450);
            this.Tree.TabIndex = 20;
            this.Tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TREE_AfterSelect);
            // 
            // TB_Trans_X
            // 
            this.TB_Trans_X.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TB_Trans_X.Location = new System.Drawing.Point(215, 923);
            this.TB_Trans_X.Margin = new System.Windows.Forms.Padding(4);
            this.TB_Trans_X.Maximum = 15;
            this.TB_Trans_X.Minimum = -15;
            this.TB_Trans_X.Name = "TB_Trans_X";
            this.TB_Trans_X.Size = new System.Drawing.Size(1709, 56);
            this.TB_Trans_X.TabIndex = 21;
            this.TB_Trans_X.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // X_L
            // 
            this.X_L.AutoSize = true;
            this.X_L.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.X_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X_L.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.X_L.Location = new System.Drawing.Point(993, 891);
            this.X_L.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.X_L.Name = "X_L";
            this.X_L.Size = new System.Drawing.Size(142, 29);
            this.X_L.TabIndex = 22;
            this.X_L.Text = "Translate X";
            // 
            // TB_Trans_Y
            // 
            this.TB_Trans_Y.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TB_Trans_Y.Location = new System.Drawing.Point(1928, 85);
            this.TB_Trans_Y.Margin = new System.Windows.Forms.Padding(4);
            this.TB_Trans_Y.Minimum = -10;
            this.TB_Trans_Y.Name = "TB_Trans_Y";
            this.TB_Trans_Y.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TB_Trans_Y.Size = new System.Drawing.Size(56, 895);
            this.TB_Trans_Y.TabIndex = 23;
            this.TB_Trans_Y.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Y_L
            // 
            this.Y_L.AutoSize = true;
            this.Y_L.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Y_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Y_L.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Y_L.Location = new System.Drawing.Point(1874, 46);
            this.Y_L.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Y_L.Name = "Y_L";
            this.Y_L.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Y_L.Size = new System.Drawing.Size(141, 29);
            this.Y_L.TabIndex = 24;
            this.Y_L.Text = "Translate Y";
            // 
            // Z_L
            // 
            this.Z_L.AutoSize = true;
            this.Z_L.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.Z_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Z_L.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Z_L.Location = new System.Drawing.Point(993, 799);
            this.Z_L.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Z_L.Name = "Z_L";
            this.Z_L.Size = new System.Drawing.Size(140, 29);
            this.Z_L.TabIndex = 26;
            this.Z_L.Text = "Translate Z";
            // 
            // TB_Trans_Z
            // 
            this.TB_Trans_Z.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TB_Trans_Z.Location = new System.Drawing.Point(215, 832);
            this.TB_Trans_Z.Margin = new System.Windows.Forms.Padding(4);
            this.TB_Trans_Z.Maximum = 15;
            this.TB_Trans_Z.Minimum = -15;
            this.TB_Trans_Z.Name = "TB_Trans_Z";
            this.TB_Trans_Z.Size = new System.Drawing.Size(1709, 56);
            this.TB_Trans_Z.TabIndex = 25;
            this.TB_Trans_Z.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // RotateCB
            // 
            this.RotateCB.AutoSize = true;
            this.RotateCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotateCB.ForeColor = System.Drawing.Color.White;
            this.RotateCB.Location = new System.Drawing.Point(21, 599);
            this.RotateCB.Margin = new System.Windows.Forms.Padding(4);
            this.RotateCB.Name = "RotateCB";
            this.RotateCB.Size = new System.Drawing.Size(90, 29);
            this.RotateCB.TabIndex = 27;
            this.RotateCB.Text = "Rotate";
            this.RotateCB.UseVisualStyleBackColor = true;
            this.RotateCB.CheckedChanged += new System.EventHandler(this.CB_ROTATE_CheckedChanged);
            // 
            // TranslateCB
            // 
            this.TranslateCB.AutoSize = true;
            this.TranslateCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TranslateCB.ForeColor = System.Drawing.Color.White;
            this.TranslateCB.Location = new System.Drawing.Point(21, 566);
            this.TranslateCB.Margin = new System.Windows.Forms.Padding(4);
            this.TranslateCB.Name = "TranslateCB";
            this.TranslateCB.Size = new System.Drawing.Size(116, 29);
            this.TranslateCB.TabIndex = 28;
            this.TranslateCB.Text = "Translate";
            this.TranslateCB.UseVisualStyleBackColor = true;
            this.TranslateCB.CheckedChanged += new System.EventHandler(this.CB_TRANSLATE_CheckedChanged);
            // 
            // ScaleCB
            // 
            this.ScaleCB.AutoSize = true;
            this.ScaleCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScaleCB.ForeColor = System.Drawing.Color.White;
            this.ScaleCB.Location = new System.Drawing.Point(21, 632);
            this.ScaleCB.Margin = new System.Windows.Forms.Padding(4);
            this.ScaleCB.Name = "ScaleCB";
            this.ScaleCB.Size = new System.Drawing.Size(84, 29);
            this.ScaleCB.TabIndex = 29;
            this.ScaleCB.Text = "Scale";
            this.ScaleCB.UseVisualStyleBackColor = true;
            this.ScaleCB.CheckedChanged += new System.EventHandler(this.CB_SCALE_CheckedChanged);
            // 
            // Time_L
            // 
            this.Time_L.AutoSize = true;
            this.Time_L.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Time_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time_L.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Time_L.Location = new System.Drawing.Point(1030, 46);
            this.Time_L.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Time_L.Name = "Time_L";
            this.Time_L.Size = new System.Drawing.Size(70, 29);
            this.Time_L.TabIndex = 31;
            this.Time_L.Text = "Time";
            // 
            // TB_TIME
            // 
            this.TB_TIME.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TB_TIME.Location = new System.Drawing.Point(215, 85);
            this.TB_TIME.Margin = new System.Windows.Forms.Padding(4);
            this.TB_TIME.Maximum = 100;
            this.TB_TIME.Name = "TB_TIME";
            this.TB_TIME.Size = new System.Drawing.Size(1709, 56);
            this.TB_TIME.TabIndex = 30;
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Info.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Info.Location = new System.Drawing.Point(20, 842);
            this.Info.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(113, 32);
            this.Info.TabIndex = 33;
            this.Info.Text = "Welcome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.label3.Font = new System.Drawing.Font("Arial", 31.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(348, 60);
            this.label3.TabIndex = 34;
            this.label3.Text = "MASH-UP 3D";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2500, 79);
            this.panel1.TabIndex = 35;
            // 
            // MAIN_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.Time_L);
            this.Controls.Add(this.TB_TIME);
            this.Controls.Add(this.ScaleCB);
            this.Controls.Add(this.TranslateCB);
            this.Controls.Add(this.RotateCB);
            this.Controls.Add(this.Z_L);
            this.Controls.Add(this.TB_Trans_Z);
            this.Controls.Add(this.Y_L);
            this.Controls.Add(this.TB_Trans_Y);
            this.Controls.Add(this.X_L);
            this.Controls.Add(this.TB_Trans_X);
            this.Controls.Add(this.Tree);
            this.Controls.Add(this.RecordButton);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.PCT_CANVAS);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MAIN_FORM";
            this.Text = "DEMO";
            this.Load += new System.EventHandler(this.MAIN_FORM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Trans_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Trans_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Trans_Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_TIME)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PCT_CANVAS;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Timer TIMER;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.OpenFileDialog OpenObj;
        private System.Windows.Forms.Button RecordButton;
        private System.Windows.Forms.TreeView Tree;
        private System.Windows.Forms.TrackBar TB_Trans_X;
        private System.Windows.Forms.Label X_L;
        private System.Windows.Forms.TrackBar TB_Trans_Y;
        private System.Windows.Forms.Label Y_L;
        private System.Windows.Forms.Label Z_L;
        private System.Windows.Forms.TrackBar TB_Trans_Z;
        private System.Windows.Forms.CheckBox RotateCB;
        private System.Windows.Forms.CheckBox TranslateCB;
        private System.Windows.Forms.CheckBox ScaleCB;
        private System.Windows.Forms.Label Time_L;
        private System.Windows.Forms.TrackBar TB_TIME;
        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
    }
}

