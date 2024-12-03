using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Codigo2024Clase30
{
    public partial class frmStudents : Form
    {
        public frmStudents()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Capa de negocio que lista los estudiantes
            
            BStudent student = new BStudent();
            List<Student> students = student.Listar(txtName.Text, txtLastName.Text);
            dgvStudents.DataSource = students;
        }
    }
}
