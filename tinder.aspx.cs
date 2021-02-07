using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OleDb;
using System.Collections.Generic;

public partial class tinder : System.Web.UI.Page
{
    public string trystring = "";
    public string tryJS = "";
    //מערכת חיפוש דינאמית
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            makeTinder();
    }

    public void makeTinder()
    {
        Dog d = (Dog)Session["dogi"];  // יצירת אובייקט כלב מחובר    
        Dictionary<int, int> dictDogs = new Dictionary<int, int>();//יצירת מילון, המפתח הוא מזהה כלב והערך הוא ציון ההתאמה שהוענק לו
        DataTable dt = dogHelper.GetDataWithoutCurrent(d.GetOwnerID());//קבלת כל המידע על כלבי האתר מלבד הכלב הרשום וכלבים הנמצאים במשפחתו
        Dog otherDog;
        foreach (DataRow r in dt.Rows)
        {
            int currentID = int.Parse(r.ItemArray[0].ToString());//מייצג מזהה כלב
            otherDog = dogHelper.GetDogFromDataRow(r);//יוצר אובייקט כלב 
            dictDogs.Add(currentID, dogHelper.GetGrade(d, otherDog));//הוספת מזהה הכלב וציון ההתאמה לאחר הפעלת פונקציה מתן הציון
        }
        handleImg(ToList(dictDogs));//קריאה לפונקציה המטפלת בתמונות
    }

    public List<int> ToList(Dictionary<int, int> dict)//פונקציה המחזירה רשימה של 7 מזההי הכלבים שקיבלו את הציון הגבוה ביותר - ממוינת
    {
        List<int> keySort = new List<int>();
        foreach (var item in dict.OrderByDescending(r => r.Value).Take(7))//שימוש בלינק, מיון המילון מהערך הגבוה לנמוך
            keySort.Add(item.Key);//הוספת מזהה הכלב לרשימה שנוצרה
        return keySort;
    }

    public void handleImg(List<int> lst)//פונקציה מקבלת רשימה של מספרים שלמים ומטפלת בהצגת תמונות הכלבים 
    {
        DataTable dt = dogHelper.GetDataTabeFromList(lst);
        int i = 1;
        foreach (DataRow r in dt.Rows)
        {
            trystring += "<div class='mySlides fade'>";
            trystring += "<div class='numbertext'>" + i + "/" + dt.Rows.Count + "</div>";
            trystring += "<a href='Profile_Dog.aspx?id_Dogi=" + r.ItemArray[0].ToString() + "'>";
            trystring += "<img src='imagesDogs/" + r.ItemArray[2].ToString() + "'  style='height:400px;width:100%' />";
            trystring += "</a>";
            trystring += "<div class='text' style='font-size:xx-large;color:black'>" + r.ItemArray[1].ToString() + " - " + r.ItemArray[3].ToString() + "</div>";
            trystring += "</div>";
            i++;
        }
    }



}