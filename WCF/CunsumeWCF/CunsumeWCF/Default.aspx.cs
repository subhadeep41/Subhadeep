using System;
using MyCalculatorServiceProxy;

namespace CunsumeWCF
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Button2_Click(object sender, EventArgs e)
        {
            Class1.MyCalculatorServiceProxy proxy;
            proxy = new Class1.MyCalculatorServiceProxy();
            int sum = proxy.Add(Convert.ToInt32(text1.Value), Convert.ToInt32(text2.Value));
            Label1.Text = sum.ToString();
        }
    }
}