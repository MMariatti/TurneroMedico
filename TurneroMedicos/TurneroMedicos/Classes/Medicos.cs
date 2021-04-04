using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurneroMedicos.Classes;

namespace TurneroMedicos.Classes
{
  public class Medicos
  {
    private int idMedico = 0;
    public int IdMedico
    {
      get
      {
        return this.idMedico;
      }

      private set
      {
        this.idMedico = value;
      }
    }
    //Forzamos que los parametros sean privados para que una vez creados solo puedan ser modificados por la misma clase
    private string nombre = "";
    //Creamos Properties que definen los get y set de cada atributo, manteniendo el set privado para que todo el comportamiento quede dentro de la clase
    //y no exista posibilidad de manipulacion maliciosa de datos.
    public string Nombre
    {
      get { return this.nombre; }
      private set
      {
        if (!string.IsNullOrWhiteSpace(value))
        {
          this.nombre = value;
        }
        else
        {
          throw new ArgumentNullException();
        }
      }
    }
    private string apellido = "";
    public string Apellido
    {
      get { return this.apellido; }
      private set
      {
        if (!string.IsNullOrWhiteSpace(value))
        {
          this.apellido = value;
        }
        else
        {
          throw new ArgumentNullException();
        }
      }
    }
    private int idEspecialidad = 0;
    public int Especialidad
    {
      get { return this.idEspecialidad; }
      private set
      {
        if (value >= 0)
        {
          this.idEspecialidad = value;
        }
        else
        {
          throw new ArgumentNullException();
        }
      }
    }

    private double porcentajeDesc = 0;

    public double PorcentajeDesc

    {
      get { return this.porcentajeDesc; }
      private set
      {
        if (value >= 0)
        {
          this.porcentajeDesc = value;
        }
        else
        {
          throw new ArgumentNullException();
        }
      }
    }

    DateTime horaInicio = new DateTime();
    DateTime horaFin = new DateTime();

    private int minutosIntervalo = 0;
    public int MinutosIntervalo
    {
      get { return this.minutosIntervalo; }
      private set
      {
        if (value >= 0)
        {
          this.minutosIntervalo = value;
        }

        else
        {
          throw new ArgumentException();
        }
      }
    }




    public Medicos()
    {

    }

    public Medicos(string apellidoMedico, string nombreMedico, int idEspecialidad, DateTime horaInicio, DateTime horaFin, int minIntervalo, double porcDesc)
    {

      this.Nombre = nombreMedico;
      this.Apellido = apellidoMedico;
      this.Especialidad = idEspecialidad;
      this.horaInicio = horaInicio;
      this.horaFin = horaFin;
      this.MinutosIntervalo = minIntervalo;
      this.PorcentajeDesc = porcDesc;


    }

    public Medicos(int idMedico)
    {
      this.IdMedico = idMedico;
      getAttr();
    }


    private void getAttr()
    {
      string query = "SELECT * FROM Medicos WHERE legajo = " + IdMedico + "";
      DataTable tabla = BDHelper.ConsultarSQL(query);
      Nombre = tabla.Rows[0]["nombre"].ToString();
      Apellido = tabla.Rows[0]["apellido"].ToString();
      Especialidad = (int)tabla.Rows[0]["idEspecialidad"];
      horaInicio = DateTime.Parse(tabla.Rows[0]["horaInicioAtencion"].ToString());
      horaFin = DateTime.Parse(tabla.Rows[0]["horaFinAtencion"].ToString());
      minutosIntervalo = (int)tabla.Rows[0]["intervaloTurnos"];
      PorcentajeDesc = Convert.ToDouble(tabla.Rows[0]["porcentajeDescuento"]);

    }


