<%@ Page Title="" Language="C#" MasterPageFile="~/MasterShon.master" AutoEventWireup="true" CodeFile="editDogg.aspx.cs" Inherits="editDogg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Inconsolata">
    <style>
        body, html {
            /*height: 30%;*/
            font-family: "Inconsolata", sans-serif;
        }
        .auto-style1 {
            margin-right: 0px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="w3-sand w3-grayscale w3-large">
        <br />
        <br />
        <br />
        <br />

        <center> <h1 class="w3-center w3-padding-64"><span class="w3-tag w3-wide">עריכת פרטי כלב</span></h1></center>

        <center> <asp:DetailsView  ID="DetailsView1"  runat="server"  Height="150px" Width="250px" Font-Bold="True" Font-Italic="True" Font-Size="XX-Large" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
        OnModeChanging="DetailsView1_Edit" OnItemUpdating="DetailsView1_Update" OnItemDeleting="deleteItem1" AutoGenerateRows="False" BackColor="#DEBA84" CellPadding="3" CellSpacing="2">
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

            <asp:TemplateField HeaderText="שם הכלב">
                <ItemTemplate>
                    <asp:Label ID="lbl_dogName" runat="server" Text='<%#Eval("DogName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="גודל הכלב">
                <ItemTemplate>
                    <asp:Label ID="lbl_size" runat="server"  Text='<%#Eval("dogsize") %>' ></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="S">קטן</asp:ListItem>
                        <asp:ListItem Value="M">בינוני</asp:ListItem>
                        <asp:ListItem Value="L">גדול</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>


             <asp:TemplateField HeaderText="משחק עם זכרים">
                <ItemTemplate>
                    <asp:Label ID="lbl_male" runat="server"  Text='<%#Eval("playWithMales") %>' ></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList4" runat="server">
                        <asp:ListItem Value="yess">כן</asp:ListItem>
                        <asp:ListItem Value="noo">לא</asp:ListItem>                    
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            
             <asp:TemplateField HeaderText="משחק עם נקבות">
                <ItemTemplate>
                    <asp:Label ID="lbl_Fmale" runat="server"  Text='<%#Eval("playWithFemale") %>' ></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList5" runat="server">
                        <asp:ListItem Value="yess">כן</asp:ListItem>
                        <asp:ListItem Value="noo">לא</asp:ListItem>                    
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="גיל מועדף למשחק">
                <ItemTemplate>
                    <asp:Label ID="lbl_ageP" runat="server"  Text='<%#Eval("preferAge") %>' ></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:DropDownList ID="DropDownList3" class="form-control" runat="server">
                                    <asp:ListItem Value="1">0-4</asp:ListItem>
                                    <asp:ListItem Value="2">5-8</asp:ListItem>
                                    <asp:ListItem Value="3">8 ומעלה</asp:ListItem>
                                    <asp:ListItem Value="-1">אין לי העדפה</asp:ListItem>
                                </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="גודל מועדף למשחק">
                <ItemTemplate>
                    <asp:Label ID="lbl_prederSize" runat="server"  Text='<%#Eval("preferSize") %>' ></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                  <asp:DropDownList ID="DropDownList2" class="form-control" runat="server">
                                    <asp:ListItem  Value="S">קטן</asp:ListItem>
                                    <asp:ListItem Value="M">בינוני</asp:ListItem>
                                    <asp:ListItem Value="L">גדול</asp:ListItem>
                                    <asp:ListItem Value="none">אין לי העדפה</asp:ListItem>
                                </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>



          



           

           
            
        </Fields>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
    </asp:DetailsView>

        </center>
        <br />
        <br />
      
        <center> <h2 class="w3-center w3-padding-64"><span class="w3-tag w3-wide">עריכת גזעים אהובים</span></h2></center>
       
        <br />
        <center><asp:GridView ID="GridView1" runat="server"  OnRowDataBound="GridView1_RowDataBound" OnRowUpdating="GridView1_Update" OnRowEditing="GridView1_Editing" OnRowCancelingEdit="GridView1_Cancel"
           ShowFooter="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" CssClass="auto-style1" Height="216px" Width="368px">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Edit" runat="server" Text="Edit" CommandName="Edit" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="btn_Update" runat="server" Text="Update" CommandName="Update" />
                        <asp:LinkButton ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="גזע אוהב">
                    <ItemTemplate>
                        <asp:Label ID="lbl_geza1" runat="server" Text='<%#Eval("b_name") %>' ></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>                    
                                <asp:DropDownList ID="DropDownList2"   class="form-control"  runat="server"> 
                                  
                                </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                
            </Columns>
             <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
             <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
             <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#F7F7F7" />
             <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
             <SortedDescendingCellStyle BackColor="#E5E5E5" />
             <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView></center>
        <br /><br /><br />


    </div>
   
</asp:Content>


