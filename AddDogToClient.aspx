<%@ Page Title="" Language="C#" MasterPageFile="~/MasterShon.master" AutoEventWireup="true" CodeFile="AddDogToClient.aspx.cs" Inherits="AddDogToClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.8/css/all.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br /><br /><br />
    <div class="container">


        
        <br /><br /><br /><br /><br />

        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <header class="card-header">
                        <center><h4 class="card-title mt-2">פרטי הכלב</h4></center>
                    </header>
                    <article class="card-body">




                        <br />
                        <center><div class="form-group">
                            <label class="form-check form-check-inline">
                                <input class="form-check-input" type="radio" name="genderDog" checked="checked" value="F">
                                <span class="form-check-label">זכר</span>
                            </label>
                            <label class="form-check form-check-inline">
                                <input class="form-check-input" type="radio" name="genderDog" value="M">
                                <span class="form-check-label">נקבה</span>
                            </label>
                        </div></center>

                        <div class="form-row">
                            <div class="col form-group">
                                <label><b>שם הכלב/ה</b></label>
                                <asp:TextBox ID="dogName" class="form-control" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="checkName" runat="server"
                                    ControlToValidate="dogName" ErrorMessage="אותיות בעברית בלבד אורך (2-15)"
                                    ForeColor="red" ValidationExpression="[א-ת, ]{2,15}"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ForeColor="red" runat="server" ID="RequiredFieldValidator23232" ControlToValidate="dogName" ErrorMessage="שדה חובה" />

                            </div>
                            <div class="col form-group">
                                <label><b>שנת לידה</b></label>
                                <asp:DropDownList ID="DropDownListDOGyear" class="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>



                        <div class="form-row">
                            <div class="col form-group">
                                <label><b>צבע</b></label>
                                <asp:TextBox ID="color4" class="form-control" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                    ControlToValidate="color4" ErrorMessage="אותיות בעברית בלבד אורך (2-15)"
                                    ForeColor="red" ValidationExpression="[א-ת, ]{2,15}"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ForeColor="red" runat="server" ID="RequiredFieldValidat43or1" ControlToValidate="color4" ErrorMessage="שדה חובה" />
                            </div>

                            <div class="form-group col-md-6">
                                <label><b>מין מועדף למשחק</b></label>
                                <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">
                                    <asp:ListItem Selected="True" Value="M">זכר</asp:ListItem>
                                    <asp:ListItem Value="F">נקבה</asp:ListItem>
                                    <asp:ListItem Value="none">אין לי העדפה</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label><b>גיל מועדף למשחק</b></label>
                                <asp:DropDownList ID="DropDownList3" class="form-control" runat="server">
                                    <asp:ListItem Selected="True" Value="1">0-4</asp:ListItem>
                                    <asp:ListItem Value="2">5-8</asp:ListItem>
                                    <asp:ListItem Value="3">8 ומעלה</asp:ListItem>
                                    <asp:ListItem Value="-1">אין לי העדפה</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-md-6">
                                <label><b>גודל מועדף</b></label>
                                <asp:DropDownList ID="DropDownList2" class="form-control" runat="server">
                                    <asp:ListItem Selected="True" Value="S">קטן</asp:ListItem>
                                    <asp:ListItem Value="M">בינוני</asp:ListItem>
                                    <asp:ListItem Value="L">גדול</asp:ListItem>
                                    <asp:ListItem Value="none">אין לי העדפה</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-row">

                            <div class="form-group col-md-6">
                                <label><b>גזע הכלב</b></label>
                                <asp:DropDownList ID="DropDownList4" class="form-control" runat="server">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group col-md-6">

                                <label><b>גזע חביב למשחק 1</b></label>
                                <asp:DropDownList ID="DropDownList5" class="form-control" runat="server">
                                </asp:DropDownList>
                            </div>

                        </div>

                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label><b>גזע חביב למשחק 2</b></label>
                                <asp:DropDownList ID="DropDownList6" class="form-control" runat="server">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group col-md-6">
                                <label><b>גזע חביב למשחק 3</b></label>
                                <asp:DropDownList ID="DropDownList7" class="form-control" runat="server">
                                </asp:DropDownList>

                            </div>
                        </div>


                        <asp:Label ID="checkBreedsLove" runat="server" ForeColor="Red"></asp:Label>




                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label><b>גודל הכלב</b></label>
                                <asp:DropDownList ID="DropDownList8" class="form-control" runat="server">
                                    <asp:ListItem Selected="True" Value="S">קטן</asp:ListItem>
                                    <asp:ListItem Value="M">בינוני</asp:ListItem>
                                    <asp:ListItem Value="L">גדול</asp:ListItem>

                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-md-6">


                                <label><b>הוסף תמונה פרופיל של הכלב</b></label>

                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="FileUpload1" ForeColor="red" ErrorMessage="File Required!">
                                </asp:RequiredFieldValidator>

                                <asp:Label ID="checkPhoto" runat="server" Text="" Font-Bold="true"></asp:Label>



                            </div>
                        </div>












                        <br />

                        <div class="form-group" >
                            <asp:Button ID="Button1" class="btn btn-primary btn-block" runat="server" Text="הוסף" OnClick="Button1_Click" />
                        </div>
                        <br />
                        <asp:Label ID="erorLabel" runat="server" ForeColor="red" Text=""></asp:Label>

                    </article>

                </div>

            </div>


        </div>

        <br />

    </div>


</asp:Content>

