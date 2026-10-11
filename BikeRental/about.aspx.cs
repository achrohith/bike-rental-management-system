
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace BikeRental
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(WebForm2)); 

        protected void Page_Load(object sender, EventArgs e)
        {
            logger.Info("Page loaded: about "); 
        }
    }
}
