namespace TurneroMedicos.Forms
{
  partial class FrmMainMedico
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
      this.LblLegajo = new System.Windows.Forms.Label();
      this.GrdPacientesMedico = new System.Windows.Forms.DataGridView();
      this.monthCalendarMedico = new System.Windows.Forms.MonthCalendar();
      this.LblBienvenida = new System.Windows.Forms.Label();
      this.BtnBuscar = new System.Windows.Forms.Button();
      this.BtnHistoriaClinica = new System.Windows.Forms.Button();
      this.BtnAtendido = new System.Windows.Forms.Button();
      this.BtnRefrescar = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.GrdPacientesMedico)).BeginInit();
      this.SuspendLayout();
      // 
      // LblLegajo
      // 
      this.LblLegajo.AutoSize = true;
      this.LblLegajo.Location = new System.Drawing.Point(12, 37);
      this.LblLegajo.Name = "LblLegajo";
      this.LblLegajo.Size = new System.Drawing.Size(35, 13);
      this.LblLegajo.TabIndex = 0;
      this.LblLegajo.Text = "label1";
      this.LblLegajo.Visible = false;
      // 
      // GrdPacientesMedico
      // 
      this.GrdPacientesMedico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.GrdPacientesMedico.Location = new System.Drawing.Point(219, 59);
      this.GrdPacientesMedico.Name = "GrdPacientesMedico";
      this.GrdPacientesMedico.Size = new System.Drawing.Size(569, 275);
      this.GrdPacientesMedico.TabIndex = 1;
      // 
      // monthCalendarMedico
      // 
      this.monthCalendarMedico.Location = new System.Drawing.Point(15, 59);
      this.monthCalendarMedico.Name = "monthCalendarMedico";
      this.monthCalendarMedico.TabIndex = 2;
      // 
      // LblBienvenida
      // 
      this.LblBienvenida.AutoSize = true;
      this.LblBienvenida.Location = new System.Drawing.Point(12, 9);
      this.LblBienvenida.Name = "LblBienvenida";
      this.LblBienvenida.Size = new System.Drawing.Size(35, 13);
      this.LblBienvenida.TabIndex = 3;
      this.LblBienvenida.Text = "label1";
      // 
      // BtnBuscar
      // 
      this.BtnBuscar.Location = new System.Drawing.Point(15, 375);
      this.BtnBuscar.Name = "BtnBuscar";
      this.BtnBuscar.Size = new System.Drawing.Size(75, 23);
      this.BtnBuscar.TabIndex = 4;
      this.BtnBuscar.Text = "Buscar";
      this.BtnBuscar.UseVisualStyleBackColor = true;
      this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
      // 
      // BtnHistoriaClinica
      // 
      this.BtnHistoriaClinica.Location = new System.Drawing.Point(219, 375);
      this.BtnHistoriaClinica.Name = "BtnHistoriaClinica";
      this.BtnHistoriaClinica.Size = new System.Drawing.Size(101, 23);
      this.BtnHistoriaClinica.TabIndex = 5;
      this.BtnHistoriaClinica.Text = "Historia Clinica";
      this.BtnHistoriaClinica.UseVisualStyleBackColor = true;
      this.BtnHistoriaClinica.Click += new System.EventHandler(this.BtnHistoriaClinica_Click);
      // 
      // BtnAtendido
      // 
      this.BtnAtendido.Location = new System.Drawing.Point(688, 375);
      this.BtnAtendido.Name = "BtnAtendido";
      this.BtnAtendido.Size = new System.Drawing.Size(100, 23);
      this.BtnAtendido.TabIndex = 6;
      this.BtnAtendido.Text = "Marcar Atendido";
      this.BtnAtendido.UseVisualStyleBackColor = true;
      this.BtnAtendido.Click += new System.EventHandler(this.BtnAtendido_Click);
      // 
      // BtnRefrescar
      // 
      this.BtnRefrescar.Location = new System.Drawing.Point(15, 335);
      this.BtnRefrescar.Name = "BtnRefrescar";
      this.BtnRefrescar.Size = new System.Drawing.Size(75, 23);
      this.BtnRefrescar.TabIndex = 7;
      this.BtnRefrescar.Text = "Refrescar";
      this.BtnRefrescar.UseVisualStyleBackColor = true;
      this.BtnRefrescar.Click += new System.EventHandler(this.BtnRefrescar_Click);
      // 
      // FrmMainMedico
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 412);
      this.Controls.Add(this.BtnRefrescar);
      this.Controls.Add(this.BtnAtendido);
      this.Controls.Add(this.BtnHistoriaClinica);
      this.Controls.Add(this.BtnBuscar);
      this.Controls.Add(this.LblBienvenida);
      this.Controls.Add(this.monthCalendarMedico);
      this.Controls.Add(this.GrdPacientesMedico);
      this.Controls.Add(this.LblLegajo);
      this.Name = "FrmMainMedico";
      this.Text = "FrmMainMedico";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMainMedico_FormClosing);
      this.Load += new System.EventHandler(this.FrmMainMedico_Load);
      ((System.ComponentModel.ISupportInitialize)(this.GrdPacientesMedico)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    protected internal System.Windows.Forms.Label LblLegajo;
    private System.Windows.Forms.DataGridView GrdPacientesMedico;
    private System.Windows.Forms.MonthCalendar monthCalendarMedico;
    protected internal System.Windows.Forms.Label LblBienvenida;
    private System.Windows.Forms.Button BtnBuscar;
    private System.Windows.Forms.Button BtnHistoriaClinica;
    private System.Windows.Forms.Button BtnAtendido;
    private System.Windows.Forms.Button BtnRefrescar;
  }
}