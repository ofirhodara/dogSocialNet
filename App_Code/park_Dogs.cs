using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for parkDogs
/// </summary>
public class park_Dogs
{

    private int idpark;
    private string address;
    private string openT;
    private string seatble;
    private string toys;
    private string ifShadow;
    private string parkName;
    private string closeT;
    private string ifWater;


    public park_Dogs(string ifWater, string toys, string seat, string openT,string closeT,int idpark,string address, string ifShadow, string parkName)
    {
        this.ifWater = ifWater;
        seatble = seat;
        this.toys = toys;
        this.openT = openT;
        this.closeT = closeT;
        this.parkName = parkName;
        this.ifShadow = ifShadow;
        this.idpark = idpark;     
        this.address = address;

    }
    public int GetparkID()
    { return idpark; }
    public string GetparkName()
    { return parkName; }
    public string GetparkAddress()
    { return address; }
    public string GetifShadow()
    { return ifShadow; }
    public string GetifToys()
    { return toys; }
    public string GetifSeatble()
    { return seatble; }
    public string GetOpenTime() { return openT; }
    public string GetCloseTime() { return closeT; }
    public string GeTIfWater() { return ifWater; }
   


}