using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class AddDogToClient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)       
            handleBreedDropboxes();


        
    }

    public void handleBreedDropboxes()
    {

        DataTable dt = breedHelper.GetDataBreeds();
        foreach (DataRow r in dt.Rows)
        {
            ListItem breed = new ListItem(r.ItemArray[1].ToString(), r.ItemArray[0].ToString(), true);//TEXT,VALUE
            DropDownList4.Items.Add(breed);
            DropDownList5.Items.Add(breed);
            DropDownList6.Items.Add(breed);
            DropDownList7.Items.Add(breed);
        }



        for (int i = 2000; i < 2020; i++)
        {
            ListItem year = new ListItem(i.ToString(), i.ToString(), true);//TEXT,VALUE
            DropDownListDOGyear.Items.Add(year);
        }

    }

    public bool checkbreedsLove()
    {
        string breed1 = DropDownList5.Text;
        string breed2 = DropDownList6.Text;
        string breed3 = DropDownList7.Text;

        if (breed1 == breed2 || breed1 == breed3 || breed3 == breed2)


            return false;



        return true;

    }

    public bool checkphoto()
    {


        string[] extensions = { ".JPG", ".jpg", ".PNG", ".png" };
        foreach (string ext in extensions)
            if (FileUpload1.FileName.EndsWith(ext))
                return true;
        return false;


    }





    protected void Button1_Click(object sender, EventArgs e)
    {

        if (checkphoto() && checkbreedsLove())
        {
            string size = DropDownList8.Text;
            string preferSize = DropDownList2.SelectedValue;

            int preferAGE = int.Parse(DropDownList3.SelectedValue);
            int birth_year = int.Parse(DropDownListDOGyear.Text);

            string pictureDog = FileUpload1.FileName.ToLower();

            string path = @"D:\ProjectShonNET\imagesDogs\" + pictureDog;

            int adding = 1;
            while (File.Exists(path))
            {
                pictureDog = adding + pictureDog;
                path = @"D:\ProjectShonNET\imagesDesign\" + pictureDog;
                adding++;
            } 

            bool if_male = true, if_female = true;

            if (DropDownList1.Text == "זכר")
                if_female = false;
            else
            {
                if (DropDownList1.Text == "נקבה")
                    if_male = false;
            }

            string gender = Request.Form["genderDog"];

            Dog dog = new Dog(size, preferSize, preferAGE, pictureDog, if_female, if_male, dogName.Text, color4.Text, gender, int.Parse(DropDownListDOGyear.Text), ((Client)Session["client_now"]).GetidNum(), -1, int.Parse(DropDownList4.SelectedValue));

            int new_dog_id = dogHelper.buildDog(dog);

            FileUpload1.SaveAs(path);

            AddLoveBreeds(new_dog_id);

            Response.Redirect("chooseDog.aspx");
            


        }
    }

    public void AddLoveBreeds(int new_dog_id)
    {



        LoveBreedHelper.AddLoveBreed(int.Parse(DropDownList5.SelectedValue), new_dog_id);
        LoveBreedHelper.AddLoveBreed(int.Parse(DropDownList6.SelectedValue), new_dog_id);
        LoveBreedHelper.AddLoveBreed(int.Parse(DropDownList7.SelectedValue), new_dog_id);



    }
}