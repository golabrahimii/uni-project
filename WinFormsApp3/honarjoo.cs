using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class honarjoo : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\ASUS\source\repos\project unii\WinFormsApp3\database.mdf';Integrated Security=True;Connect Timeout=30";
        public honarjoo()
        {
            InitializeComponent();
            AddStudentsToComboBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private bool Query(string sql)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                Console.WriteLine(err.Message);
                return false;
            }
        }



        private List<studentsData> FetchStudentsData(string cmdtext)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(cmdtext, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            List<studentsData> data = new List<studentsData>();
            while (dataReader.Read())
            {
                studentsData student = new studentsData();
                student.fullname = (string)dataReader["fullname"];
                student.idcode = (long)dataReader["idcode"];
                data.Add(student);
            }

            return data;

        }


        private void AddStudentsToComboBox()
        {
            comboBox1.Items.Clear();
            List<studentsData> studentList = FetchStudentsData("SELECT * FROM students");
            for(int i = 0; i < studentList.Count; i++)
            {
                comboBox1.Items.Add(studentList[i].fullname);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string fullname = textBox1.Text;
            string idcode = textBox2.Text;

            bool result = Query($"INSERT INTO students (fullname, idcode) VALUES ('{fullname}', '{idcode}')");
            if(result)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                AddStudentsToComboBox();
            }
        }
        
        private void OnBack3 (object sender, EventArgs e)
        {

        }
    }
}
