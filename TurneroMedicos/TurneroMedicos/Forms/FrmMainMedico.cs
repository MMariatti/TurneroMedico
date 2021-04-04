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
  public partial class FrmMainMedico : Form
  {
    public FrmMainMedico()
    {
      InitializeComponent();
    }


    /* Eventos */

    private void VerTurnos()
    {

      DataTable tabla = new DataTable();
      int legajo = Convert.ToInt32(LblLegajo.Text.ToString());
      if (monthCalendarMedico.SelectionStart != null)
      {
        tabla = Turnos.GetDiaMedico(monthCalendarMedico.SelectionStart, legajo);
        if (tabla.Rows.Count == 0)
        {
          MessageBox.Show("No hay turnos cargados para el dia de la fecha", "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
          GrdPacientesMedico.DataSource = tabla;
          // GrdPacientesMedico.Columns[5].Visible = false;
          GrdPacientesMedico.Columns[10].Visible = false;
          GrdPacientesMedico.Columns[11].Visible = false;
          GrdPacientesMedico.Columns[12].Visible = false;

          foreach (DataGridViewRow row in GrdPacientesMedico.Rows)
          {

            if (Convert.ToBoolean(row.Cells[11].Value.ToString()) && Convert.ToBoolean(row.Cells[12].Value.ToString()))
            {
              row.DefaultCellStyle.BackColor = Color.Red;
            }
            else if (Convert.ToBoolean(row.Cells[11].Value.ToString()))
            {
              row.DefaultCellStyle.BackColor = Color.LightBlue;
            }
          }
        }
       
      }
      else
      {
        MessageBox.Show("Por favor seleccione una fecha en el calendario y/o el medico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void VerTurnosDelDia()
    {

      DataTable tabla = new DataTable();
      int legajo = Convert.ToInt32(LblLegajo.Text.ToString());
      if (tabla.Rows.Count == 0)
      {
        MessageBox.Show("No hay turnos cargados para el dia de la fecha", "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      else
      {
        tabla = Turnos.GetTurnosDelDiaMedico(legajo);
        GrdPacientesMedico.DataSource = tabla;
        GrdPacientesMedico.Columns[5].Visible = false;
        GrdPacientesMedico.Columns[6].Visible = false;
        GrdPacientesMedico.Columns[7].Visible = false;
        GrdPacientesMedico.Columns[8].Visible = true;



        foreach (DataGridViewRow row in GrdPacientesMedico.Rows)
        {

          if (Convert.ToBoolean(row.Cells[6].Value.ToString()) && Convert.ToBoolean(row.Cells[7].Value.ToString()))
          {
            row.DefaultCellStyle.BackColor = Color.Red;
          }
          else if (Convert.ToBoolean(row.Cells[6].Value.ToString()))
          {
            row.DefaultCellStyle.BackColor = Color.LightBlue;
          }
        }
      }
      

    }

    /* Eventos */

    private void FrmMainMedico_Load(object sender, EventArgs e)
    {
      Medicos medico = new Medicos(Convert.ToInt32(LblLegajo.Text.ToString()));
      LblBienvenida.Text = "Bienvenido Dr/a : " + medico.Nombre + ", " + medico.Apellido;
      VerTurnosDelDia();

    }

    private void BtnHistoriaClinica_Click(object sender, EventArgs e)
    {
      if (GrdPacientesMedico.SelectedRows.Count == 0)
      {
        MessageBox.Show("Por favor seleccione al paciente del que quiere ver la historia clinica", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        FrmHistoriaClinica frmHistoriaClinica = new FrmHistoriaClinica();
        frmHistoriaClinica.TxtDni.Text = GrdPacientesMedico.SelectedRows[0].Cells[8].Value.ToString();
        frmHistoriaClinica.TxtDni.ReadOnly = true; 
        frmHistoriaClinica.Show();
      }
    }

    
    private void BtnBuscar_Click(object sender, EventArgs e)
    {
      BtnAtendido.Enabled = false;
      VerTurnos();
    }

    private void BtnRefrescar_Click(object sender, EventArgs e)
    {
      VerTurnosDelDia();
      BtnAtendido.Enabled = true;
    }

    private void BtnAtendido_Click(object sender, EventArgs e)
    {
      if (GrdPacientesMedico.SelectedRows.Count == 0)
      {
        MessageBox.Show("Por favor, seleccione el turno que quiere marcar como atendido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        DateTime fecha = DateTime.Parse(GrdPacientesMedico.SelectedRows[0].Cells[0].Value.ToString());
        DateTime hora = DateTime.Parse(GrdPacientesMedico.SelectedRows[0].Cells[1].Value.ToString());
        int medico = Convert.ToInt32(GrdPacientesMedico.SelectedRows[0].Cells[5].Value.ToString());
        Turnos turno = new Turnos(fecha, hora, medico);
        turno.Atender();
      }
    }

    private void FrmMainMedico_FormClosing(object sender, FormClosingEventArgs e)
    {
      Application.Exit();
    }

    
  }
}
