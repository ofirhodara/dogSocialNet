using System;


using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Profile_Dog : System.Web.UI.Page
{
    public static bool mine = false;
    public static Dog dogi;
    public static Client clientDog;
    public static string prferSex, preferAge, preferSize;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string type = Request.QueryString["typ"];
            if (type == "mine")
            {
                mine = true;
                clientDog = (Client)Session["client_now"];
                dogi = (Dog)Session["dogi"];
            }
            else
            {
                mine = false;
                int id_Dog = int.Parse(Request.QueryString["id_Dogi"]);
                dogi = dogHelper.GetDogFromDogID(id_Dog);
                clientDog = ClientHelper.GetClientByID(dogi.GetOwnerID());
            }

            Image1.ImageUrl = "imagesDogs/" + dogi.GetPictureDog();
            handlePrefers();
        }



    }
    public void handlePrefers()
    {
        if (dogi.GetplayWithFemale() && dogi.GetplayWithMale())
            prferSex = "אין העדפה למין מסוים";
        else
        {
            if (dogi.GetplayWithFemale()) prferSex = "מעדיף לשחק עם נקבות";
            else prferSex = "מעדיף לשחק עם זכרים";
        }
        /////////////////////////////////////////////////////////////////////////
        int age = dogi.GetPreferAge();
        if (age == -1) preferAge = "אין העדפה לקבוצת גילאים מסוימת";
        else
        {
            if (age == 1)
                preferAge = "קבוצת גילאים צעירה (0-4)";
            else
            {
                if (age == 2)
                    preferAge = "קבוצת גילאים בינונית (5-8)";
                else
                    preferAge = "קבוצת גילאים מבוגרת (8 ומעלה)";
            }
        }
        ////////////////////////////////////////////////////////////////////////
        string size = dogi.GetPreferSize();
        if (size == "none") preferSize = "אין העדפה לגודל מסוים";
        else
        {
            if (size == "M")
                preferSize = "כלבים בגודל בינוני";
            else
            {
                if (size == "S")
                    preferSize = "כלבים בגודל קטן";
                else
                    preferSize = "כלבים בגודל גדול";
            }
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        ClientHelper.sendEmail(TextBox1.Text,((Dog)Session["dogi"]).GetName(),dogi.GetName(),((Client)Session["client_now"]).GetEmail(), clientDog.GetEmail());
        TextBox1.Text = "";
    }
}