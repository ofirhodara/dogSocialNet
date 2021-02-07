<%@ Page Title="" Language="C#" MasterPageFile="~/MasterShon.master" AutoEventWireup="true" CodeFile="chooseDog.aspx.cs" Inherits="chooseDog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .img {
            border-radius: 100%;
            display: flex;
            flex: 0 0 150px;
            height: 300px;
            justify-content: center;
            overflow: hidden;
            position: relative;
            width: 300px;
        }

            .img img {
                height: 100%;
            }
             input[type=button] {
            background-color: #4CAF50;
            border: none;
            color: white;
            padding: 16px 32px;
            text-decoration: none;
            margin: 4px 2px;
            cursor: pointer;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br /><br /><br /><br /><br /><br /><br /><br /><br />
    <center><h1>לחץ על מנת לעבור לחשבון כלבך</h1></center>
    <br />
    <br />
    
    <center><asp:GridView ID="GridView1" runat="server" AllowPaging="true" GridLines="None" PagerSettings-Visible="false" AutoGenerateColumns="False" Width="501px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>       
            <asp:TemplateField>
                <ItemTemplate>
                    <center><asp:Image ID="Image1" class="img" runat="server" ImageUrl='<%#"~/imagesDogs/"+Eval("pictureDog") %>' />
                    <br /><br />
                    <h3><%#Eval("DogName") %></h3></center>
                    <br />
                </ItemTemplate>
            </asp:TemplateField>
          <asp:ButtonField ButtonType="Button" CommandName="Select" Text="לחץ לעבור לחשבון הכלב" />
             <asp:TemplateField>
                <ItemTemplate >           
    <asp:Label ID="Label2" runat="server" style="display:none" Text='<%#Eval("DogID") %>'></asp:Label>
             </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        <br /><br />
    </center>
    <center><asp:Label ID="Label1" runat="server"  style="color:blue;border-bottom:double;border-bottom-color:black;font-family:Aharoni;font-size:xx-large" Text=""></asp:Label>
</center>
    <br /><br />
     <center>
         <a href="AddDogToClient.aspx"><input type='button' value=" הוסף כלב לחשבונך - עבור לכאן" /></a>
     </center>

</asp:Content>


