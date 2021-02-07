using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceReferenceShon;
using System.Data;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;


public partial class viewVetrinars : System.Web.UI.Page
{
    private names_ServiceSoapClient vetService = new names_ServiceSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)                        
            handleDropDownList();             
        
    }
    public void handleDropDownList() 
    {
        DataTable dt = vetService.GetAllAreas().Tables[0];
        foreach (DataRow r in dt.Rows)
        {
            ListItem l = new ListItem(r.ItemArray[1].ToString(), r.ItemArray[0].ToString(), true);
            DropDownList1.Items.Add(l);
        }

        ListItem last = new ListItem("כל הארץ", "-1", true);
        DropDownList1.Items.Add(last);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int value_DropDown = int.Parse(DropDownList1.SelectedValue);
        DataTable dt = vetService.GetVets(value_DropDown).Tables[0];
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
      
        GridView gv = sender as GridView;

        
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //create the first row
            GridViewRow extraHeader1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
           

            TableCell cell1 = new TableCell();
            cell1.ColumnSpan = 1;
            cell1.Text = "שם";
            cell1.Font.Size = 20;
            

            extraHeader1.Cells.Add(cell1);

            TableCell cell2 = new TableCell();
            cell2.ColumnSpan = 1;
            cell2.Text = "כתובת";

            cell2.Font.Size = 20;
           

            extraHeader1.Cells.Add(cell2);

            TableCell cell3 = new TableCell();
            cell3.ColumnSpan = 1;
            cell3.Text = "מספר טלפון";
            cell3.Font.Size = 20;

            extraHeader1.Cells.Add(cell3);

            //add the new rows to the gridview  
            gv.Controls[0].Controls.AddAt(0, extraHeader1);
        }
    }
}