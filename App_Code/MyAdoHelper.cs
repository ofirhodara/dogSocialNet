﻿using System;
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

/// <summary>
/// Summary description for MyAdoHelper
/// פעולות עזר לשימוש במסד נתונים מסוג אקסס
///  App_Data המסד ממוקם בתקיה 
/// </summary>

public class MyAdoHelper
{
	public MyAdoHelper()
	{
	}


    public static OleDbConnection ConnectToDb(string fileName)
    {
        //string path = HttpContext.Current.Server.MapPath("App_Data/");//מיקום מסד בפורוייקט
        //path += fileName;

        string path = HttpContext.Current.Server.MapPath("App_Data/" + fileName);//מאתר את מיקום מסד הנתונים מהשורש ועד התקייה בה ממוקם המסד


 

        //string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + path;//נתוני ההתחברות הכוללים מיקום וסוג המסד
        string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;//נתוני ההתחברות הכוללים מיקום וסוג המסד
        OleDbConnection conn = new OleDbConnection(connString);
        return conn;
    }

    public static string ConnectionString(string fileName)
    {
        string path = HttpContext.Current.Server.MapPath("App_Data/");//מיקום מסד בפורוייקט
        path += fileName;
        //string path = HttpContext.Current.Server.MapPath("App_Data/" + fileName);//מאתר את מיקום מסד הנתונים מהשורש ועד התקייה בה ממוקם המסד




        string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + path;//נתוני ההתחברות הכוללים מיקום וסוג המסד

        //string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source" + path;//נתוני ההתחברות הכוללים מיקום וסוג המסד
        return connString;
    }

    /// <summary>
    /// To Execute update / insert / delete queries
    ///  הפעולה מקבלת שם קובץ ומשפט לביצוע ומבצעת את הפעולה על המסד
    /// </summary>

    public static void  DoQuery(string fileName, string sql)//הפעולה מקבלת שם מסד נתונים ומחרוזת מחיקה/ הוספה/ עדכון
    //ומבצעת את הפקודה על המסד הפיזי
    {

        OleDbConnection conn = ConnectToDb(fileName);
        try
        {
            conn.Open();
        }
        catch (Exception)
        {
            throw new Exception("לא ניתן להתחבר למסד נתונים");
        }
        OleDbCommand com = new OleDbCommand(sql, conn);
        com.ExecuteNonQuery();
        com.Dispose();
        conn.Close();
      
    }


    /// <summary>
    /// To Execute update / insert / delete queries
    ///  הפעולה מקבלת שם קובץ ומשפט לביצוע ומחזירה את מספר השורות שהושפעו מביצוע הפעולה
    /// </summary>
    public static int RowsAffected(string fileName, string sql)//הפעולה מקבלת מסלול מסד נתונים ופקודת עדכון
    //ומבצעת את הפקודה על המסד הפיזי
    {
        OleDbConnection conn = ConnectToDb(fileName);
        try
        {
            conn.Open();
        }
        catch (Exception)
        {
            throw new Exception("לא ניתן להתחבר למסד נתונים");
        }
        OleDbCommand com = new OleDbCommand(sql, conn);
        int rowsA = com.ExecuteNonQuery();
        conn.Close();
        return rowsA;
    }

    /// <summary>
    /// הפעולה מקבלת שם קובץ ומשפט לחיפוש ערך - מחזירה אמת אם הערך נמצא ושקר אחרת
    /// </summary>
    public static bool IsExist(string fileName, string sql)//הפעולה מקבלת שם קובץ ומשפט בחירת נתון ומחזירה אמת אם הנתונים קיימים ושקר אחרת
    {

        OleDbConnection conn = ConnectToDb(fileName);
        try
        {
            conn.Open();
        }
        catch (Exception)
        {
            throw new Exception("לא ניתן להתחבר למסד נתונים");
        }
        OleDbCommand com = new OleDbCommand(sql, conn);
        OleDbDataReader data = com.ExecuteReader();
        bool found;
        found=(bool) data.Read();// אם יש נתונים לקריאה יושם אמת אחרת שקר - הערך קיים במסד הנתונים
        conn.Close();
        return found;

    }
    

    public static DataTable ExecuteDataTable(string fileName, string sql)
    {
        OleDbConnection conn = ConnectToDb(fileName);
        try
        {
            conn.Open();
        }
        catch (Exception)
        {
            throw new Exception("לא ניתן להתחבר למסד נתונים");
        }
        OleDbDataAdapter tableAdapter = new OleDbDataAdapter(sql,conn);
        DataTable dt = new DataTable();
        tableAdapter.Fill(dt);
        conn.Close();//לא בטוח צריך
        return dt;
    }


    public void ExecuteNonQuery(string fileName, string sql)
    {
        OleDbConnection conn = ConnectToDb(fileName);
        try
        {
            conn.Open();
            OleDbCommand command = new OleDbCommand(sql, conn);
            command.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw new Exception("הייתה בעיה בהכנסת הנתונים למסד!");
        }
        finally
        {
            conn.Close();
        }
        
    }

    public static string printDataTable(string fileName, string sql)//הפעולה מקבלת שם קובץ ומשפט בחירת נתון ומחזירה אמת אם הנתונים קיימים ושקר אחרת
    {
        
       
        DataTable dt = ExecuteDataTable(fileName, sql);
       
        string printStr = "<table border='1'>";
        
        foreach (DataRow row in dt.Rows)
        {
            printStr += "<tr>";
            foreach (object myItemArray in row.ItemArray)
            {

                printStr += "<td>" + myItemArray.ToString() +"</td>";
            }
            printStr += "</tr>";
        }
        printStr += "</table>";
        
        return printStr;
    }

    public static int MaximumCount(string fileName, string tableName, string keyName)
    {
        int count = 0;
        string sqlMax = "SELECT max(" + keyName + ") FROM " + tableName;
        DataTable dt = MyAdoHelper.ExecuteDataTable(fileName, sqlMax);
        count = int.Parse(dt.Rows[0][0].ToString());
        return count;
    }

}
