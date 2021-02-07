using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data.OleDb;


/// <summary>
/// Summary description for breedHelper
/// </summary>
public static class breedHelper
{
    static string fileName = "masadPjct.accdb";

    static OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\\Users\\User\\Desktop\\פרחים\\App_Data\\flowers.accdb;Persist Security Info=True");
    public static OleDbConnection myco = MyAdoHelper.ConnectToDb("flowers.accdb");
    static OleDbCommand myCommand = new OleDbCommand();

    public static string  GetNameBreedByID(int id)
    {
        string sql= "SELECT b_name from breeds where breedID="+id+";";
        DataTable dt = MyAdoHelper.ExecuteDataTable(fileName,sql);
        if (dt == null) return "";
        return dt.Rows[0].ItemArray[0].ToString();
    }
    public static DataTable GetDataBreeds()
    {

        string sql = "SELECT * FROM breeds;";
        return MyAdoHelper.ExecuteDataTable(fileName, sql); 



    }
}