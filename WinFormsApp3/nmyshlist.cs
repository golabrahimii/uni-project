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
    public partial class nmyshlist : Form
    {

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\ASUS\source\repos\project unii\WinFormsApp3\database.mdf';Integrated Security=True;Connect Timeout=30";
        List<classListData> classListDatas;
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


        private List<sectionData> FetchSectionData(string cmdtext)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(cmdtext, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            List<sectionData> data = new List<sectionData>();
            while (dataReader.Read())
            {
                sectionData sectionDataValues = new sectionData();
                sectionDataValues.classId = (int)dataReader["classId"];
                sectionDataValues.Id = (int)dataReader["Id"];
                sectionDataValues.factor = (string)dataReader["factorId"];
                sectionDataValues.studentId = (long)dataReader["studentId"];
                data.Add(sectionDataValues);
            }
            return data;
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


        private void AddClassDataToComboBox()
        {
            comboBox1.Items.Clear();
            List<classListData> classAllData = FetchClassData("SELECT * FROM classdars");
            for (int i = 0; i < classAllData.Count; i++)
            {
                comboBox1.Items.Add(classAllData[i].classname);
            }
        }

        public nmyshlist()
        {
            InitializeComponent();
            AddClassDataToComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            int classId = classListDatas[index].Id;
            List<sectionData> sectionDatas = FetchSectionData($"SELECT * FROM section WHERE classId = '{classId}'");
            for (int i = 0; i < sectionDatas.Count; i++)
            {
                long idcode = sectionDatas[i].studentId;
                List<studentsData> studentsDatas = FetchStudentsData($"SELECT * FROM students WHERE Idcode = '{idcode}'");
                studentList.Items.Add(studentsDatas[0].fullname);
            }
        }

        private void OnBack4 (object sender, EventArgs e)
        {

        }
    }
}
