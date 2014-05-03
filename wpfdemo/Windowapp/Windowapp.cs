using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Windowapp
{
    public partial class Windowapp : Form
    {
        string pathoffile { get; set; }
        List<User> _list;
        public Windowapp()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var Users = new List<User>();
            using (StreamReader reader = new StreamReader(pathoffile))
            {
                label2.Text = "";
                if ((System.IO.Path.GetFileName(pathoffile)).Contains(".txt"))
                {
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null)
                        { break; }
                        Users.Add(new User(line));
                    }
                    this._list = Users;
                    databind(Users);
                }
                else
                    label2.Text = "Not a valid file";
            }
        }
        private void databind(List<User> Users)
        {
            if (Users.Count > 0)
            {
                //dataGridView1.DataSource = Users;
                foreach (User o in Users)
                {
                    dataGridView1.Rows.Add(o.FirstName, o.LastName, o.Address, o.time);
                }
                
            }
        }
        class User
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string time { get; set; }
            public User(string line)
            {
                string[] parts = line.Split(',');
                this.FirstName = parts[0];
                this.LastName = parts[1];
                this.Address = parts[2];
                this.time = parts[3];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
            new FileInfo(openFileDialog1.FileName);
            }
            pathoffile = @openFileDialog1.FileName;
            if (@openFileDialog1.FileName.Length > 0)
            {
                label1.Text = System.IO.Path.GetFileName(@openFileDialog1.FileName);
                button2.Visible = true;
            }
        }
    }
}
