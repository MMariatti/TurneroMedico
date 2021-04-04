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
  public partial class FrmHistoriaClinica : Form
  {
    public FrmHistoriaClinica()
    {
      InitializeComponent();
    }

    /* Metodos */

    private void BuscarHistoriaClinica(string dni)
    {
      Pacientes paciente = new Pacientes(dni);
      paciente.BuscarHistoriaClinica();
      RtbHistoriaClinica.Text = paciente.HistoriaClinica.ToString();
    }

    /* Eventos */

    private void FrmHistoriaClinica_Load(object sender, EventArgs e)
    {

    }

    private void BtnGuardar_Click(object sender, EventArgs e)
    {
      Pacientes paciente = new Pacientes(TxtDni.Text);
      paciente.GuardarHistoriaClinica(RtbHistoriaClinica.Text);
    }

    private void BtnBuscar_Click(object sender, EventArgs e)
    {
      if (TxtDni.Text != string.Empty)
      {
        BuscarHistoriaClinica(TxtDni.Text);
      }
      else
      {
        MessageBox.Show("Ingrese el dni del paciente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }
  }
}
