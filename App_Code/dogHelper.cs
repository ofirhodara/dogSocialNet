using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;


public static class dogHelper
{
    static string fileName = "masadPjct.accdb";
   
    public static int GetGrade(Dog myDog, Dog dog_To_Compare)// פונקציה המשקללת ציון התאמה בין שני כלבים לפי כל הפרמטרים 
    {
        int dist = Distance(myDog.GetDogID(), dog_To_Compare.GetDogID());//ציון לפי מרחק
        if (dist == -1) return -1; //יש בעיה בדרך הניווט, הפונקציה מחזירה -1           
        int gender = GenderCheck(myDog.GetplayWithMale(), myDog.GetplayWithFemale(), dog_To_Compare.GetGender());//ציון לפי מין
        int breed = breedeCheck(myDog.GetDogID(), dog_To_Compare.GetDog_breedID());//ציון לפי גזע
        int age = compareAge(myDog.GetPreferAge(), dog_To_Compare.GetbirthYear());//ציון לפי קבוצת גיל
        int size = CompareSize(myDog.GetPreferSize(), dog_To_Compare.GetSize());//ציון לפי גודל
        return dist + gender + breed + age + size;//שקלול כל הציונים לפי הפרמטרים הרבים
    }

    public static DataTable GetDataTabeFromList(List<int> keys)
    {
        string sql1 = "SELECT dogg.DogID,dogg.DogName, dogg.pictureDog, clients.address_ ";
        sql1 += "FROM dogg INNER JOIN clients ON dogg.OwenrID=clients.clientID WHERE ";
        int count = keys.Count;
        for (int i = 0; i < count - 1; i++)
            sql1 += "DogID=" + keys[i].ToString() + " OR ";
        sql1 += "DogID=" + keys[count - 1].ToString() + ";";
        DataTable dt = MyAdoHelper.ExecuteDataTable(fileName, sql1);
        return dt;
    }


    public static DataTable GetDataWithoutCurrent(int ownerID)
    {
        string sql1 = "SELECT * FROM dogg WHERE OwenrID <> " + ownerID + ";";       
        DataTable dt = MyAdoHelper.ExecuteDataTable(fileName, sql1);
        return dt;
    }



    public static int GetMeters(string url)// פונקציה מקבל מחרוזת url 
    {
        WebRequest request = WebRequest.Create(url);//יצירת אובייקט בקשה משרת
        WebResponse response = request.GetResponse();//יצירת אובייקט תשובה משרת
        Stream data = response.GetResponseStream();
        StreamReader reader = new StreamReader(data);
        string responseFromServer = reader.ReadToEnd();//מחרוזת מפורמט json המכילה תשובה לאחר יצירת בקשה request
        response.Close();//סגירת הקשר לשרת
        JObject o = JObject.Parse(responseFromServer);//יצירת אובייקט מסוג JObject על מנת לקבל יכולת לקרוא את הנתונים בצורה מיטבית

        if (o["status"].ToString() != "ZERO_RESULTS")//אם נמצאו דרכי ניווט
            return int.Parse(o["routes"][0]["legs"][0]["distance"]["value"].ToString());//מחזירה את המרחק במטרים לפי שני כתובות הנמצאות בפרמטרים במחרוזת url
        return -1;//לא נמצאו דרכי הגעה 
    }

    public static string GetOwnerAddressByID(int dogID)
    {
        string sql1 = "SELECT OwenrID FROM dogg WHERE DogID=" + dogID + ";";
        DataTable dt = MyAdoHelper.ExecuteDataTable(fileName, sql1);
        int ownerID = int.Parse(dt.Rows[0].ItemArray[0].ToString());
        sql1 = "SELECT address_ FROM clients WHERE clientID=" + ownerID + ";";
        return MyAdoHelper.ExecuteDataTable(fileName, sql1).Rows[0].ItemArray[0].ToString();

    }

    public static int GetDistGrade(int meters) 
    {


        if (meters < 5000) return 7;//מרחק נמוך 
        if (meters > 5000 && meters < 10000) return 5;//מרחק קרוב
        if (meters > 10000 && meters < 20000) return 3;//מרחק בינוני
        if (meters > 20000 && meters < 35000) return 1;//מרחק רחוק

        return -25;//רחוק מאוד


    }

    public static int Distance(int mydogID, int dog_to_compare_ID)
    {
        string address_1 = GetOwnerAddressByID(mydogID);
        string address_2 = GetOwnerAddressByID(dog_to_compare_ID);
        string url = @"https://maps.googleapis.com/maps/api/directions/json?origin=" + address_1 + "&destination=" + address_2 + "&key=AIzaSyCpJlsjlI2aKN4EubuHyf1RxGrwY6JxnZM";//יצירת בקשת http
        int meters = GetMeters(url);//מרחק בין שתי הכתובת 
        if (meters > 0)
            return GetDistGrade(meters);//אם נמצא דרכי ניווט, מחזיר ציון משוקלל
        return -1;
    }//מחזירה ציון משוקלל למרחת בין שני כתובת מגורים של כלבים

    public static int GenderCheck(bool playWithMale, bool playWithFemale, string gender_other)
    {

        if (playWithFemale && playWithMale)//אין העדפה למין מסוים
            return 3;

        if (playWithMale && !playWithFemale)//כלב אוהב לשחק עם זכרים בלבד
        {
            if (gender_other == "M") return 5;//יש התאמה מיטבית
            return 0;
        }
        if (gender_other == "F") return 5;// כלב אוהב לשחק עם נקבות בלבד,יש התאמה מיטבית
        return 0;
    }

