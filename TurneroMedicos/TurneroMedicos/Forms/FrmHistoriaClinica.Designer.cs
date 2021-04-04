namespace TurneroMedicos.Forms
{
  partial class FrmHistoriaClinica
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
      this.label1 = new System.Windows.Forms.Label();
      this.TxtDni = new System.Windows.Forms.TextBox();
      this.RtbHistoriaClinica = new System.Windows.Forms.RichTextBox();
      this.BtnGuardar = new System.Windows.Forms.Button();
      this.BtnBuscar = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(35, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(23, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Dni";
      // 
      // TxtDni
      // 
      this.TxtDni.Location = new System.Drawing.Point(74, 12);
      this.TxtDni.Name = "TxtDni";
      this.TxtDni.Size = new System.Drawing.Size(176, 20);
      this.TxtDni.TabIndex = 1;
      // 
      // RtbHistoriaClinica
      // 
      this.RtbHistoriaClinica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.RtbHistoriaClinica.Location = new System.Drawing.Point(12, 38);
      this.RtbHistoriaClinica.Name = "RtbHistoriaClinica";
      this.RtbHistoriaClinica.Size = new System.Drawing.Size(776, 354);
      this.RtbHistoriaClinica.TabIndex = 3;
      this.RtbHistoriaClinica.Text = "";
      // 
      // BtnGuardar
      // 
      this.BtnGuardar.Location = new System.Drawing.Point(12, 398);
      this.BtnGuardar.Name = "BtnGuardar";
      this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
      this.BtnGuardar.TabIndex = 4;
      this.BtnGuardar.Text = "Guardar";
      this.BtnGuardar.UseVisualStyleBackColor = true;
      this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
      // 
      // BtnBuscar
      // 
      this.BtnBuscar.Location = new System.Drawing.Point(713, 5);
      this.BtnBuscar.Name = "BtnBuscar";
      this.BtnBuscar.Size = new System.Drawing.Size(75, 23);
      this.BtnBuscar.TabIndex = 2;
      this.BtnBuscar.Text = "Buscar";
      this.BtnBuscar.UseVisualStyleBackColor = true;
      this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
      // 
      // FrmHistoriaClinica
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.BtnBuscar);
      this.Controls.Add(this.BtnGuardar);
      this.Controls.Add(this.RtbHistoriaClinica);
      this.Controls.Add(this.TxtDni);
      this.Controls.Add(this.label1);
      this.Name = "FrmHistoriaClinica";
      this.Text = "FrmHistoriaClinica";
      this.Load += new System.EventHandler(this.FrmHistoriaClinica_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.RichTextBox RtbHistoriaClinica;
    private System.Windows.Forms.Button BtnGuardar;
    protected internal System.Windows.Forms.TextBox TxtDni;
    private System.Windows.Forms.Button BtnBuscar;
  }
}