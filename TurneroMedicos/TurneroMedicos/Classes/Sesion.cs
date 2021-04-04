using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace TurneroMedicos.Classes
{
  class Sesion
  {
    private string usuario = "";
    public string Usuario
    {
      get { return this.usuario; }
      private set
      {
        if (!string.IsNullOrWhiteSpace(value))
        {
          this.usuario = value;
        }
        else
        {
          throw new ArgumentNullException();
        }
      }
    }
    private string contraseña = "";
    public string Contraseña
    {
      get { return this.contraseña; }
      private set
      {
        if (!string.IsNullOrWhiteSpace(value))
        {
          this.contraseña = value;
        }
        else
        {
          throw new ArgumentNullException();
        }
      }
    }
    private int rol = 0;
    public int Rol
    {
      get
      {
        return this.rol;
      }

      private set
      {
        this.rol = value;
      }
    }

    private int? legajoMedico;
    public int? LegajoMedico
    {
      get { return this.legajoMedico; }
      private set
      {
        this.legajoMedico = value;
      }
    }
    public Sesion() { }

    public Sesion(string usuario, string contraseña)
    {
      this.Usuario = usuario;
      this.Contraseña = contraseña;
    }

    public Sesion(string usuario, string contraseña, int rol)
    {
      this.Usuario = usuario;
      this.Contraseña = contraseña;
      this.Rol = rol;
    }
    public Sesion(string usuario, string contraseña, int rol, int? legajoMedico)
    {
      this.Usuario = usuario;
      this.Contraseña = contraseña;
      this.Rol = rol;
      this.LegajoMedico = legajoMedico;
    }

    public DataTable Login()
    {
      DataTable tabla = new DataTable();
      try
      {

        string query = "SELECT usuario, contraseña, idRol, Activo, nMedico FROM Usuarios WHERE usuario = '" + this.Usuario +
          "' AND contraseña ='" + this.Contraseña + "AND activo=1 ";
        tabla = BDHelper.ConsultarSQL(query);
        return tabla;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Data.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return tabla;
      }
    }
  }


}
