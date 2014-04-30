using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ShowButton_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Address");

            using (StreamReader sr = new StreamReader(@"C:\Users\test.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] parts = sr.ReadLine().Split(':');
                    table.Rows.Add(parts[0], parts[1]);
                }
            }
            grdViewCustomers.DataSource = table;
            grdViewCustomers.DataBind();
        }
    }
}