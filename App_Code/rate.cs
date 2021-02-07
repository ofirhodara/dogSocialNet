using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for rate
/// </summary>
public class rate
{
    private int parkid, clientid;
    private string date_;
    private string content;

    public rate(int parkid,int clientid,string content,string date_)
    {
        this.clientid = clientid;
        this.content = content;
        this.date_ = date_;
        //this.rateid = rateid;
        this.parkid = parkid;
    }

    public string Get_Date() { return date_; }  
    public string GetContent() { return content; }
    public int GetParkID() { return parkid; }
    //public int GetRateID() { return rateid; }
    public int GetClientID() { return clientid; }
}