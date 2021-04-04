using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TurneroMedicos.Classes;
using System.Windows.Forms;

namespace TurneroMedicos.Classes
{
  class Turnos
  {
    public DateTime fechaTurno = new DateTime();
    public DateTime horaTurno = new DateTime();

    private int legajoMedico = 0;

    public int LegajoMedico
    {
      get { return this.legajoMedico; }
      private set
      {
        this.legajoMedico = value;

      }
    }

    private string dniPaciente = "";

    public string DniPaciente
    {
      get { return this.dniPaciente; }
      private set
      {
        if (!string.IsNullOrWhiteSpace(value))
        {
          this.dniPaciente = value;
        }
        else
        {
          throw new ArgumentNullException();
        }
      }
    }
    private int idEspecialidad = 0;
    public int IdEspecialidad
    {
      get { return this.idEspecialidad; }
      private set
      {
        this.idEspecialidad = value;
      }
    }

    private int practica = 0;
    public int Practica
    {
      get { return this.practica; }
      private set
      {
        this.practica = value;
      }
    }

    private int obraSocial = 0;
    public int ObraSocial
    {
      get { return this.obraSocial; }
      private set
      {
        this.obraSocial = value;
      }
    }

    private int confirmado = 0;
    public int Confirmado
    {
      get { return this.confirmado; }
      private set
      {
        this.confirmado = value;

      }
    }

    private int atendido = 0;
    public int Atendido
    {
      get { return this.atendido; }
      private set
      {
        this.atendido = value;
      }
    }

    public Turnos()
    {

    }

    public Turnos(DateTime fechaTurno, DateTime horaTurno, int legajoMedico, string dniPaciente, int idEspecialidad, int practica, int obraSocial)
    {
      this.fechaTurno = fechaTurno;
      this.horaTurno = horaTurno;
      this.LegajoMedico = legajoMedico;
      this.DniPaciente = dniPaciente;
      this.IdEspecialidad = idEspecialidad;
      this.Practica = practica;
      this.ObraSocial = obraSocial;
    }

    public Turnos(DateTime fechaTurno, DateTime horaTurno, int legajoMedico)
    {
      this.fechaTurno = fechaTurno;
      this.horaTurno = horaTurno;
      this.LegajoMedico = legajoMedico;
    }

    private void GetAll()
    {
      string query = "SELECT * FROM Turnos";
      DataTable tabla = BDHelper.ConsultarSQL(query);
      fechaTurno = DateTime.Parse(tabla.Rows[0]["fecha"].ToString());
      horaTurno = DateTime.Parse(tabla.Rows[0]["hora"].ToString());

      this.LegajoMedico = (int)tabla.Rows[0]["medico"];
      this.IdEspecialidad = (int)tabla.Rows[0]["idEspecialidad"];
      this.DniPaciente = tabla.Rows[0]["paciente"].ToString();
      this.Practica = (int)tabla.Rows[0]["idPractica"];
      this.ObraSocial = (int)tabla.Rows[0]["obraSocial"];
    }

    public static DataTable GetAllEspecifico(DateTime fechaDelDia)
    {
      DataTable tabla = new DataTable();
      string query = "SELECT T.fecha AS 'Fecha', T.hora AS 'Hora', M.apellido AS 'Medico',E.descripcion as 'Especialidad',X.descripcion AS 'Practica', P.apellido AS 'Apellido',P.nombre AS 'Nombre',P.dni AS'DNI',P.telefono AS'Telefono', O.descripcion AS 'Obra Social',T.medico, T.confirmado, T.atendido " +
        "FROM Pacientes P, ObrasSociales O, Medicos M, Especialidades E, Practicas X, Turnos T " +
        "WHERE T.medico = M.legajo AND T.obraSocial = O.idObraSocial AND T.paciente = P.dni AND T.idEspecialidad = E.idEspecialidad AND T.idPractica = X.idPractica AND T.fecha = '" + fechaDelDia + "'";
      try
      {
        tabla = BDHelper.ConsultarSQL(query);
        return tabla;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return tabla;
      }
    }


