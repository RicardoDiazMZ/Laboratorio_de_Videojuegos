namespace Tarea1;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    /// 
    private Label Label1;
    private Label Label2;
    private Label Label3;

    private void InitializeComponent()
    {
        this.Label1 = new System.Windows.Forms.Label();
        this.Label2 = new System.Windows.Forms.Label();
        this.Label3 = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // Label1
        this.Label1.AutoSize = true;
        this.Label1.Text = "Nombre: Ricardo Díaz Méndez";
        this.Label1.BackColor = System.Drawing.Color.WhiteSmoke;
        this.Label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.Label1.Location = new System.Drawing.Point(235, 100);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(279, 28);
        // Label2
        this.Label2.AutoSize = true;
        this.Label2.Text = "ID: 166435";
        this.Label2.BackColor = System.Drawing.Color.WhiteSmoke;
        this.Label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.Label2.Location = new System.Drawing.Point(320, 135);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(106, 28);
        this.Label2.TabIndex = 1;
        // Label3
        this.Label3.AutoSize = true;
        this.Label3.Text = "Graficación y videojuegos";
        this.Label3.BackColor = System.Drawing.Color.WhiteSmoke;
        this.Label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.Label3.Location = new System.Drawing.Point(255, 200);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(237, 28);
        this.Label3.TabIndex = 2;
        // Form
        this.Location = new System.Drawing.Point(32, 32);
        this.Size = new System.Drawing.Size(750, 450);
        this.Text = "Tarea 1";
        this.Name = "Tarea 1";
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.Label2);
        this.Controls.Add(this.Label3);
        this.ResumeLayout(false);
    }

    #endregion
}
