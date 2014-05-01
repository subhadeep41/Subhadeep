using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
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
#if X86 // 32-bit
        string _connectionStringTemplate = "Driver={{Microsoft Text Driver (*.txt; *.csv)}};Extensions=asc,csv,tab,txt;Persist Security Info=False;Dbq={0}";
#else // 64-bit
            string _connectionStringTemplate = "Driver={{Microsoft Access Text Driver (*.txt, *.csv)}};Dbq={0};Extensions=asc,csv,tab,txt";
#endif
            string file = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
            string connectionString = string.Format(_connectionStringTemplate, @"C:\Users");

            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                string selectAll = string.Format("select * from [{0}]", Path.GetFileName(FileUpload1.PostedFile.FileName));

                using (OdbcCommand command = new OdbcCommand(selectAll, connection))
                {
                    connection.Open();

                    DataTable dataTable = new DataTable("txt");

                    using (OdbcDataAdapter adapter = new OdbcDataAdapter(selectAll, connection))
                    {
                        //Fills dataset with the records from file
                        adapter.Fill(dataTable);
                        grdViewCustomers.DataSource = dataTable;
                        grdViewCustomers.DataBind();
                    }
                }
            }

        }

        #region compare
        public class Row
        {
            public string Column1 { get; set; }
            public string Column2 { get; set; }
            public string Column3 { get; set; }
            public string Column4 { get; set; }
            public string Column5 { get; set; }
            public string Column6 { get; set; }
        }
        public class RowComparer : IComparer<Row>
        {
            private List<string> myOrder = new List<string>(new string[] { "FIDUCIAL", "1111", "2222", "DDDD", "4444" });

            private int primaryOrder(Row x)
            {
                int index = myOrder.FindIndex(v => x.Column6.Contains(v));
                return (index >= 0) ? index : myOrder.Count;
            }

            public int Compare(Row x, Row y)
            {
                int result = primaryOrder(x).CompareTo(primaryOrder(y));
                if (result != 0)
                    return result;

                return x.Column2.CompareTo(y.Column2);
            }
        }
        #endregion
    }
}