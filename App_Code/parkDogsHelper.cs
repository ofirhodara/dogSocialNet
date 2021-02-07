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


public static class parkDogsHelper
{

    static string   fileName = "masadPjct.accdb";


    public static string GetAddByID(int id)
    {      
        string sql = "SELECT parkAddress From parks WHERE parkID="+id+";";
        DataTable dt = MyAdoHelper.ExecuteDataTable(fileName, sql);
        return dt.Rows[0].ItemArray[0].ToString();
    }

    public static DataTable GetParksNames()
    {
        string sql = "SELECT name_ FROM parks";
        return MyAdoHelper.ExecuteDataTable(fileName,sql);
    }
    public static DataTable GetNameParksAndAddress()
    {
        string sql = "SELECT name_,parkAddress From parks;";
        DataTable dt=MyAdoHelper.ExecuteDataTable(fileName, sql);
        return dt;
    }
    public static DataTable GetCommentsToParkByID(int id)
    {

        string sql = "SELECT clients.firstName,clients.lastName,rates.content,rates.date_ ";
        sql += "FROM rates INNER JOIN clients ON rates.clientID=clients.clientID ";
        sql+= "WHERE rates.parkID ="+id;
        return MyAdoHelper.ExecuteDataTable(fileName, sql);
       




    }
    public static DataTable GetNameParksAndID()
    {
        string sql = "SELECT name_,parkID From parks;";
        DataTable dt = MyAdoHelper.ExecuteDataTable(fileName, sql);
        return dt;
    }
    public static string GetAddressByName(string name)
    {

        string sql = "SELECT parkAddress FROM parks WHERE name_='"+name+"';";
        return MyAdoHelper.ExecuteDataTable(fileName, sql).Rows[0].ItemArray[0].ToString();
    }

    public static park_Dogs GetParkByID(int id_Park)
    {        
        DataTable dt = MyAdoHelper.ExecuteDataTable(fileName, "SELECT * from parks WHERE parkID="+id_Park+";");
        return new park_Dogs(dt.Rows[0].ItemArray[6].ToString(), dt.Rows[0].ItemArray[8].ToString(), dt.Rows[0].ItemArray[7].ToString(), dt.Rows[0].ItemArray[2].ToString(), dt.Rows[0].ItemArray[3].ToString(),int.Parse(dt.Rows[0].ItemArray[0].ToString()), dt.Rows[0].ItemArray[1].ToString(), dt.Rows[0].ItemArray[4].ToString(), dt.Rows[0].ItemArray[5].ToString());
    }

    

    public static int GetParkIDbyName(string name)
    {

        string sql = "SELECT parkID FROM parks WHERE name_='" + name + "';";
        DataTable dt = MyAdoHelper.ExecuteDataTable(fileName, sql);
        if(dt.Rows.Count!=0)        
            return int.Parse(dt.Rows[0].ItemArray[0].ToString());
        return -1;
            
        



    }


  


}