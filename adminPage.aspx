<%@ Page Title="" Language="C#" MasterPageFile="~/MasterShon.master" AutoEventWireup="true" CodeFile="adminPage.aspx.cs" Inherits="adminPage" %>

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
        <br /><br />
        <br /><br /><br />
        <center><h1 class="w3-center w3-padding-64"><span class="w3-tag w3-wide">דף המנהל</span></h1></center>
        <center><asp:DropDownList ID="DropDownList1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" runat="server">
        </asp:DropDownList></center>

        <br />
        <center>
       <asp:DetailsView  ID="DetailsView1"  runat="server"  Height="150px" Width="250px" Font-Bold="True" Font-Italic="True" Font-Size="XX-Large" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
        OnModeChanging="DetailsView1_Edit" OnItemUpdating="DetailsView1_Update" OnItemDeleting="deleteItem1" AutoGenerateRows="False" BackColor="#DEBA84" CellPadding="3" CellSpacing="2" >
            <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="Edit" runat="server" Text="Edit" CommandName="Edit" />
                    <asp:LinkButton ID="Delete" runat="server" Text="Delete" CommandName="Delete" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="btn_Update" runat="server" Text="Update" CommandName="Update" />
                    <asp:LinkButton ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="תעודת זהות">
                <ItemTemplate>
                    <asp:Label ID="lbl_userId" runat="server" Text='<%#Eval("clientID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="כתובת מייל">
                <ItemTemplate>
                    <asp:Label ID="lbl_Email" runat="server" Text='<%#Eval("email_") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="tb_Email" Text='<%#Eval("email_") %>' runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="שם פרטי">
                <ItemTemplate>
                    <asp:Label ID="lbl_fName" runat="server" Text='<%#Eval("firstName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="tb_fName" Text='<%#Eval("firstName") %>' runat="server"></asp:TextBox>
                </EditItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="שם משפחה">
                <ItemTemplate>
                    <asp:Label ID="lbl_lName" runat="server" Text='<%#Eval("lastName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="tb_lName" Text='<%#Eval("lastName") %>' runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>



            <asp:TemplateField HeaderText="סיסמא">
                <ItemTemplate>
                    <asp:Label ID="lbl_pass" runat="server" Text='<%#Eval("password_") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="tb_pass" Text='<%#Eval("password_") %>' runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="מספר טלפון">
                <ItemTemplate>
                    <asp:Label ID="lbl_phoneNum" runat="server" Text='<%#Eval("phoneNum") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="tb_phoneNum" Text='<%#Eval("phoneNum") %>' runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="כתובת מגורים">
                <ItemTemplate>
                    <asp:Label ID="lbl_address_" runat="server" Text='<%#Eval("address_") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="tb_address_" Text='<%#Eval("address_") %>' runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="שנת לידה">
                <ItemTemplate>
                    <asp:Label ID="lbl_birthh" runat="server" Text='<%#Eval("birthh") %>'></asp:Label>
                </ItemTemplate>

                <EditItemTemplate>
              <asp:TextBox ID="tb_birthh" Text='<%#Eval("birthh") %>' runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
        </Fields>
    </asp:DetailsView></center>
        <br />

        <br />
        <br />

        <br />
        <br />


        <br />
        <br />

        <br />
        <br />

        <br />
    </div>
</asp:Content>
