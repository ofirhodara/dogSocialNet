using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MasterShon : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = parkDogsHelper.GetNameParksAndID();
            foreach (DataRow r in dt.Rows)
            {
                MenuItem name = new MenuItem();
                name.Text = r.ItemArray[0].ToString();
                int park_ID = int.Parse(r.ItemArray[1].ToString());
                name.NavigateUrl = "Park_View.aspx?id="+ park_ID;
                menuParks.Items.Add(name);
            }
        }
    }
}
