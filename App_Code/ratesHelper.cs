using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for ratesHelper
/// </summary>
public static class ratesHelper
{
    static string fileName = "masadPjct.accdb";
    public static void AddRate(rate r)
    {
       
        string sql = "INSERT INTO rates ( content, clientID, parkID, date_ ) VALUES('" + r.GetContent() + "'," + r.GetClientID() + "," + r.GetParkID() + ", '" + r.Get_Date() + "');";     
        MyAdoHelper.DoQuery(fileName, sql);

    }

    public static void deleteByID(int id)
    {
        string sqls = "DELETE * FROM rates WHERE clientID=" + id + ";";
        MyAdoHelper.DoQuery(fileName, sqls);
    }



}