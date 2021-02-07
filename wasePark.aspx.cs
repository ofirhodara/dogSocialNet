using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class wasePark : System.Web.UI.Page
{
    public static string returnTO="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int idPark = int.Parse(Request.QueryString["id"]);
            Session["dest"] = parkDogsHelper.GetAddByID(idPark);
            Session["userAddress"] = "הארז 37 פרדסיה";
            returnTO = "<a href='Park_View.aspx?id="+idPark+"'><input type='button' value='חזרה לפרטי הגינה' /></a>";
        }

    }
}