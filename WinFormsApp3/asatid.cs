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
    public partial class asatid : Form
    {


        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\ASUS\source\repos\project unii\WinFormsApp3\database.mdf';Integrated Security=True;Connect Timeout=30";



        public asatid()
        {
            InitializeComponent();

        }

        private void AddMaster(object sender, EventArgs e)
        {
            string fullname = MasterName.Text;
            string idcode = idcodeTextbox.Text;
            string instrument = instrumentTextbox.Text;
            string query = $"INSERT INTO asatid (fullname,idcode,instrument) VALUES ('{fullname}','{idcode}','{instrument}')";
            
            bool result = Query(query);
            if (result)
            {
                MessageBox.Show("success");
                MasterName.Text = "";
                idcodeTextbox.Text = "";
                instrumentTextbox.Text = "";
                FormLoad();
            }
        }


        private bool Query(string sql) 
        {
            try
            {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql,conn);
            cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
                Console.WriteLine(err.Message);
                return false;
            }
        }

         private List<AsatidData> FetchMasterData(string cmdtext)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(cmdtext,connection);
            SqlDataReader dataReader = command.ExecuteReader();
            List<AsatidData> data = new List<AsatidData>();
            while (dataReader.Read())
            {
                AsatidData ostad = new AsatidData();
                ostad.fullname = (string) dataReader["fullname"];
                ostad.idcode = (long) dataReader["idcode"];
                ostad.instrument = (string) dataReader["instrument"];
                data.Add(ostad);
            }

            return data;

        }

        private void FormLoad(object sender, EventArgs e)
        {
            List<AsatidData> data = FetchMasterData("SELECT * FROM asatid");
            //MasterList.Items.Add(obj.)
            for (int i = 0; i < data.Count; i++)
            {
                MasterList.Items.Add(data[i].fullname);
            }
        }
        private void FormLoad()
        {
            MasterList.Items.Clear();
            List<AsatidData> data = FetchMasterData("SELECT * FROM asatid");
            //MasterList.Items.Add(obj.)
            for (int i = 0; i < data.Count; i++)
            {
                MasterList.Items.Add(data[i].fullname);
            }
        }

        private void DeletedMaster(object sender, EventArgs e)
        {
            string selected = (string)MasterList.SelectedItem;
          bool res = Query($"DELETE FROM asatid WHERE fullname = '{selected}'");
            if (res)
            {
                MessageBox.Show($"Deleted {selected}");
                FormLoad();
            }
        }

        private void OnBack(object sender, EventArgs e)
        {
            //hide this form 
            this.Hide();
            //show main form from controller
            ViewController.mainView.Show();
        }
    }

}
