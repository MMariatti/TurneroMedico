using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurneroMedicos.Classes;

namespace TurneroMedicos.Forms
{
  public partial class FrmLogin : Form
  {
    public FrmLogin()
    {
      InitializeComponent();
    }

    private string usuarioActual;
    private string contraseñaActual;
    private int rolActual;
    private int? legajoM;

    /* Metodos */

    private bool Loguear(string usuario, string contra)
    {
      DataTable tabla;
      string consulta = "SELECT usuario , contraseña, idRol, nMedico FROM Usuarios U WHERE " +
          "U.usuario = '" + usuario + "' AND U.contraseña = '" + contra + "' AND U.activo = 1";
      tabla = BDHelper.ConsultarSQL(consulta);
      if (tabla.Rows.Count == 0)
      {
        return false;
      }
      else
      {
        contraseñaActual = contra;
        usuarioActual = usuario;
        rolActual = (int)tabla.Rows[0]["idRol"];
        legajoM = (int?)tabla.Rows[0]["nMedico"];


        return true;
      }
    }

    /* Eventos */

    private void FrmLogin_Load(object sender, EventArgs e)
    {

    }

    private void BtnIniciarSesion_Click(object sender, EventArgs e)
    {
      if (TxtUsuario.Text == string.Empty || TxtContraseña.Text == string.Empty)
      {
        MessageBox.Show("Ingrese Usuario y/o Contrasena", "Error al Iniciar Sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {

        //Logueo con base de datos 
        if (Loguear(TxtUsuario.Text, TxtContraseña.Text))
        {
          Sesion sesion = new Sesion(usuarioActual, contraseñaActual, rolActual);

          //Logueo satisfactorio, creacion de instancia de menu principal 

          if (sesion.Rol == 3 && legajoM != null)
          {
            FrmMainMedico frmMainMedico = new FrmMainMedico();
            frmMainMedico.LblLegajo.Text = legajoM.ToString();
            frmMainMedico.Show();
          }
          
          else
          {
            MessageBox.Show("Error al iniciar sesion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          //Minimizacion del frmLogin y eliminacion del TaskBar 
          this.WindowState = FormWindowState.Minimized;
          this.ShowInTaskbar = false;
        }
      }
    }

    private void BtnSalir_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("¿Está seguro que desea cerrar la aplicacion?", "Cerrar Aplicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        Application.Exit();
      }
    }

    private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (MessageBox.Show("¿Está seguro que desea cerrar la aplicación?", "Cerrar Aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      
        e.Cancel = false;
      
      else
        e.Cancel = true;
    }
  }
  
}