    public static int compareAge(int preferAge, int birthyear_other)
    {
        if (preferAge == -1) return 3;//יש התאמה, לכלב אין העדפה לקבוצת גילאים מסוימת
        DateTime moment = DateTime.Now;//שנה נוכחית
        int difference = moment.Year - birthyear_other;//גיל הכלב המקבל ציון

        int diffrenceType = 0;

        if (difference >= 0 && difference <= 4) diffrenceType = 0;//קבוצת גילאים קטנה
        else
        {
            if (difference >= 8) diffrenceType = 3;//קבוצת גילאים מבוגרת
            else { diffrenceType = 2; }//קבוצת גילאים בינונית
        }


        if (diffrenceType == preferAge) return 5;//האתמה מושלמת בין העדפת גיל לגיל הכלב בפועל

        if (Math.Abs(diffrenceType - preferAge) == 1) return 3;//הבדל של קטגורייה אחת,התאמה בינונית
        return 0;//אין התאמה בכלל      
    } 

    public static int breedeCheck(int dog1ID, int dog2BreedeID)
    {
        int grade = 0;
        string sql = "SELECT * FROM loveBreed WHERE dogID=" + dog1ID + " AND breedID=" + dog2BreedeID + ";";
        DataTable dt = MyAdoHelper.ExecuteDataTable(fileName, sql);
        if (dt.Rows.Count != 0)//     
            grade = 4;
        return grade;
    }

    public static int CompareSize(string FavoriteSize, string size_other)
    {
        if (FavoriteSize == "none")
            return 3;//קיימת התאמה בינונית, לכלב איו העדפה לגודל כלב מסוים למשחק

        if (FavoriteSize == size_other) return 5;//התאמה מיטבית

        if ((FavoriteSize == "S" && size_other == "M") || (FavoriteSize == "M" && size_other == "S"))
            return 3;//התאמה בינונית
        if ((FavoriteSize == "M" && size_other == "L") || (FavoriteSize == "L" && size_other == "M"))
            return 3;//התאמה בינונית
        return 0; // אין התאמה לחלוטין      
    }

    public static Dog GetDogFromDataRow(DataRow r)
    {

        bool withMale = bool.Parse(r.ItemArray[7].ToString().ToLower());
        bool withFeMale = bool.Parse(r.ItemArray[6].ToString().ToLower());
        return new Dog(r.ItemArray[11].ToString(), r.ItemArray[10].ToString(), int.Parse(r.ItemArray[12].ToString()), r.ItemArray[9].ToString(), withFeMale, withMale, r.ItemArray[1].ToString(), r.ItemArray[5].ToString(), r.ItemArray[8].ToString(), int.Parse(r.ItemArray[2].ToString()), int.Parse(r.ItemArray[3].ToString()), int.Parse(r.ItemArray[0].ToString()), int.Parse(r.ItemArray[4].ToString()));

    }

    public static Dog GetDogFromDogID(int id)
    {


        string sql1 = "SELECT * FROM dogg WHERE DogID=" + id + ";";
        DataTable dt = MyAdoHelper.ExecuteDataTable("masadPjct.accdb", sql1);
        return GetDogFromDataRow(dt.Rows[0]);





    }
    public static string GetDogFromDogID2(int id)
    {


        string sql1 = "SELECT * FROM dogg WHERE DogID=" + id + ";";
        DataTable dt = MyAdoHelper.ExecuteDataTable(fileName, sql1);

        return dt.Rows[0].ItemArray[0].ToString();





    }


    public static int MaxDOG_id()
    {
        string sql1 = "SELECT MAX(DogID) FROM dogg;";
        DataTable dt = MyAdoHelper.ExecuteDataTable(fileName, sql1);
        return int.Parse(dt.Rows[0].ItemArray[0].ToString());

    }

    public static int buildDog(Dog d)//מוסיפה כלב ומחזירה את המספר שלו
    {
        string sqlS = "INSERT INTO dogg (DogName,OwenrID,birthYear,color,pictureDog,dogsize,preferSize,preferAge,Gender,playWithMales,playWithFemale,Dog_breedID) VALUES ('" + d.GetName() + "'," + d.GetOwnerID() + "," + d.GetbirthYear() + ",'" + d.GetColor() + "','" + d.GetPictureDog() + "','" + d.GetSize() + "','" + d.GetPreferSize() + "'," + d.GetPreferAge() + ",'" + d.GetGender() + "'," + d.GetplayWithMale().ToString() + "," + d.GetplayWithFemale().ToString() + "," + d.GetDog_breedID() + ");";
        MyAdoHelper.DoQuery(fileName, sqlS);
        return MaxDOG_id();
    }
    public static DataTable GetDogByOwnerID(int ownerID)
    {
        string sql1 = "SELECT * FROM dogg WHERE OwenrID=" + ownerID + ";";
        DataTable dt = MyAdoHelper.ExecuteDataTable(fileName, sql1);
        return dt;
    }

    public static void deleteDogsByID(int id)
    {
        string sqls = "DELETE * FROM dogg WHERE OwenrID=" + id + ";";
        MyAdoHelper.DoQuery(fileName, sqls);
    }
}