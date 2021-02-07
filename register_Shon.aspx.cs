using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;


public partial class register_Shon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            handleBreedDropboxes();

        }

    }
    public void handleBreedDropboxes()
    {
        for (int i = 1921; i < 2007; i++)
        {
            ListItem year = new ListItem(i.ToString(), i.ToString(), true);//TEXT,VALUE
            DropDownList10.Items.Add(year);
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ClientHelper.ifEmail(email_.Text) && ClientHelper.ifTz(tz.Text))
        {
            Client client = new Client(addresss.Text, int.Parse(tz.Text), int.Parse(tel.Text), email_.Text, prati.Text, last_name.Text, int.Parse(DropDownList10.Text), pass1.Text,false);
            ClientHelper.buildClient(client);

            Session["client_now"] = client;
            Session["pail"] = true;
            Response.Redirect("logIn.aspx");
        }
        else
            erorLabel.Text = "מייל או תעודת זהות תפוסים";
    }


}