using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Client search = ClientHelper.ifExist(pass.Text, email_.Text);
        if (search != null)
        {
            Session["client_now"] = search;
            Session["pail"] = true;
            if (search.GetisAdmin())
                Session["isAdmin"] = true;
            Response.Redirect("chooseDog.aspx");


        }
        else
            ErorText.Text = "מייל או סיסמא לא נכונים. נסה שנית בבקשה.";
    }
}