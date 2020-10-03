using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Web.Services.Description;
using System.Runtime.Remoting.Messaging;

namespace ProcessAppWebMvc
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                OracleConnection ora = new OracleConnection("DATA SOURCE = PRUEBA ; PASSWORD =  Portafolio2020;  USER ID = SYSTEM;");
                ora.Open();
            }
            catch (Exception)
            {
                
                throw;
            }
           
            
        }
    }
}