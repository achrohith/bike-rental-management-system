using BikeRental.APPCODE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BikeRental
{
    public partial class updatebike : System.Web.UI.Page
    {
  
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllBikes();
            }
        }
        private void LoadAllBikes()
                 
        {
            BL bikeBLL = new BL();
            gvBikes.DataSource = bikeBLL.GetAllBikes();
            gvBikes.DataBind();
        }
        BL bikeBLL = new BL();
        protected void gvBikes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int bikeId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Increase")
            {
                bikeBLL.IncreaseAvailability(bikeId);
            }
            else if (e.CommandName == "Decrease")
            {
                bikeBLL.DecreaseAvailability(bikeId);
            }
            LoadAllBikes(); 
        }

    }
}