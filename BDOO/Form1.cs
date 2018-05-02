using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDOO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Tesis> lstTesis = new List<Tesis>();
            if (Util.BDDisponible())
            {
                lstTesis = Util.MostrarTodosObjetos();
            }

            if(lstTesis!=null && lstTesis.Count > 0)
            {
                dataGridView.ColumnCount = 3;
                dataGridView.Columns[0].Name = "Tesis";
                dataGridView.Columns[1].Name = "Alumno";
                dataGridView.Columns[2].Name = "Asesor";

                foreach (Tesis item in lstTesis)
                {
                    string[] row = new string[] { item.Titulo, item.Estudiante.Nombre, item.Asesor.Nombre };
                    dataGridView.Rows.Add(row);  
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Util.Guardar(new Tesis(txtTesis.Text, new Estudiante(txtEstudiante.Text), new Docente(txtAsesor.Text)));
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView.Rows[e.RowIndex];

                txtTesis.Text = row.Cells["Tesis"].Value.ToString();
                txtEstudiante.Text = row.Cells["Alumno"].Value.ToString();
                txtAsesor.Text = row.Cells["Asesor"].Value.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtTesis.Text != "")
            {
                if (Util.BDDisponible())
                {
                    Util.DeleteByObject(txtTesis.Text);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
             Util.Actualizar(new Tesis(txtTesis.Text, new Estudiante(txtEstudiante.Text), new Docente(txtAsesor.Text)));
            //
            //Util.Guardar(new Tesis(txtTesis.Text, new Estudiante(txtEstudiante.Text), new Docente(txtAsesor.Text)));
        }

        private void txtTesis_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
