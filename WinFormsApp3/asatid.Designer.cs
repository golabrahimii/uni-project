
namespace WinFormsApp3
{
    partial class asatid
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MasterName = new System.Windows.Forms.TextBox();
            this.idcodeTextbox = new System.Windows.Forms.TextBox();
            this.instrumentTextbox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.idcode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MasterList = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MasterName
            // 
            this.MasterName.Location = new System.Drawing.Point(146, 69);
            this.MasterName.Name = "MasterName";
            this.MasterName.Size = new System.Drawing.Size(139, 23);
            this.MasterName.TabIndex = 0;
            // 
            // idcodeTextbox
            // 
            this.idcodeTextbox.Location = new System.Drawing.Point(146, 137);
            this.idcodeTextbox.Name = "idcodeTextbox";
            this.idcodeTextbox.Size = new System.Drawing.Size(139, 23);
            this.idcodeTextbox.TabIndex = 1;
            // 
            // instrumentTextbox
            // 
            this.instrumentTextbox.Location = new System.Drawing.Point(146, 207);
            this.instrumentTextbox.Name = "instrumentTextbox";
            this.instrumentTextbox.Size = new System.Drawing.Size(139, 23);
            this.instrumentTextbox.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "ثبت";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddMaster);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "نام استاد";
            // 
            // idcode
            // 
            this.idcode.AutoSize = true;
            this.idcode.Location = new System.Drawing.Point(242, 105);
            this.idcode.Name = "idcode";
            this.idcode.Size = new System.Drawing.Size(43, 15);
            this.idcode.TabIndex = 5;
            this.idcode.Text = "کد ملی";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "ساز تخصصی";
            // 
            // MasterList
            // 
            this.MasterList.FormattingEnabled = true;
            this.MasterList.Location = new System.Drawing.Point(615, 69);
            this.MasterList.Name = "MasterList";
            this.MasterList.Size = new System.Drawing.Size(154, 23);
            this.MasterList.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(632, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "حذف استاد";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.DeletedMaster);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(693, 254);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "بازگشت";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnBack);
            // 
            // asatid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.MasterList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.idcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.instrumentTextbox);
            this.Controls.Add(this.idcodeTextbox);
            this.Controls.Add(this.MasterName);
            this.Name = "asatid";
            this.Text = "asatid";
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MasterName;
        private System.Windows.Forms.TextBox idcodeTextbox;
        private System.Windows.Forms.TextBox instrumentTextbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label idcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox MasterList;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}