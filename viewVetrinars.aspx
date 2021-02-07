<%@ Page Title="" Language="C#" MasterPageFile="~/MasterShon.master" AutoEventWireup="true" CodeFile="viewVetrinars.aspx.cs" Inherits="viewVetrinars" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Inconsolata">
    <style>
        body, html {
            /*height: 30%;*/
            font-family: "Inconsolata", sans-serif;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <div class="w3-sand w3-grayscale w3-large">
    <br />
    <br /><br /><br />
        
         <br /><br />
    <br />
    <center><h1>מידע על וטרינרים ללקוחות האתר בלבד</h1>
    <br />
    <h3>חפש לפי אזור מגורים</h3>
    <br />   
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </center>
    <br />
    <br />
    <center><asp:GridView ID="GridView1" runat="server"  OnRowCreated="GridView1_RowCreated" AllowPaging="True" GridLines="None" PagerSettings-Visible="false" AutoGenerateColumns="False" Width="501px" CellPadding="4" ForeColor="#333333" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>            
            <asp:TemplateField>
                <ItemTemplate>                     
                    <h3><%#Eval("vetName") %></h3></center>
                </ItemTemplate>
            </asp:TemplateField>  
             <asp:TemplateField>
                <ItemTemplate>                     
                    <h3><%#Eval("Addresses") %></h3></center>
                </ItemTemplate>
            </asp:TemplateField>             
             <asp:TemplateField>
                <ItemTemplate >    
                     <h3><%#Eval("tel_Vet") %></h3></center>
             </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />

<PagerSettings Visible="False"></PagerSettings>
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>

        <br /><br />
    </center><br /><br /><br /><br /><br /><br /><br />
         </div>
</asp:Content>

