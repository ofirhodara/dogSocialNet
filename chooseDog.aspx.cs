using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class chooseDog : System.Web.UI.Page
{

    public string dogs = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

           
            BindGridview();       
            Dog d = (Dog)Session["dogi"];
            if (d != null)       
                Label1.Text = "  הכלב המחובר כעת הוא  " + d.GetName();
            


        }





    }

    public void BindGridview()
    {
        int id = ((Client)Session["client_now"]).GetidNum();
        DataTable dogstable = dogHelper.GetDogByOwnerID(id);
        GridView1.DataSource = dogstable;
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ID = ((Label)GridView1.Rows[GridView1.SelectedIndex].FindControl("Label2")).Text;
        Session["dogi"] = dogHelper.GetDogFromDogID(int.Parse(ID));
        Dog d = (Dog)Session["dogi"];
        Label1.Text = "  הכלב המחובר כעת הוא  " + d.GetName();

    }
}