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

        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader sqlreader;
        string connstring = "server = localhost; database = student";
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.database1DataSet.student);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            comm = new SqlCommand("INSERT INTO student (StudentID, FName, LName, Year, City, State) values(" + txtStuID.Text + ",'" + txtFName.Text + ",'" + txtLName.Text + ",'" + txtYear.Text + ",'" + txtCity.Text + ",'" + txtState.Text + "')", conn);

            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("New student added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   // End try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error, student not saved.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   // End catch
            finally
            {
                conn.Close();
            }   // End finally
        }   // End btnAdd_Click

        private void btnSearch_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            comm = new SqlCommand("SELECT * FROM student(StudentID, fName, LName, Year, City, State)  WHERE StudentID =" + txtStuID.Text + ",", conn);
            try
            {
                sqlreader = comm.ExecuteReader();
                if (sqlreader.Read())
                {
                    txtFName.Text = sqlreader[1].ToString();
                    txtLName.Text = sqlreader[2].ToString();
                    txtYear.Text = sqlreader[3].ToString();
                    txtCity.Text = sqlreader[4].ToString();
                    txtState.Text = sqlreader[5].ToString();
                }
                else
                {
                    MessageBox.Show(" No Record");
                }
                sqlreader.Close();
            }   // End try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   // End catch
            finally
            {
                conn.Close();
            }   // End finallh
        }   // End btnSearch_Click

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.studentTableAdapter.Fill(this.database1DataSet.student);
        }   // End btnRefresh_Click
    }   // End class
}   // End namespace
