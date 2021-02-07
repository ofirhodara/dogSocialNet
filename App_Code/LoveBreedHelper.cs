using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for LoveBreed
/// </summary>
public static class LoveBreedHelper
{
    static string fileName = "masadPjct.accdb";
    public static void AddLoveBreed(int breedID, int dogID)
    {
        string sql = "INSERT INTO loveBreed(breedID,dogID) VALUES(" + breedID + "," + dogID + ")";
        MyAdoHelper.DoQuery(fileName, sql);
    }
    public static void deleteByID(int id)
    {
        string sqls = "DELETE * FROM loveBreed WHERE dogID=" + id + ";";
        MyAdoHelper.DoQuery(fileName,sqls);       
    }


}