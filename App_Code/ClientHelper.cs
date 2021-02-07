using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for ClientHelper
/// </summary>
public static class ClientHelper
{
    static string fileName2 = "masadPjct.accdb";
    

    public static Client ifExist(string pass, string email)
    {
        string findClent = "SELECT clientID from clients WHERE password_='" + pass + "' AND email_='" + email + "';";
        DataTable searchClient = MyAdoHelper.ExecuteDataTable(fileName2, findClent);
        if (searchClient.Rows.Count == 0) return null;
        return GetClientByID(int.Parse(searchClient.Rows[0].ItemArray[0].ToString()));
    }

    //public static string checkNames(string name)
    //{

    //    if (name.Length == 0) return "שדה חובה";


    //    string sp_Ch = "/[!@#$%^&*()_+-=[]{};':\\|,.<>/?]+/";
    //    foreach (char c in sp_Ch)
    //        if (name.IndexOf(c) != -1) return "אסור ששם יכלול סימנים מיוחדים";
    //    return "ok";




    //}
    //public static string check_phone(string id)
    //{
    //    if (id.Length == 0) return "שדה חובה";
    //    if (id.Length != 10) return "מספר טלפון צריך להיות 10 מספרים";
    //    int n;
    //    if (!int.TryParse(id, out n))
    //        return "מספר טלפון כולל רק מספרות";
    //    return "ok";

    //}
    //public static string check_Birth(string year)
    //{
    //    if (year.Length == 0) return "שדה חובה";
    //    int n;
    //    if (int.TryParse(year, out n))
    //    {
    //        int mana = DateTime.Now.Year - n;

    //        if (mana < 13 || mana > 120)
    //            return "ההרשמה מגיל 13 עד 120 בלבד";
    //    }
    //    else return "שנת לידה כוללת ספרות בלבד";
    //    return "ok";
    //}
    //public static string check_ID(string id)
    //{
    //    if (id.Length == 0) return "שדה חובה";
    //    if (id.Length != 9) return "תעודת זהות צריכה להיות תשעה מספרים";
    //    int n;
    //    if (!int.TryParse(id, out n))
    //        return "תעודת זהות כלולה רק מספרות";
    //    return "ok";

    //}
    //public static string checkPassword(string pass)
    //{




    //    if (pass.Length == 0)
    //        return "שדה חובה";




    //    Regex hasNumber = new Regex(@"[0-9]+");
    //    Regex hasUpperChar = new Regex(@"[A-Z]+");
    //    Regex hasMiniMaxChars = new Regex(@".{8,15}");
    //    Regex hasLowerChar = new Regex(@"[a-z]+");


    //    if (!hasLowerChar.IsMatch(pass))
    //    {
    //        return "אות קטנה אחת לפחות";

    //    }
    //    else if (!hasUpperChar.IsMatch(pass))
    //    {
    //        return "אות גדולה אחת לפחות";

    //    }
    //    else if (!hasMiniMaxChars.IsMatch(pass))
    //    {
    //        return "הסיסמא חייבת לכלול 8 עד 15 אותיות";

    //    }
    //    else if (!hasNumber.IsMatch(pass))
    //    {
    //        return "סיסמא חייבת לכלול מספר אחד לפחות";

    //    }



    //    return "ok";



    //}
    //public static string checkAddress(string address)
    //{

    //    if (address.Length == 0)
    //        return "שדה חובה";
    //    string charsExepted = "אבגדהוזחטיכלמנסעפצקרשת-, '1234567890";

    //    foreach (char c in address)
    //        if (charsExepted.IndexOf(c) == -1) return "כתובת אינה מתאימה";

    //    return "ok";




    //}




    

    public static void buildClient(Client c)
    {
        string sql = "INSERT INTO clients(phoneNum,address_,clientID,email_,lastName,birthh,firstName,password_) VALUES(" + c.GetPhoneNumber() + ",'" + c.GetAddress() + "'," + c.idNum + ",'" + c.email + "','" + c.lName + "'," + c.birthYear + ",'" + c.fName + "','" + c.pass + "')";
        MyAdoHelper.DoQuery(fileName2, sql);
    }

    public static List<string> GetClientsUser_NameList()
    {
        List<string> lst = new List<string>();
        DataTable dt = new DataTable();
        dt = MyAdoHelper.ExecuteDataTable("flowers.accdb", "SELECT firstName from clients");

        foreach (DataRow dataRow in dt.Rows)
            foreach (var item in dataRow.ItemArray)
                lst.Add(item.ToString());
        return lst;
    }
    
    public static Client GetClientByID(int id)
    {

        DataTable dt;

        string sql = "SELECT * FROM clients WHERE clientID=" + id + ";";

        dt = MyAdoHelper.ExecuteDataTable("masadPjct.accdb", sql);

        DataRow r = dt.Rows[0];

        Client c = new Client(r.ItemArray[6].ToString(), int.Parse(r.ItemArray[0].ToString()), int.Parse(r.ItemArray[3].ToString()), r.ItemArray[4].ToString(), r.ItemArray[1].ToString(), r.ItemArray[2].ToString(), int.Parse(r.ItemArray[7].ToString()), r.ItemArray[5].ToString(), (bool.Parse(r.ItemArray[8].ToString())));

        return c;






    }

    public static bool ifTz(string tz)
    {

        DataTable dt = MyAdoHelper.ExecuteDataTable(fileName2, "SELECT clientID FROM clients;");

        foreach (DataRow r in dt.Rows)
            if (tz == r.ItemArray[0].ToString())
                return false;

        return true;




    }
    public static bool ifEmail(string email)
    {
        DataTable dt = MyAdoHelper.ExecuteDataTable(fileName2, "SELECT email_ FROM clients;");
        foreach (DataRow r in dt.Rows)
            if (email == r.ItemArray[0].ToString())
                return false;
        return true;

    }



    public static void deleteByID2(int id)
    {
        string sqls = "DELETE FROM clients WHERE clientID=" + id + ";";
        MyAdoHelper.DoQuery(fileName2, sqls);
    }

    public static void deleteClientByID(int id)
    {
        ratesHelper.deleteByID(id);
        DataTable dogs = dogHelper.GetDogByOwnerID(id);
        foreach (DataRow r in dogs.Rows)
            LoveBreedHelper.deleteByID(int.Parse(r.ItemArray[0].ToString()));
        dogHelper.deleteDogsByID(id);
        deleteByID2(id);
    }


    public static void sendEmail(string contnet, string dogSendName, string dogReciveName, string sender, string sendTO)
    {
        MailMessage mail = new MailMessage("shon.net2018@gmail.com", sendTO);
        mail.IsBodyHtml = true;
        mail.Subject = "SHON.NET יש לך הודעה מהאתר";
        string start = "שלום רב <br />";
        string end = "<br />";
        end += "המייל שלי הוא-  " + sender + "  צור קשר אם רלוונטי.<br />";
        start += "<br /> שם הכלב שלי הוא-" + dogSendName;
        start += "<br />";
        start += " מעוניין לשחק עם הכלב שלך: " + dogReciveName;
        start += "<br />";
        mail.Body = start + contnet + end;
        SmtpClient smtpC = new SmtpClient("smtp.gmail.com", 587);
        smtpC.Credentials = new System.Net.NetworkCredential()
        {
            UserName = "shon.net2018@gmail.com"
            ,
            Password = "Shon2474"
        };
        smtpC.EnableSsl = true;
        smtpC.Send(mail);
    }
}