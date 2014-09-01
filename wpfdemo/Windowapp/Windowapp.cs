using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Windowapp
{

    public partial class Windowapp : Form
    {
        string pathoffile { get; set; }
        string filetype { get; set; }
        int gsv = 0;
        int gsa = 0;
        int igsv = 18;
        int ygsv = 34;
        int counter = 0;
        int zdaoccured = 0;
        int rmcoccured = 0;
        List<User> Users = null;
        bool settypeoffile = true;

        public Windowapp()
        {
            InitializeComponent();
        }

        private void outputfileschecked(object sender, EventArgs e)
        {
            settypeoffile = false;
        }
        private void nmfileschecked(object sender, EventArgs e)
        {
            settypeoffile = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var Users = new List<User>();
                using (StreamReader reader = new StreamReader(pathoffile))
                {

                    if ((System.IO.Path.GetFileName(pathoffile)).Contains(".txt") || (System.IO.Path.GetFileName(pathoffile)).Contains(""))
                    {
                        if ((System.IO.Path.GetFileName(pathoffile)).Contains(".L") || (System.IO.Path.GetFileName(pathoffile)).Contains(".l")) { filetype = "Ltype"; }
                        if ((System.IO.Path.GetFileName(pathoffile)).Contains(".P") || (System.IO.Path.GetFileName(pathoffile)).Contains(".p")) { filetype = "Ptype"; }
                        if ((System.IO.Path.GetFileName(pathoffile)).Contains(".X") || (System.IO.Path.GetFileName(pathoffile)).Contains(".x")) { filetype = "Xtype"; }
                        if ((System.IO.Path.GetFileName(pathoffile)).Contains(".W") || (System.IO.Path.GetFileName(pathoffile)).Contains(".w")) { filetype = "Wtype"; }
                        if ((System.IO.Path.GetFileName(pathoffile)).Contains(".Y") || (System.IO.Path.GetFileName(pathoffile)).Contains(".y")) { filetype = "Ytype"; }
                        if ((System.IO.Path.GetFileName(pathoffile)).Contains(".G") || (System.IO.Path.GetFileName(pathoffile)).Contains(".g")) { filetype = "Gtype"; }
                        string[] partsnew = new string[100];
                        int count = 0;
                        
                        StringBuilder finalline = new StringBuilder();
                        while (true)
                        {
                            string line = reader.ReadLine();
                            if (line == null)
                            {
                                StringBuilder line1 = new StringBuilder();
                                for (int i = 0; i < 99; i++)
                                {
                                    line1.Append(partsnew[i] + ",");
                                }
                                line1.Append(partsnew[99]);
                                finalline.Append(line1);
                                Users.Add(new User(Convert.ToString(finalline)));
                                break;
                            }
                           // if (count <= 100)
                            {
                                string[] parts = new string[20];
                                string[] newdata = new string[20];
                                #region logic
                                newdata = line.Split(',');
                                if ((newdata.Length < 20) && (newdata.Length > 1))
                                {
                                    for (int i = 0; i < (20 - newdata.Length); i++)
                                    {
                                        line += ",";
                                        line += "00";
                                    }
                                }
                                parts = line.Split(',');
                                string GPGL = parts[0];
                                if ((GPGL == "$GLGGA") || (GPGL == "$GPGGA") || (GPGL == "$GNGGA") || (GPGL == "$GNGNS"))
                                {
                                    partsnew[2] = parts[2]; partsnew[5] = parts[4];
                                    partsnew[6] = parts[6]; partsnew[9] = parts[9];
                                    if ((filetype == "Ptype") || (filetype == "Wtype") || (filetype == "Gtype") || (settypeoffile == false)) { partsnew[14] = "00"; } 
                                    else { partsnew[14] = parts[7]; }
                                    if ((filetype == "Ltype")||(filetype == "Gtype")) { partsnew[12] = "00"; } 
                                    else { partsnew[12] = parts[7]; }
                                }
                                if ((GPGL == "$GLGSA") || (GPGL == "$GPGSA") || (GPGL == "$GNGSA") || (GPGL == "$GAGSA"))
                                {
                                    if (GPGL == "$GNGSA") { gsa = gsa + 1; }
                                    partsnew[15] = parts[15];
                                    partsnew[16] = parts[16]; partsnew[17] = parts[17];
                                    int pos = Array.IndexOf(parts, "");
                                    int x = pos - 3;
                                    partsnew[99] = Convert.ToString(x);
                                    if (gsa == 1)
                                    {
                                        if ((filetype == "Xtype") || (filetype == "Wtype")) { partsnew[12] = Convert.ToString(x);
                                        partsnew[99] = Convert.ToString(x); }
                                    }
                                    if (gsa == 2)
                                    {
                                        if ((filetype == "Xtype") || (filetype == "Wtype") || (filetype == "Ytype"))
                                        {
                                            partsnew[14] = Convert.ToString(x); 
                                            partsnew[99] = Convert.ToString(x);
                                        }
                                        gsa = 0;
                                    }
                                    if ((filetype == "Ptype") || (filetype == "Ltype") || (filetype == "Xtype") || (settypeoffile == false)) { partsnew[99] = "00"; }
                                    if (filetype == "Wtype") { partsnew[14] = "00"; }
                                    if ((filetype == "Ytype") || (filetype == "Ytype")) { partsnew[12] = "00"; }
                                }
                                if ((GPGL == "$GLZDA") || (GPGL == "$GPZDA") || (GPGL == "$GNZDA"))
                                {
                                    partsnew[1] = parts[1];
                                    StringBuilder sb = new StringBuilder();
                                    sb.Append(parts[2] + " ");
                                    sb.Append(parts[3] + " ");
                                    sb.Append(parts[4]);
                                    partsnew[0] = Convert.ToString(sb);
                                    zdaoccured = 1;
                                }
                                if ((GPGL == "$GPGSV") || (GPGL == "$GLGSV"))
                                {
                                    if (gsv == 0)
                                    {
                                        partsnew[11] = parts[3];
                                        if ((filetype == "Ytype") || (filetype == "Gtype"))
                                        {partsnew[11] = "00";}
                                    }
                                    gsv = gsv + 1;
                                }
                                else
                                {
                                    gsv = 0;
                                }
                                if ((GPGL == "$GLGSV"))
                                {
                                    partsnew[13] = parts[3];
                                }
                                if ((GPGL == "$GAGSV")||(GPGL == "$GPGSV"))
                                {
                                    partsnew[13] = parts[3];
                                    partsnew[98] = parts[3];
                                }
                                if ((filetype == "Wtype") || (filetype == "Gtype") || (settypeoffile == false))
                                { partsnew[13] = "00"; }
                                if ((filetype == "Ptype") || (filetype == "Ltype") || (filetype == "Xtype") || (settypeoffile == false)) { partsnew[98] = "00"; }
                                if ((GPGL.Contains("GSV")))
                                {
                                    counter = counter + 1;
                                    int j = 4;
                                    for (int x = igsv; x < ygsv; x++)
                                    {
                                        if (parts[j].Contains("*"))
                                        {
                                            string[] xyz = Convert.ToString(parts[j]).Split('*');
                                            if (xyz[0] != "") { parts[j] = xyz[0]; }
                                            else { parts[j] = "000"; }
                                        }
                                        if (parts[j] == "") { parts[j] = "000"; }
                                        if (parts.Length > j)
                                        {
                                            partsnew[x] = parts[j];
                                        }
                                        j = j + 1;
                                    }
                                    igsv = ygsv;
                                    ygsv = ygsv + 16;
                                }
                                if (GPGL.Contains("RMC")) {
                                    partsnew[1] = parts[1];
                                    StringBuilder sb = new StringBuilder();
                                    var date1 = parts[9].ToString();
                                    for (int i = 0; i < date1.Length; i++)
                                    {
                                        if (i % 2 == 0)
                                            sb.Append(' ');
                                        sb.Append(date1[i]);
                                    }
                                    partsnew[0] = Convert.ToString(sb);
                                    rmcoccured = 1;
                                }
                                #endregion
                                parts = null;
                            }
                                count = count + 1;
                                if ((zdaoccured == 1) || (rmcoccured == 1))
                            {
                                StringBuilder line1 = new StringBuilder();
                                for (int i = 0; i < 99; i++)
                                {
                                    line1.Append(partsnew[i] + ",");
                                }
                                line1.Append(partsnew[99]);
                                finalline.Append(line1);
                                Users.Add(new User(Convert.ToString(finalline)));
                                finalline = new StringBuilder();
                                partsnew = new string[100];
                                zdaoccured = 0;
                                rmcoccured = 0;
                                igsv = 18;
                                ygsv = 34;
                                counter = 0;
                            }
                        }
                        databind(Users);
                    }
                    else
                    {label1.Text = "Not a valid file";}
                }
            }
            catch (Exception ex) { MessageBox.Show("Error:" + ex.ToString()); }
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
                            dataGridView1.Rows.Add(o.Date, o.Time, o.latitude, o.longitude, o.altitude, o.quality, o.pdop, o.hdop, o.vdop, o.GPS, o.GPSused, o.GLO, o.GLOused,o.GAL,o.GALused, o.totalSV, o.totalSVused,o.PRN,o.Eleivation, o.Azimuth, o.SNR, o.more);
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
            catch (Exception ex) { MessageBox.Show("Error:" + ex.ToString()); }
        }
        class User
        {
            #region public properties
            public string Date { get; set; }
            public string Time { get; set; }
            public string latitude { get; set; }
            public string min { get; set; }
            public string second { get; set; }
            public string longitude { get; set; }
            public string altitude { get; set; }
            public string quality { get; set; }
            public string pdop { get; set; }
            public string hdop { get; set; }
            public string vdop { get; set; }
            public string GPS { get; set; }
            public string GPSused { get; set; }
            public string GLO { get; set; }
            public string GLOused { get; set; }
            public string GAL { get; set; }
            public string GALused { get; set; }
            public string totalSV { get; set; }
            public string totalSVused { get; set; }
            public string PRN { get; set; }
            public string Eleivation { get; set; }
            public string Azimuth { get; set; }
            public string SNR { get; set; }
            public string more { get; set; }
            #endregion

            public User(string line)
            {
                try
                {
                    string[] parts = line.Split(',');
                    this.GPS = parts[11];
                    this.GPSused = parts[12];
                    this.GLO = parts[13];
                    this.GLOused = parts[14];
                    this.GAL = parts[98];
                    this.GALused = parts[99];
                    this.latitude = parts[2]; this.quality = "1";
                    this.longitude = parts[5]; this.altitude = parts[9];
                    this.pdop = parts[15]; this.hdop = parts[16];
                    string[] xx = Convert.ToString(parts[17]).Split('*');
                    this.vdop = xx[0];
                    this.Date = parts[0];
                    this.Time = parts[1];
                    this.totalSV = Convert.ToString(Convert.ToInt32(this.GPS) + Convert.ToInt32(this.GLO) + Convert.ToInt32(this.GAL));
                    this.totalSVused = Convert.ToString(Convert.ToInt32(this.GPSused) + Convert.ToInt32(this.GLOused) + Convert.ToInt32(this.GALused));
                    if (parts[18].Length < 3) { parts[18] = "0" + parts[18]; }
                    if (parts[18].Length < 3) { parts[18] = "0" + parts[18]; }
                    if (parts[19].Length < 3) { parts[19] = "0" + parts[19]; }
                    if (parts[19].Length < 3) { parts[19] = "0" + parts[19]; }
                    if (parts[20].Length < 3) { parts[20] = "0" + parts[20]; }
                    if (parts[20].Length < 3) { parts[20] = "0" + parts[20]; }
                    if (parts[21].Length < 3) { parts[21] = "0" + parts[21]; }
                    if (parts[21].Length < 3) { parts[21] = "0" + parts[21]; }
                    this.PRN = parts[18];
                    this.Eleivation = parts[19];
                    this.Azimuth = parts[20];
                    this.SNR = parts[21];
                    StringBuilder line2 = new StringBuilder();
                    for (int i = 22; i < parts.Length-1; i++)
                    {
                        if (parts[i].Length < 3) { parts[i] = "0" + parts[i]; }
                        if (parts[i].Length < 3) { parts[i] = "0" + parts[i]; }
                        line2.Append(parts[i] + "   ");
                    }
                    line2.Append(parts[parts.Length-1]);
                    this.more = line2.ToString();
                }
                catch (Exception e) { }
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

        private void button4_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                xlWorkSheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    xlWorkSheet.Cells[i + 2, j + 1] = Convert.ToString(dataGridView1.Rows[i].Cells[j].Value);
                }
            }
            xlApp.Visible = true;
            ObjectRelease(xlWorkSheet);
            ObjectRelease(xlWorkBook);
            ObjectRelease(xlApp);

        }

        private void ObjectRelease(object objRealease)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objRealease);
                objRealease = null;
            }
            catch (Exception ex)
            {
                objRealease = null;
                MessageBox.Show("Error_" + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                String RowcCount = "";
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "Save file as...";
                dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                }
                string Startuppath = dialog.FileName;
                string Destinationpath = Startuppath;
                using (StreamWriter Streamwrite = File.CreateText(Destinationpath))
                {

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        RowcCount = "";
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (RowcCount.Length > 0)
                            {
                                RowcCount = RowcCount + "  " + Convert.ToString(dataGridView1.Rows[i].Cells[j].Value);
                            }
                            else
                            {
                                RowcCount = Convert.ToString(dataGridView1.Rows[i].Cells[j].Value);
                            }
                        }
                        Streamwrite.WriteLine(RowcCount);
                    }
                    Streamwrite.WriteLine(Streamwrite.NewLine);
                    Streamwrite.Close();
                    MessageBox.Show("File Created Successfully");
                }

            }
        }
    }
}
