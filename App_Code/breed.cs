using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for breed
/// </summary>
public class breed
{
    private string nameBreed;
    private int breed_Id;
    public breed(string name,int id)
    {
        breed_Id = id;
        nameBreed = name;
    }
    public string GetNameBreed() { return nameBreed; }
    public int GetBreedID() { return breed_Id; }
}