using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace TurneroMedicos.Classes
{
  public class Pacientes
  {
    //Forzamos que los parametros sean privados para que una vez creados solo puedan ser modificados por la misma clase
    private string nombre;
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
    private string apellido;
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

    private string telefono;
    public string Telefono
    {
      get { return this.telefono; }
      private set
      {
        if (!string.IsNullOrWhiteSpace(value))
        {
          this.telefono = value;
        }
        else
        {
          throw new ArgumentOutOfRangeException();
        }
      }
    }
    private string dni;
    public string Dni
    {
      get { return this.dni; }
      private set
      {
        if (!string.IsNullOrWhiteSpace(value))
        {
          this.dni = value;
        }
        else
        {
          throw new ArgumentOutOfRangeException();
        }
      }
    }


    public DateTime fechaNac = new DateTime();



    private string direccion;
    public string Direccion
    {
      get { return this.direccion; }
      private set
      {
        if (!string.IsNullOrWhiteSpace(value))
        {
          this.direccion = value;
        }
        else
        {
          throw new ArgumentNullException();
        }
      }
    }

    private int obraSocial;
    public int ObraSocial
    {
      get { return this.obraSocial; }
      private set
      {
        if (value > 0)
        {
          this.obraSocial = value;
        }
        else
        {
          throw new ArgumentOutOfRangeException();
        }
      }
    }
    private int nroHistoriaClinica;
    public int NroHistoriaClinica
    {
      get { return this.nroHistoriaClinica; }
      private set
      {
        if (value > 0)
        {
          this.nroHistoriaClinica = value;
        }
        else
        {
          throw new ArgumentOutOfRangeException();
        }
      }
    }


    private string historiaClinica;
    public string HistoriaClinica
    {
      get { return this.historiaClinica; }
      private set
      {
        if (!string.IsNullOrWhiteSpace(value))
        {
          this.historiaClinica = value;
        }
        else
        {
          throw new ArgumentNullException();
        }
      }
    }

    public Pacientes(string dni)
    {
      this.Dni = dni;
      getAttr();
    }

    public void getAttr()
    {
      string query = "SELECT * FROM Pacientes WHERE dni = '" + this.Dni + "'";
      DataTable tabla = BDHelper.ConsultarSQL(query);
      if (tabla.Rows.Count != 0)
      {
        Apellido = tabla.Rows[0]["apellido"].ToString();
        Nombre = tabla.Rows[0]["nombre"].ToString();
        ObraSocial = (int)tabla.Rows[0]["obraSocial"];
        fechaNac = DateTime.Parse(tabla.Rows[0]["fechaNac"].ToString());
        Direccion = tabla.Rows[0]["direccion"].ToString();
        Telefono = tabla.Rows[0]["Telefono"].ToString();
        NroHistoriaClinica = (int)tabla.Rows[0]["nroHistoriaClinica"];

      }
      else
      {
        MessageBox.Show("El paciente que busca no está cargado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }

    }

    public void BuscarHistoriaClinica()
    {
      string query = "SELECT HistoriaClinica FROM Pacientes WHERE dni ='" + this.Dni + "'";
      DataTable tabla = new DataTable();
      try
      {
        tabla = BDHelper.ConsultarSQL(query);

        tabla.Rows[0]["HistoriaClinica"].ToString();
        historiaClinica = tabla.Rows[0]["HistoriaClinica"].ToString();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Data.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public void GuardarHistoriaClinica(string nuevaHc)
    {
      string query = "UPDATE Pacientes SET HistoriaClinica ='" + nuevaHc + "' WHERE dni ='" + this.Dni + "'";
      try
      {
        BDHelper.ConsultarSQL(query);
        MessageBox.Show("Historia Clinica Guardada", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Data.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    

  }
}