    public static DataTable GetTurnosDelDia()
    {
      DataTable tabla = new DataTable();
      string query = "SELECT T.fecha AS 'Fecha', T.hora AS 'Hora', M.apellido AS 'Medico',E.descripcion as 'Especialidad',X.descripcion AS 'Practica', P.apellido AS 'Apellido',P.nombre AS 'Nombre',P.dni AS'DNI',P.telefono AS'Telefono', O.descripcion AS 'Obra Social', T.medico, T.confirmado,T.atendido " +
        "FROM Pacientes P, ObrasSociales O, Medicos M, Especialidades E, Practicas X, Turnos T " +
        "WHERE T.medico = M.legajo AND T.obraSocial = O.idObraSocial AND T.paciente = P.dni AND T.idEspecialidad = E.idEspecialidad AND T.idPractica = X.idPractica AND T.fecha = convert(date, GETDATE())";
      try
      {
        tabla = BDHelper.ConsultarSQL(query);
        return tabla;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return tabla;
      }
    }
    public static DataTable TurnosMedico(int idMedico)
    {
      DataTable tabla = new DataTable();
      string query = "SELECT T.fecha AS 'Fecha', T.hora AS 'Hora', M.apellido AS 'Medico',E.descripcion as 'Especialidad',X.descripcion AS 'Practica', P.apellido AS 'Apellido',P.nombre AS 'Nombre',P.dni AS'DNI',P.telefono AS'Telefono', O.descripcion AS 'Obra Social', T.medico, T.confirmado,T.atendido " +
        "FROM Pacientes P, ObrasSociales O, Medicos M, Especialidades E, Practicas X, Turnos T " +
        "WHERE T.medico = M.legajo AND T.obraSocial = O.idObraSocial AND T.paciente = P.dni AND T.idEspecialidad = E.idEspecialidad AND T.idPractica = X.idPractica AND T.fecha = convert(date, GETDATE())  AND T.medico = " + idMedico;
      try
      {
        tabla = BDHelper.ConsultarSQL(query);
        return tabla;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return tabla;
      }
    }
    public static DataTable GetTurnosDelDiaMedico(int idMedico)
    {
      DataTable tabla = new DataTable();
      string query = "SELECT T.fecha AS 'Fecha', T.hora AS 'Hora', X.descripcion AS 'Practica', P.apellido AS 'Paciente', O.descripcion AS 'Obra Social', T.medico, T.confirmado,T.atendido,T.paciente AS 'DNI'" +
        "FROM Pacientes P, ObrasSociales O, Practicas X, Turnos T " +
        "WHERE T.obraSocial = O.idObraSocial AND T.paciente = P.dni AND T.idPractica = X.idPractica AND T.fecha = convert(date, GETDATE()) AND T.medico = " + idMedico;
      try
      {
        tabla = BDHelper.ConsultarSQL(query);
        return tabla;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return tabla;
      }
    }

    //metodo que busca los turnos que hay para un dia determinado y un medico determinado 

    public static DataTable GetDiaMedico(DateTime fechaDelDia, int idMedico)
    {
      DataTable tabla = new DataTable();
      string query = "SELECT T.fecha AS 'Fecha', T.hora AS 'Hora', M.apellido AS 'Medico',E.descripcion as 'Especialidad',X.descripcion AS 'Practica',O.descripcion AS 'Obra Social' ,P.apellido AS 'Apellido',P.nombre AS 'Nombre',P.dni AS'DNI',P.telefono AS'Telefono', T.medico, T.confirmado,T.atendido " +
        "FROM Pacientes P, ObrasSociales O, Medicos M, Especialidades E, Practicas X, Turnos T " +
        "WHERE T.medico = M.legajo AND T.obraSocial = O.idObraSocial AND T.paciente = P.dni AND T.idEspecialidad = E.idEspecialidad AND T.idPractica = X.idPractica AND T.fecha = '" + fechaDelDia.ToShortDateString() + "' AND T.medico =" + idMedico;
      try
      {
        tabla = BDHelper.ConsultarSQL(query);
        return tabla;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return tabla;
      }
    }

    public static DataTable CheckearTurno(DateTime fecha, DateTime hora, int medico)
    {
      DataTable tabla = new DataTable();
      string query = "SELECT * FROM Turnos WHERE fecha ='" + fecha.ToString("yyyy-MM-dd") + "' AND hora = '" + hora.ToString("HH:mm:ss") + "' AND medico =" + medico;
      try
      {
        tabla = BDHelper.ConsultarSQL(query);
        return tabla;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return tabla;
      }
    }

    public void Save()
    {
      string query = "INSERT into Turnos(fecha, hora, medico, idEspecialidad, paciente, idPractica, obraSocial, confirmado, atendido) VALUES ('"
        + fechaTurno.ToString("yyyy-MM-dd") + "','" + horaTurno.ToString("HH:mm:ss") + "'," + this.LegajoMedico + "," + this.IdEspecialidad + ",'" + this.DniPaciente + "',"
        + this.Practica + "," + this.ObraSocial + ",0, 0)";
      try
      {
        BDHelper.ConsultarSQL(query);
        MessageBox.Show("Turno cargado para el dia: " + this.fechaTurno.ToString("yyyy-MM-dd") + " a la hora: " + this.horaTurno.ToString("HH:mm:ss") + " para el paciente con dni: " + this.DniPaciente, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

      }



    }

    public void Confirmar()
    {
      string query = "UPDATE Turnos SET confirmado = 1 " +
        "WHERE fecha = '" + this.fechaTurno.ToString("yyyy-MM-dd") + "' AND hora = '" + this.horaTurno.ToString("HH:mm:ss") + "' AND medico =" + this.LegajoMedico;
      try
      {
        BDHelper.ConsultarSQL(query);
        MessageBox.Show("Turno confirmado", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    public void Atender()
    {
      string query = "UPDATE Turnos SET atendido = 1 " +
        "WHERE fecha = '" + this.fechaTurno.ToString("yyyy-MM-dd") + "' AND hora = '" + this.horaTurno.ToString("HH:mm:ss") + "' AND confirmado = 1 AND medico =" + this.LegajoMedico;
      try
      {
        BDHelper.ConsultarSQL(query);
        MessageBox.Show("Turno atendido", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    public void BorrarTurno()
    {
      string query = "DELETE FROM Turnos WHERE fecha = '" + this.fechaTurno.ToString("yyyy-MM-dd") + "' AND hora = '" + this.horaTurno.ToString("HH:mm:ss") + "' AND medico = " + this.LegajoMedico;
      try
      {
        BDHelper.ConsultarSQL(query);
        MessageBox.Show("Turno eliminado", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }
  }


}