<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register_Shon.aspx.cs" Inherits="register_Shon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.8/css/all.css">
</head>

<body style="background-image: url('imagesDesign/background.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-size: cover;">
    <form id="form1" runat="server">
        <div class="container">
            <br>
            <p class="text-center">
                צור קשר
                <br />
                מספר טלפון: 0543973871
                <br />
                ofir1682002@gmail.com :כתובת מייל
            </p>
            <hr>
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card">
                        <header class="card-header">
                            <a href="logIn.aspx" class="float-right btn btn-outline-primary mt-1">לחץ להתחברות</a>
                            <a href="HomePage.aspx" class="float-right btn btn-outline-primary mt-1">דף הראשי</a>
                            <h4 class="card-title mt-2">הרשמה לאתר</h4>
                        </header>
                        <article class="card-body">

                            <div class="form-row">
                                <div class="col form-group">
                                    <b>
                                        <asp:Label ID="pratiLabel"
                                            Text="שם פרטי"
                                            runat="server" />
                                    </b>

                                    <asp:TextBox ID="prati" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="checkName" runat="server"
                                        ControlToValidate="prati" ErrorMessage="אותיות בעברית בלבד אורך (2-10)"
                                        ForeColor="red" ValidationExpression="[א-ת, ]{2,10}"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ForeColor="red" runat="server" ID="RequiredFieldValidator23232" ControlToValidate="prati" ErrorMessage="שדה חובה" />
                                </div >
                                <div class="col form-group" >
                                    <label><b>שם משפחה</b></label>
                                    <asp:TextBox ID="last_name" class="form-control" runat="server"></asp:TextBox>
                                    <asp:Label ID="checkLast" runat="server" Text="" Font-Bold="true"
                                        ForeColor="red"></asp:Label>
                                    <asp:RegularExpressionValidator ID="validateLastName" runat="server"
                                        ControlToValidate="last_name" ErrorMessage="(אותיות בעברית ומקף בארוך (2-13"
                                        ForeColor="red" ValidationExpression="[א-ת, ,-]{2,13}"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ForeColor="red" runat="server" ID="RequiredFieldValidator2" ControlToValidate="last_name" ErrorMessage="שדה חובה" />

                                </div>
                            </div>

                            <div class="form-row">
                                <div class="col form-group">
                                    <label><b>תעודת זהות</b></label>
                                    <asp:TextBox ID="tz" class="form-control" runat="server"></asp:TextBox>
                                    <asp:Label ID="check_tz" runat="server" Text="" Font-Bold="true"
                                        ForeColor="red"></asp:Label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                        ControlToValidate="tz" ErrorMessage="תעודת זהות כוללת תשה ספרות"
                                        ForeColor="red" ValidationExpression="[0-9]{9}"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ForeColor="red" runat="server" ID="RequiredFieldValidator1" ControlToValidate="tz" ErrorMessage="שדה חובה" />
                                </div>
                                <div class="col form-group">
                                    <label><b>שנת לידה</b></label>
                                    <asp:DropDownList ID="DropDownList10" class="form-control" runat="server">
                                    </asp:DropDownList>
                                    <asp:Label ID="checkyear" runat="server" Text="" Font-Bold="true"
                                        ForeColor="red"></asp:Label>
                                </div>
                            </div>


                            <div class="form-group">
                                <label><b>כתובת מייל</b></label>
                                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="email_" ErrorMessage="כתובת מייל אינה מתאימה"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="email_" class="form-control" runat="server"></asp:TextBox>
                                <small class="form-text text-muted">לא אשתף כתובת זו עם אף אחד לעולם</small>
                                <asp:Label ID="checkMail" runat="server" Text="" Font-Bold="true"
                                    ForeColor="red"></asp:Label>
                                <asp:RequiredFieldValidator ForeColor="red" runat="server" ID="RequiredFieldValidator13" ControlToValidate="email_" ErrorMessage="שדה חובה" />
                            </div>




                            <div class="form-group">
                                <label><b>כתובת מגורים</b></label>
                                <asp:TextBox ID="addresss" class="form-control" runat="server"></asp:TextBox>
                                <small class="form-text text-muted">שים לב להקליד כתובת מדויקת</small>

                                <asp:Label ID="checkAddress" runat="server" Text="" Font-Bold="true"
                                    ForeColor="red"></asp:Label>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                    ControlToValidate="addresss" ErrorMessage="(אותיות בעברית וסימנים מיוחדים בלבד באורך (2-30"
                                    ForeColor="red" ValidationExpression="[א-ת, ,.,',1-9]{2,30}"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ForeColor="red" runat="server" ID="RequiredFieldValidator12" ControlToValidate="addresss" ErrorMessage="שדה חובה" />
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label><b>סיסמא</b></label>
                                    <asp:TextBox ID="pass1" class="form-control" runat="server"></asp:TextBox>
                                    <small class="form-text text-muted">הסיסמא חייבת לכלול 8-15 תווים</small>

                                    <asp:Label ID="passcheck" Font-Bold="true"
                                        ForeColor="red" runat="server" Text=""></asp:Label>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator33" runat="server"
                                        ControlToValidate="pass1" ErrorMessage="סיסמא חייבת לכלול אות גדולה אות קטנה וסיפרה אחת לפחות."
                                        ForeColor="red" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ForeColor="red" runat="server" ID="RequiredFieldValidator232" ControlToValidate="pass1" ErrorMessage="שדה חובה" />






                                </div>

                                <div class="form-group col-md-6">
                                    <label><b>מספר טלפון</b></label>
                                    <asp:TextBox ID="tel" class="form-control" runat="server"></asp:TextBox>

                                    <asp:Label ID="checktel" runat="server" Text="" Font-Bold="true"
                                        ForeColor="red"></asp:Label>

                                    <asp:RequiredFieldValidator ForeColor="red" runat="server" ID="reqName" ControlToValidate="tel" ErrorMessage="שדה חובה" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                        ControlToValidate="tel" ErrorMessage="מספר טלפון כולל 10 ספרות"
                                        ForeColor="red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="Button1" class="btn btn-primary btn-block" runat="server" Text="הרשם" OnClick="Button1_Click" />
                    </div>
                    <asp:Label ID="erorLabel" runat="server" ForeColor="red" Text=""></asp:Label>
                    </article>              
                </div>
            </div>
        </div>
    </form>
</body>
</html>
