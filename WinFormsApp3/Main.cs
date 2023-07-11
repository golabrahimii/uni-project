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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Asatid_Click(object sender, EventArgs e)
        {
            asatid asatidForm = new asatid();
            asatidForm.Show();
            this.Hide();


        }

        private void Student_Click(object sender, EventArgs e)
        {
            honarjoo honarjooForm = new honarjoo();
            honarjooForm.Show();
            this.Hide();



        }

        private void OnClassClick(object sender, EventArgs e)
        {
            classDarsi classDarsiForm = new classDarsi();
            classDarsiForm.Show();
            this.Hide();

        }

        private void OnSectionClick(object sender, EventArgs e)
        {
            section sectiondarsi =new();
            sectiondarsi.Show();
            this.Hide();

        }

        private void showClassList_Click(object sender, EventArgs e)
        {
            this.Hide();
            nmyshlist nmyshlistForm = new nmyshlist();
            nmyshlistForm.Show();
        }
    }
}
