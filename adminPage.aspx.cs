using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class adminPage : System.Web.UI.Page
{
    public int userId = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateDropdown();
            BindDetailsView();
        }
    }
    public void BindDetailsView()
    {
        if (DropDownList1.SelectedValue != null)
        {
            userId = Convert.ToInt32(DropDownList1.SelectedValue);
        }

        string sql = "SELECT * FROM clients WHERE clientID=" + userId.ToString();
        DataTable dt = MyAdoHelper.ExecuteDataTable("masadPjct.accdb", sql);

        DetailsView1.DataSource = dt;
        DetailsView1.DataBind();
    }

    public void PopulateDropdown()
    {
        DropDownList1.Items.Clear();
        string sql = "SELECT * FROM clients WHERE isAdmin=false";
        DataTable dt = MyAdoHelper.ExecuteDataTable("masadPjct.accdb", sql);
        ListItem li;

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            li = new ListItem();
            li.Value = dt.Rows[i]["clientID"].ToString();
            li.Text = dt.Rows[i]["firstName"].ToString() + " " + dt.Rows[i]["lastName"].ToString();
            DropDownList1.Items.Add(li);
        }

        userId = Convert.ToInt32(DropDownList1.SelectedValue);
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        userId = Convert.ToInt32(DropDownList1.SelectedValue);
        BindDetailsView();
    }

    protected void DetailsView1_Edit(object sender, DetailsViewModeEventArgs e)
    {
        switch (e.NewMode)
        {
            case DetailsViewMode.ReadOnly:
                DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                break;
            case DetailsViewMode.Edit:
                DetailsView1.ChangeMode(DetailsViewMode.Edit);
                break;
        }

       
        BindDetailsView();
    }

    protected void DetailsView1_Update(object sender, DetailsViewUpdateEventArgs e)
    {
        TextBox email = DetailsView1.FindControl("tb_Email") as TextBox;
        TextBox lName = DetailsView1.FindControl("tb_lName") as TextBox;
        TextBox fName = DetailsView1.FindControl("tb_fName") as TextBox;
        TextBox pass = DetailsView1.FindControl("tb_pass") as TextBox;
        TextBox addrs = DetailsView1.FindControl("tb_address_") as TextBox;
        TextBox pn = DetailsView1.FindControl("tb_phoneNum") as TextBox;
        TextBox by = DetailsView1.FindControl("tb_birthh") as TextBox;
        Label id = DetailsView1.FindControl("lbl_userId") as Label;

        string sql = "UPDATE clients SET birthh=" + by.Text + ",phoneNum='" + pn.Text + "',address_='" + addrs.Text + "',email_='" + email.Text + "',lastName = '" + lName.Text + "',password_='" + pass.Text + "', firstName='" + fName.Text + "'  WHERE clientID=" + id.Text + ";";
        MyAdoHelper.DoQuery("masadPjct.accdb", sql);
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        BindDetailsView();

    } 
    
    protected void deleteItem1(object sender, DetailsViewDeleteEventArgs e)
    {

        Label id = DetailsView1.FindControl("lbl_userId") as Label;
        ClientHelper.deleteClientByID(int.Parse(id.Text));
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        PopulateDropdown();
        BindDetailsView();

    }
}