using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            string user_name = username.Text;
            MessageBox.Show("hello " + user_name);
            string password = pass.Text;

            if (user_name == "admin" && password == "admin")
            {
                
                ViewController.mainView.Show();
                
                this.Hide();
            }
            else
            {
                MessageBox.Show("username or pass its wrong");
            }
        }


    }

}