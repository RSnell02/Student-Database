using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Student_Database_Application
{
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.database1DataSet.student);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(global::DataBaseTest.Properties.Settings.Default.Database1ConnectionString);
            try
            {
                string sql = "INSERT INTO student (StudentID, FName, LName, Year, City, State) values(" + txtStuID.Text + ",'" + txtFName.Text + ",'" + txtLName.Text + ",'" + txtYear.Text + ",'" + txtCity.Text + ",'" + txtState.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("New student added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.studentTableAdapter.Fill(this.database1DataSet.student);
            }   // End try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   // End catch
            finally
            {
                cn.Close();
            }   // End finally
        }   // End btnAdd_Click

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }   // End btnSearch_Click

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.studentTableAdapter.Fill(this.database1DataSet.student);
        }   // End btnRefresh_Click
    }   // End class
}   // End namespace
