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
        int gsv = 0;
        int gsa = 0;
        List<User> Users = null;
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
                        string[] partsnew = new string[20];
                        
                        StringBuilder finalline = new StringBuilder();
                        while (true)
                        {
                            string line = reader.ReadLine();
                            if (line == null)
                            {
                                StringBuilder line1 = new StringBuilder();
                                for (int i = 0; i < 18; i++)
                                {
                                    line1.Append(partsnew[i] + ",");
                                }
                                line1.Append(partsnew[18]);
                                finalline.Append(line1);
                                Users.Add(new User(Convert.ToString(finalline)));
                                break; 
                            }
                            if (count <= 100)
                            {
                                string[] parts = null;
                                #region logic
                                parts = line.Split(',');
                                    string GPGL = parts[0];
                                    if ((GPGL == "$GLGGA") || (GPGL == "$GPGGA") || (GPGL == "$GNGGA"))
                                    {
                                        partsnew[2] = parts[2]; partsnew[5] = parts[4];
                                        partsnew[6] = parts[6]; partsnew[9] = parts[9];
                                    }
                                    if ((GPGL == "$GLGSA") || (GPGL == "$GPGSA") || ((GPGL == "$GNGSA")&&(gsa==0)))
                                    {
                                        if (GPGL == "$GNGSA")
                                        { gsa = gsa + 1; }
                                        partsnew[15] = parts[15];
                                        partsnew[16] = parts[16]; partsnew[17] = parts[17];
                                    }
                                    if ((GPGL == "$GLZDA") || (GPGL == "$GPZDA") || (GPGL == "$GNZDA"))
                                    {
                                        partsnew[1] = parts[1];
                                        StringBuilder sb = new StringBuilder();
                                        sb.Append(parts[2] + "/");
                                        sb.Append(parts[3] + "/");
                                        sb.Append(parts[4]);
                                        partsnew[0] = Convert.ToString(sb);
                                    }
                                    if (GPGL == "$GPGSV")
                                    {
                                        if (gsv == 0)
                                        {
                                            partsnew[11] = parts[3];
                                        }
                                        if (gsv == 2)
                                        {
                                            partsnew[12] = parts[3];
                                        }
                                        gsv = gsv + 1;
                                    }
                                    else
                                    {
                                        gsv = 0;
                                    }
                                    if ((GPGL == "$GLGSV"))
                                    {
                                        partsnew[13] = parts[3]; partsnew[14] = parts[3];
                                    }
                                #endregion 
                                parts = null;
                            }
                            count = count + 1;
                            if (line == "")
                            {
                                StringBuilder line1 = new StringBuilder();
                                for (int i = 0; i < 18; i++)
                                {
                                    line1.Append(partsnew[i] + ",");
                                }
                                line1.Append(partsnew[18]);
                                finalline.Append(line1);
                                Users.Add(new User(Convert.ToString(finalline)));
                                finalline = new StringBuilder();
                            }
                        }
                        
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
                            dataGridView1.Rows.Add(o.Date, o.Time, o.latitude, o.longitude, o.altitude, o.quality, o.pdop, o.hdop, o.vdop, o.GPS, o.GPSused, o.GLO, o.GLOused, o.totalSV, o.totalSVused);
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
            public string totalSV { get; set; }
            public string totalSVused { get; set; }
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
                    this.latitude = parts[2]; this.quality = parts[6];
                    this.longitude = parts[5]; this.altitude = parts[9];
                    this.pdop = parts[15]; this.hdop = parts[16];
                    string[] xx = Convert.ToString(parts[17]).Split('*');
                    this.vdop = xx[0];
                    this.Date = parts[0];
                    this.Time = parts[1];
                    this.totalSV = Convert.ToString(Convert.ToInt32(this.GPS) + Convert.ToInt32(this.GLO));
                    this.totalSVused = Convert.ToString(Convert.ToInt32(this.GPSused) + Convert.ToInt32(this.GLOused));
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
                string Startuppath = Application.StartupPath + "/";
                string Destinationpath = Startuppath + "" + DateTime.Now.ToString("dd-MMM-yyy") + ".txt";
                using (StreamWriter Streamwrite = File.CreateText(Destinationpath))
                {

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        RowcCount = "";
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (RowcCount.Length > 0)
                            {
                                RowcCount = RowcCount + "," + Convert.ToString(dataGridView1.Rows[i].Cells[j].Value);
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
