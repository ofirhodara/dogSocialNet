using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Client
/// </summary>
public class Client
{
    public int idNum { get; set; }
    public int birthYear { get; set; }
    public int phoneNum { get; set; }
    public string fName { get; set; }
    public string email { get; set; }
    public string pass { get; set; }
    public string address { get; set; }
    public string lName { get; set; }
    private bool isAdminn { get; set; }

    public Client(string address,int id,int phone,string email,string firstName,string Lastname ,int birthYear,string pass,bool isAdmin)
    {
        this.address = address;
        this.birthYear = birthYear;
        this.pass = pass;
        fName = firstName;
        lName = Lastname;
        this.email = email;
        idNum = id;
        phoneNum = phone;
        isAdminn = isAdmin;
    }
    public string GetFname()
    {
        return fName;
    }
    public string GetEmail()
    {

        return email;

    }
    public bool GetisAdmin()
    {
        return isAdminn;
    }
    public string GetLname()
    {

        return lName;

    }
    public int GetidNum()
    {

        return idNum;

    }
    public string GetAddress()
    {

        return address;

    }
    public int GetPhoneNumber() { return phoneNum; }
    public int Get_birthYear() { return birthYear; }






}