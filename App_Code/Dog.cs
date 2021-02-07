using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// object DOG
/// </summary>
/// 
public class Dog
{
    private string name, color, Gender, pictureDog, size, preferSize;

    private int birthYear, OwnerID, DogID, Dog_breedID, preferAge;

    private bool  playWithFemale, playWithMale;

    public Dog(string size, string preferSize, int preferAge,string pictureDog, bool playWithFemale, bool playWithMale, string name, string color, string Gender, int birthYear, int OwnerID, int DogID, int Dog_breedID)
    {
        this.name = name;     
        this.color = color;
        this.preferSize = preferSize;
        this.size = size;
        this.preferAge = preferAge;
        this.pictureDog = pictureDog;
        this.playWithFemale = playWithFemale;
        this.playWithMale = playWithMale;
        this.birthYear = birthYear;
        this.OwnerID = OwnerID;       
        this.DogID = DogID;
        this.Dog_breedID = Dog_breedID;
        this.Gender = Gender;
    }
    public string GetName()
    {
        return name;
    }
   
    public string GetColor()
    {
        return color;
    }
    public string GetPreferSize()
    {
        return preferSize;
    }
    public string GetSize()
    {
        return size;
    }
    public int GetPreferAge()
    {
        return preferAge;
    }
    public string GetPictureDog()
    {
        return pictureDog;
    }
    public bool GetplayWithFemale()
    {

        return playWithFemale;

    }
    public bool GetplayWithMale()
    {

        return playWithMale;

    }
    public int GetbirthYear()
    {
        return birthYear;
    }
    public string GetGender()
    {
        return Gender;
    }
    public int GetDogID()
    {
        return DogID;
    }
    public int GetOwnerID()
    {
        return OwnerID;
    }
    public int GetDog_breedID()
    {
        return Dog_breedID;
    }
 










}