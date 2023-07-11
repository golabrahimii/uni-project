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
    public partial class classDarsi : Form
    {

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
        private List<AsatidData> asatids;

        private void AddMasterToComboBox()
        {
            List<AsatidData> asatidDatas = FetchMasterData("SELECT * FROM asatid");
            for(int i = 0; i < asatidDatas.Count; i++)
            {
                MastercomboBox.Items.Add(asatidDatas[i].fullname);
            }
        }
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\ASUS\source\repos\project unii\WinFormsApp3\database.mdf';Integrated Security=True;Connect Timeout=30";
        private List<AsatidData> FetchMasterData(string cmdtext)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(cmdtext, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            List<AsatidData> data = new List<AsatidData>();
            while (dataReader.Read())
            {
                AsatidData ostad = new AsatidData();
                ostad.fullname = (string)dataReader["fullname"];
                ostad.idcode = (long)dataReader["idcode"];
                ostad.instrument = (string)dataReader["instrument"];
                data.Add(ostad);
            }
            asatids = data;
            return data;
        }

        private void AddClassDataToComboBox()
        {
            comboBox2.Items.Clear();
            List<classListData> classAllData = FetchClassData("SELECT * FROM classdars");
            for(int i = 0; i < classAllData.Count; i++)
            {
                comboBox2.Items.Add(classAllData[i].classname);
            }
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
                classValues.classname = (string) dataReader["classname"];
                classValues.Id = (int) dataReader["Id"];
                classValues.classtime = (string) dataReader["classtime"];
                classValues.masterid = (long) dataReader["masterid"];
                classValues.weekday = (string) dataReader["weekday"];
                data.Add(classValues);
            }
            return data;
        }


        public classDarsi()
        {
            InitializeComponent();
            AddClassDataToComboBox();
            AddMasterToComboBox();
        }

        private void OnSubmit (object sender, EventArgs e)
        {
            string className = classNameTextbox.Text;
            string time = hour.Text +":"+ min.Text;
            int Masterindex = MastercomboBox.SelectedIndex;
            long idcode = asatids[Masterindex].idcode;
            string weekday = textBox1.Text;
            bool result = Query($"INSERT INTO classdars (classname,classtime,masterid,weekday) VALUES ('{className}','{time}','{idcode}','{weekday}') ");
           
            if(result)
            {
                MessageBox.Show("success");
                classNameTextbox.Text = "";
                hour.Text = "";
                min.Text = "";
                textBox1.Text = "";
                AddClassDataToComboBox();
            }


        }

        private void MastercomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void OnBack2(object sender, EventArgs e)
        {

        }
    }
}
