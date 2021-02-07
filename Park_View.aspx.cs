using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;


public partial class Park_View : System.Web.UI.Page
{
    public static park_Dogs park;
    public static string comments = "";
    public static string toNavigate = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            int id = int.Parse(Request.QueryString["id"]);
            park = parkDogsHelper.GetParkByID(id);
            handleComments();
            handlePhotosPark();
            handlePhotosDetails();
            toNavigate = "<a href='wasePark.aspx?id=" + id + "'><input type='button' value='נווט לגינה הכלבים' /></a>";

        }
    }
    public void handlePhotosPark()
    {
        string firstUrl = "img_parks/park" + park.GetparkID() + "_1.jpg";
        string SecUrl = "img_parks/park" + park.GetparkID() + "_2.jpg";

        SmallImg.Attributes["src"] = ResolveUrl(firstUrl);
        mainImg.Attributes["src"] = ResolveUrl(SecUrl);
    }
    public void handlePhotosDetails()
    {
        string WaterUrl = " ";
        if (park.GeTIfWater() == "yes")
            WaterUrl = "img_parks/Vsign.png";
        else WaterUrl = "img_parks/Xsign.png";

        ///////////////////////////////////////
        string SEATUrl = " ";
        if (park.GetifSeatble() == "yes")
            SEATUrl = "img_parks/Vsign.png";
        else SEATUrl = "img_parks/Xsign.png";

        ///////////////////////////////////////
        string ShadowUrl = " ";
        if (park.GetifShadow() == "yes")
            ShadowUrl = "img_parks/Vsign.png";
        else ShadowUrl = "img_parks/Xsign.png";

        ///////////////////////////////////////
        string iluf_Url = " ";
        if (park.GetifToys() == "yes")
            iluf_Url = "img_parks/Vsign.png";
        else iluf_Url = "img_parks/Xsign.png";


        WaterImg.Attributes["src"] = ResolveUrl(WaterUrl);
        SEATImg.Attributes["src"] = ResolveUrl(SEATUrl);
        ilufImg.Attributes["src"] = ResolveUrl(iluf_Url);
        ShadowImg.Attributes["src"] = ResolveUrl(ShadowUrl);
    }
    public void handleComments()
    {
        string com = "";
        string name;
        string date;

        DataTable dt = parkDogsHelper.GetCommentsToParkByID(park.GetparkID());
        int i = 0;
        foreach (DataRow comment in dt.Rows)
        {
            date = comment.ItemArray[3].ToString();
            name = comment.ItemArray[0].ToString() + " " + comment.ItemArray[1].ToString();
            com += "<h3> " + (name + " " + date) + " </h3>";
            com += "<h5> " + comment.ItemArray[2].ToString() + " </h5>  <br />";
            if (i == 4)
                break;
            i++;
        }
        comments = com;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Length != 0)
        {
            Client c = (Client)Session["client_now"];
            rate bikoret = new rate(park.GetparkID(), c.GetidNum(), TextBox1.Text, DateTime.Now.ToString());
            ratesHelper.AddRate(bikoret);
            TextBox1.Text = "";
            handleComments();

        }
    }
}