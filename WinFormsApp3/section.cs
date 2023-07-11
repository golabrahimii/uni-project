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
    public partial class section : Form
    {
        List<classListData> classListDatas;
        List<studentsData> studentsDatas;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\ASUS\source\repos\project unii\WinFormsApp3\database.mdf';Integrated Security=True;Connect Timeout=30";
        public section()
        {
            InitializeComponent();
            AddClassListToComboBox();
            AddStudentToComboBox();
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
            studentsDatas = data;

            return data;

        }
        private List<classListData> FetchClassData(string cmdtext)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(cmdtext, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            List<classListData> data = new List<classListData>();
            while (dataReader.Read())
            {
                classListData classValues = new classListData();
                classValues.classname = (string)dataReader["classname"];
                classValues.Id = (int)dataReader["Id"];
                classValues.classtime = (string)dataReader["classtime"];
                classValues.masterid = (long)dataReader["masterid"];
                classValues.weekday = (string)dataReader["weekday"];
                data.Add(classValues);
            }
            classListDatas = data;
            return data;
        }
        private void AddStudentToComboBox()
        {
            List<studentsData> students = FetchStudentsData("SELECT * FROM students");
            for (int i = 0; i < students.Count; i++)
            {
                comboBox2.Items.Add(students[i].fullname);
            };
        }
        void AddClassListToComboBox()
        {
            List<classListData> classLists = FetchClassData("SELECT * FROM classdars");
            for (int i = 0; i < classLists.Count; i++)
            {
                comboBox1.Items.Add(classLists[i].classname);
            };
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

        private void button1_Click(object sender, EventArgs e)
        {
            int classIndex = comboBox1.SelectedIndex;
            int studentIndex = comboBox2.SelectedIndex;
            string factor = textBox1.Text;
            long studentId = studentsDatas[studentIndex].idcode;
            long classId = classListDatas[classIndex].Id;
            bool result = Query($"INSERT INTO section (classId, studentId, factorId) VALUES ('{classId}', '{studentId}', '{factor}')");
            if(result)
            {
                textBox1.Text = "";
                MessageBox.Show("success");
            }
        }

        private void  OnBack5 (object sender, EventArgs e)
        {

        }
    }
}
