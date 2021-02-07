using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class editDogg : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {         
            BindDetailsView();
            BindGridview();           
        }
    }

    public void BindDetailsView()
    {
        string sql = "SELECT * FROM dogg WHERE DogID=" + ((Dog)Session["dogi"]).GetDogID();
        DataTable dt = MyAdoHelper.ExecuteDataTable("masadPjct.accdb", sql);
        DetailsView1.DataSource = dt;
        DetailsView1.DataBind();
        if (DetailsView1.CurrentMode != DetailsViewMode.Edit)
        {
            Label preferAge = DetailsView1.FindControl("lbl_ageP") as Label;
            if (preferAge.Text == "-1") preferAge.Text = "אין העדפה";
            if (preferAge.Text == "1") preferAge.Text = "1-4";
            if (preferAge.Text == "2") preferAge.Text = "5-8";
            if (preferAge.Text == "3") preferAge.Text = "8 ומעלה";

            Label dogsize = DetailsView1.FindControl("lbl_size") as Label;
            if (dogsize.Text == "S") dogsize.Text = "קטן";
            if (dogsize.Text == "M") dogsize.Text = "בינוני";
            if (dogsize.Text == "L") dogsize.Text = "גדול";


            Label prederSize = DetailsView1.FindControl("lbl_prederSize") as Label;
            if (prederSize.Text == "S") prederSize.Text = "קטן";
            if (prederSize.Text == "M") prederSize.Text = "בינוני";
            if (prederSize.Text == "L") prederSize.Text = "גדול";
        }
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

        DropDownList size = (DropDownList)DetailsView1.FindControl("DropDownList1");
        DropDownList preferAgee = (DropDownList)DetailsView1.FindControl("DropDownList3");
        DropDownList prefersizee = (DropDownList)DetailsView1.FindControl("DropDownList2");
        DropDownList female = (DropDownList)DetailsView1.FindControl("DropDownList5");
        bool ifFemale = female.SelectedValue == "yess";
        DropDownList male = (DropDownList)DetailsView1.FindControl("DropDownList4");
        bool ifmale = male.SelectedValue == "yess";



        string sql = "UPDATE dogg SET dogsize='" + size.SelectedValue + "',preferAge='" + preferAgee.SelectedValue + "',preferSize='" + prefersizee.SelectedValue + "',playWithFemale=" + ifFemale + ",playWithMales=" + ifmale + " WHERE DogID=" + ((Dog)Session["dogi"]).GetDogID() + ";";

        MyAdoHelper.DoQuery("masadPjct.accdb", sql);

        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);

        BindDetailsView();

    }
    protected void deleteItem1(object sender, DetailsViewDeleteEventArgs e)//מחיקת הכלב 
    {
        LoveBreedHelper.deleteByID(((Dog)Session["dogi"]).GetDogID());
        dogHelper.deleteDogsByID(((Dog)Session["dogi"]).GetDogID());
        Response.Redirect("chooseDog.aspx");
    }

    public void BindGridview()
    {
        string sql = "SELECT breeds.b_name FROM breeds INNER JOIN loveBreed ON loveBreed.breedID = breeds.breedID WHERE loveBreed.dogID = " + ((Dog)Session["dogi"]).GetDogID() + "; ";
        DataTable dt = MyAdoHelper.ExecuteDataTable("masadPjct.accdb", sql);      
        GridView1.DataSource = dt;
        GridView1.DataBind();        

       
    }

    protected void GridView1_Editing(object sender, GridViewEditEventArgs e)
    {
      
        GridView1.EditIndex = e.NewEditIndex;
        BindGridview();
    }
    protected void GridView1_Cancel(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindGridview();
    }
    protected int formerBreed(int index)
    {
        string sql = "SELECT breeds.breedID FROM breeds INNER JOIN loveBreed ON loveBreed.breedID = breeds.breedID WHERE loveBreed.dogID = " + ((Dog)Session["dogi"]).GetDogID() + "; ";
        DataTable dt = MyAdoHelper.ExecuteDataTable("masadPjct.accdb", sql);
        return int.Parse(dt.Rows[index].ItemArray[0].ToString());
    }
    protected void GridView1_Update(object sender, GridViewUpdateEventArgs e)
    {



        DropDownList newBreed = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList2");

        int lastB=formerBreed(e.RowIndex);

        string sql = "UPDATE loveBreed SET breedID=" + newBreed.SelectedValue + " WHERE dogID=" + ((Dog)Session["dogi"]).GetDogID() + " AND breedID=" + lastB + ";";


        MyAdoHelper.DoQuery("masadPjct.accdb", sql);

 
        GridView1.EditIndex = -1;
        BindGridview();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowState == DataControlRowState.Edit)
        {         
            DropDownList breeds = (DropDownList)e.Row.FindControl("DropDownList2");
            DataTable dt = breedHelper.GetDataBreeds();
            foreach (DataRow r in dt.Rows)
            {               
                ListItem breed = new ListItem(r.ItemArray[1].ToString(), r.ItemArray[0].ToString(), true);//TEXT,VALUE
                breeds.Items.Add(breed);              
            }           
        }
    }
}