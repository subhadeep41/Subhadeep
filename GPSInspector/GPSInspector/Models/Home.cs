using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GPSInspector.Models
{
    public class Home
    { }
    public class User
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
                this.latitude = parts[2]; this.quality = parts[6];
                this.longitude = parts[5]; this.altitude = parts[9];
                this.pdop = parts[15]; this.hdop = parts[16];
                string[] xx = Convert.ToString(parts[17]).Split('*');
                this.vdop = xx[0];
                this.Date = parts[0];
                this.Time = parts[1];
                this.totalSV = Convert.ToString(Convert.ToInt32(this.GPS) + Convert.ToInt32(this.GLO));
                this.totalSVused = Convert.ToString(Convert.ToInt32(this.GPSused) + Convert.ToInt32(this.GLOused));
                this.PRN = parts[18];
                this.Eleivation = parts[19];
                this.Azimuth = parts[20];
                this.SNR = parts[21];
                StringBuilder line2 = new StringBuilder();
                for (int i = 22; i < parts.Length - 1; i++)
                {
                    line2.Append(parts[i] + "   ");
                }
                line2.Append(parts[parts.Length - 1]);
                this.more = line2.ToString();
            }
            catch (Exception e) { }
        }

        public User() { }
    }
}