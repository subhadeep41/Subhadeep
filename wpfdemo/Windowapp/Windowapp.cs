﻿using System;
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
        List<User> _list=null;
        public Windowapp()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var Users = new List<User>();
                using (StreamReader reader = new StreamReader(pathoffile))
                {

                    if ((System.IO.Path.GetFileName(pathoffile)).Contains(".txt") || (System.IO.Path.GetFileName(pathoffile)).Contains(".nm"))
                    {
                        int count = 0;
                        while (true)
                        {
                            string line = reader.ReadLine();
                            if (line == null)
                            { break; }
                            if (count <= 100)
                            {
                                Users.Add(new User(line));
                            }
                            count = count + 1;
                        }
                        this._list = Users;
                        databind(Users);
                    }
                    else
                    {
                        label1.Text = "Not a valid file";
                    }
                }
            }
            catch { }
        }
        private void databind(List<User> Users)
        {
            try
            {
                label2.Text = "";
                if (Users != null)
                {
                    if (Users.Count > 0)
                    {
                        //dataGridView1.DataSource = Users;
                        foreach (User o in Users)
                        {
                            dataGridView1.Rows.Add(o.Date, o.Time, o.latitude, o.min, o.second, o.longitude, o.altitude, o.fix, o.pdop, o.hdop, o.vdop, o.GPS, o.GPSused, o.GLO, o.GLOused, o.totalSV, o.totalSVused);
                        }
                        label2.Text = "Success";
                        label2.ForeColor = Color.Green;
                    }
                    else
                    {
                        label2.Text = "Failed";
                        label2.ForeColor = Color.Red;
                    }
                }
            }
            catch { }
        }
        class User
        {
            public string Date { get; set; }
            public string Time { get; set; }
            public string latitude { get; set; }
            public string min { get; set; }
            public string second { get; set; }
            public string longitude { get; set; }
            public string altitude { get; set; }
            public string fix { get; set; }
            public string pdop { get; set; }
            public string hdop { get; set; }
            public string vdop { get; set; }
            public string GPS { get; set; }
            public string GPSused { get; set; }
            public string GLO { get; set; }
            public string GLOused { get; set; }
            public string totalSV  { get; set; }
            public string totalSVused  { get; set; }

            public User(string line)
            {
                try
                {
                    string[] parts = line.Split(',');
                    this.Date = parts[0];
                    this.Time = parts[1];
                    this.latitude = parts[2];
                    this.min = parts[3]; this.second = parts[4]; this.longitude = parts[5]; this.altitude = parts[6]; this.fix = parts[7];
                    this.pdop = parts[8]; this.hdop = parts[9]; this.vdop = parts[10]; this.GPS = parts[11]; this.GPSused = parts[12];
                    this.GLO = parts[13]; this.GPSused = parts[14]; this.totalSV = parts[15]; this.totalSVused = parts[16];
                }
                catch (Exception e)
                {
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
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
            catch { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.gpsinformation.org/dale/nmea.htm");
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
        }
    }
}
