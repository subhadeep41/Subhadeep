//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Windowapp
//{
//    public class Utility
//    {
//        public void Logic()
//        {
//            string[] parts = new string[20];
//            string[] newdata = new string[20];
//            newdata = line.Split(',');
//            if ((newdata.Length < 20) && (newdata.Length > 1))
//            {
//                for (int i = 0; i < (20 - newdata.Length); i++)
//                {
//                    line += ",";
//                    line += "00";
//                }
//            }
//            parts = line.Split(',');
//            string GPGL = parts[0];
//            if ((GPGL == "$GLGGA") || (GPGL == "$GPGGA") || (GPGL == "$GNGGA"))
//            {
//                partsnew[2] = parts[2]; partsnew[5] = parts[4];
//                partsnew[6] = parts[6]; partsnew[9] = parts[9];
//                if (filetype == "Ptype") { partsnew[14] = "0"; } else { partsnew[14] = parts[7]; }
//                if (filetype == "Ltype") { partsnew[12] = "0"; } else { partsnew[12] = parts[7]; }
//            }
//            if ((GPGL == "$GLGSA") || (GPGL == "$GPGSA") || ((GPGL == "$GNGSA")))
//            {
//                if (GPGL == "$GNGSA") { gsa = gsa + 1; }
//                partsnew[15] = parts[15];
//                partsnew[16] = parts[16]; partsnew[17] = parts[17];
//                int pos = Array.IndexOf(parts, "");
//                int x = pos - 3;
//                if (gsa == 1)
//                {
//                    if (filetype == "Xtype") { partsnew[12] = Convert.ToString(x); }
//                }
//                if (gsa == 2)
//                {
//                    if (filetype == "Xtype") { partsnew[14] = Convert.ToString(x); }
//                    gsa = 0;
//                }
//            }
//            if ((GPGL == "$GLZDA") || (GPGL == "$GPZDA") || (GPGL == "$GNZDA"))
//            {
//                partsnew[1] = parts[1];
//                StringBuilder sb = new StringBuilder();
//                sb.Append(parts[2] + " ");
//                sb.Append(parts[3] + " ");
//                sb.Append(parts[4]);
//                partsnew[0] = Convert.ToString(sb);
//            }
//            if (GPGL == "$GPGSV")
//            {
//                if (gsv == 0)
//                {
//                    partsnew[11] = parts[3];
//                }
//                gsv = gsv + 1;
//            }
//            else
//            {
//                gsv = 0;
//            }
//            if ((GPGL == "$GLGSV"))
//            {
//                partsnew[13] = parts[3];
//            }
//            if ((GPGL.Contains("GSV")) && (counter < 5))
//            {
//                counter = counter + 1;
//                int j = 4;
//                for (int x = igsv; x < ygsv; x++)
//                {
//                    if (parts[j].Contains("*"))
//                    {
//                        string[] xyz = Convert.ToString(parts[j]).Split('*');
//                        if (xyz[0] != "") { parts[j] = xyz[0]; }
//                        else { parts[j] = "00"; }
//                    }
//                    if (parts[j] == "") { parts[j] = "00"; }
//                    if (parts.Length > j)
//                    {
//                        partsnew[x] = parts[j];
//                    }
//                    j = j + 1;
//                }
//                igsv = ygsv;
//                ygsv = ygsv + 16;
//            }
//            else
//            {
//                igsv = 18;
//                ygsv = 34;
//                counter = 0;
//            }
//        }
//    }
//}
