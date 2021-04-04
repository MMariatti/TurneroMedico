namespace TurneroMedicos.Forms
{
  partial class FrmLogin
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
      this.label1 = new System.Windows.Forms.Label();
      this.TxtUsuario = new System.Windows.Forms.TextBox();
      this.BtnIniciarSesion = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.TxtContraseña = new System.Windows.Forms.TextBox();
      this.BtnSalir = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(36, 75);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(46, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Usuario:";
      // 
      // TxtUsuario
      // 
      this.TxtUsuario.Location = new System.Drawing.Point(110, 72);
      this.TxtUsuario.Name = "TxtUsuario";
      this.TxtUsuario.Size = new System.Drawing.Size(134, 20);
      this.TxtUsuario.TabIndex = 0;
      // 
      // BtnIniciarSesion
      // 
      this.BtnIniciarSesion.Location = new System.Drawing.Point(39, 194);
      this.BtnIniciarSesion.Name = "BtnIniciarSesion";
      this.BtnIniciarSesion.Size = new System.Drawing.Size(106, 23);
      this.BtnIniciarSesion.TabIndex = 2;
      this.BtnIniciarSesion.Text = "Iniciar Sesion";
      this.BtnIniciarSesion.UseVisualStyleBackColor = true;
      this.BtnIniciarSesion.Click += new System.EventHandler(this.BtnIniciarSesion_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(36, 130);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(64, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Contraseña:";
      // 
      // TxtContraseña
      // 
      this.TxtContraseña.Location = new System.Drawing.Point(110, 127);
      this.TxtContraseña.Name = "TxtContraseña";
      this.TxtContraseña.PasswordChar = '*';
      this.TxtContraseña.Size = new System.Drawing.Size(134, 20);
      this.TxtContraseña.TabIndex = 1;
      // 
      // BtnSalir
      // 
      this.BtnSalir.Location = new System.Drawing.Point(169, 194);
      this.BtnSalir.Name = "BtnSalir";
      this.BtnSalir.Size = new System.Drawing.Size(75, 23);
      this.BtnSalir.TabIndex = 3;
      this.BtnSalir.Text = "Salir";
      this.BtnSalir.UseVisualStyleBackColor = true;
      this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
      // 
      // FrmLogin
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(279, 267);
      this.Controls.Add(this.BtnSalir);
      this.Controls.Add(this.TxtContraseña);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.BtnIniciarSesion);
      this.Controls.Add(this.TxtUsuario);
      this.Controls.Add(this.label1);
      this.Name = "FrmLogin";
      this.Text = "Form1";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);
      this.Load += new System.EventHandler(this.FrmLogin_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox TxtUsuario;
    private System.Windows.Forms.Button BtnIniciarSesion;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox TxtContraseña;
    private System.Windows.Forms.Button BtnSalir;
  }
}