    public void Save()
    {
      try
      {
        string query = "INSERT INTO Medicos(apellido, nombre, idEspecialidad, horaInicioAtencion, horaFinAtencion, intervaloTurnos, porcentajeDescuento) " + "VALUES('" + this.Apellido + "','" + this.Nombre + "', " + this.Especialidad + ", '" + this.horaInicio.ToString("HH:mm:ss") + "','" + this.horaFin.ToString("HH:mm:ss") + "'," + this.MinutosIntervalo + "," + this.PorcentajeDesc + ")";
        BDHelper.ConsultarSQL(query);

      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public static DataTable GetAll()
    {
      DataTable tabla = new DataTable();
      string query = "SELECT * FROM Medicos";
      try
      {
        tabla = BDHelper.ConsultarSQL(query);
        return tabla;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Data.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return tabla;
      }
    }

    public static DataTable GetAllEspecifico()
    {
      DataTable tabla = new DataTable();
      string query = "SELECT M.legajo AS Legajo, M.apellido AS Apellido, M.nombre AS Nombre, E.descripcion AS Especialidad,M.horaInicioAtencion AS Inicio, M.horaFinAtencion AS Fin, M.intervaloTurnos AS Intervalo, M.porcentajeDescuento AS Comision FROM Medicos M , Especialidades E WHERE M.idEspecialidad = E.idEspecialidad";
      try
      {
        tabla = BDHelper.ConsultarSQL(query);
        return tabla;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Data.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return tabla;
      }
    }


    public Medicos GetMedico(int idM)
    {
      string query = "SELECT * FROM Medicos WHERE legajo = " + idM;
      DataTable tabla = BDHelper.ConsultarSQL(query);
      DataRowCollection filas = tabla.Rows;
      DataRow fila = filas[0];
      Medicos medico = new Medicos(fila.Field<string>("nombre"), fila.Field<string>("apellido"), fila.Field<int>("idEspecialidad"), fila.Field<DateTime>("horaInicioAtencion"), fila.Field<DateTime>("horaFinAtencion"), fila.Field<int>("intervaloTurnos"), fila.Field<double>("porcentajeDescuento"));
      return medico;
    }

    public void ActualizarMedico(string nombre, string apellido, int especialidad, DateTime horaI, DateTime horaF, int minIntervalo, double porcDesc)
    {
      try
      {
        string query = "UPDATE Medicos SET nombre = '" + nombre + "', apellido = '" + apellido + "', idEspecialidad=" + especialidad + ",horaInicioAtencion = '" + horaI.ToString("HH:mm:ss") + "', horaFinAtencion = '" + horaF.ToString("HH:mm:ss") + "', intervaloTurnos = " + minIntervalo + " , porcentajeDescuento=" + porcDesc + " WHERE legajo = " + this.IdMedico + " ";
        BDHelper.ConsultarSQL(query);
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Especialidad = especialidad;
        this.horaInicio = horaI;
        this.horaFin = horaF;
        this.MinutosIntervalo = minIntervalo;
        this.PorcentajeDesc = porcDesc;

        MessageBox.Show("Datos del medico actualizados con exito", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);

      }

      catch (Exception ex)
      {
        MessageBox.Show(ex.Data.ToString(), "Error al actualizar datos del medico", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

    }



    public void CambiarNombre(string newNombre)
    {
      try
      {
        string query = "UPDATE Medicos SET nombre = '" + newNombre + "' WHERE legajo = " + this.IdMedico + " ";
        BDHelper.ConsultarSQL(query);
        this.Nombre = newNombre;
        MessageBox.Show("Nombre cambiado con exito", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Data.ToString(), "Error al cambiar nombre", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public void CambiarApellido(string newApellido)
    {
      try
      {
        string query = "UPDATE Medicos SET apellido = '" + newApellido + "' WHERE legajo = " + this.IdMedico + "";
        BDHelper.ConsultarSQL(query);
        MessageBox.Show("Apellido cambiado con exito", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.Apellido = newApellido;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Data.ToString(), "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public void CambiarEspecialidad(int newEspecialidad)
    {
      try
      {
        string query = "UPDATE Medicos SET idEspecialidad = " + newEspecialidad + " WHERE legajo = " + this.IdMedico + "";
        BDHelper.ConsultarSQL(query);
        MessageBox.Show("Especialidad cambiado con exito", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Data.ToString(), "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public void BorrarMedico()
    {
      string query = "DELETE FROM Medicos WHERE legajo = " + IdMedico + " ";
      try
      {
        BDHelper.ConsultarSQL(query);
        MessageBox.Show("Medico borrado", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
        MessageBox.Show("Primero borre todos los turnos que ha tenido y/o tiene el medico", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }


    }
  }
}