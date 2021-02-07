<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logIn.aspx.cs" Inherits="logIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
            background-color: #5CDB95;
        }

        * {
            box-sizing: border-box;
        }

        /* Add padding to containers */
        .container {
            padding: 6px;
            background-color: white;
        }

        /* Full-width input fields */
        input[type=text], input[type=password] {
            width: 100%;
            padding: 15px;
            margin: 5px 0 22px 0;
            display: inline-block;
            border: none;
            background: #f1f1f1;
        }

            input[type=text]:focus, input[type=password]:focus {
                background-color: #ddd;
                outline: none;
            }

        /* Overwrite default styles of hr */
        hr {
            border: 1px solid #f1f1f1;
            margin-bottom: 25px;
        }

        /* Set a style for the submit button */
        .registerbtn {
            background-color: darkgrey;
            color: white;
            padding: 16px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 100%;
            opacity: 0.9;
        }

            .registerbtn:hover {
                opacity: 1;
            }

        /* Add a blue text color to links */
        a {
            color: dodgerblue;
        }

        /* Set a grey background color and center the text of the "sign in" section */
        .signin {
            background-color: #f1f1f1;
            text-align: center;
        }

        .auto-style1 {
            height: 4px;
        }

        .auto-style2 {
            height: 343px;
        }
    </style>
</head>
<body dir="rtl">
    <form id="form1" runat="server">

        <div class="container">

            <center><h1>התחברות</h1>
            <h3>התחבר לאתר שון נט ותהנה מרשת חברתית מדהימה </h3></center>
            <center><a href="HomePage.aspx"><h1 style="font-family:serif">לחץ על מנת לעבור לדף הבית</h1></a>
            </center><hr>

            <label><b>כתובת אימייל</b></label>
            <asp:TextBox ID="email_" name="email" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ForeColor="red" runat="server" ID="RequiredFieldValidator23232" ControlToValidate="email_" ErrorMessage="שדה חובה" />
            <br />
            <br />
            <label><b>סיסמא</b></label>
            <asp:TextBox ID="pass" name="sisma" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:RequiredFieldValidator ForeColor="red" runat="server" ID="RequiredFieldValidator1" ControlToValidate="pass" ErrorMessage="שדה חובה" />
            <br />
            <br />

            <center> <asp:Label ID="ErorText" runat="server" Text=""></asp:Label></center>
            <br />
            <hr class="auto-style1">
            <img src="imagesDesign/loginIMG.jpg" width="100%" class="auto-style2" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" class="registerbtn" Text="התחבר" OnClick="Button1_Click" />
        </div>
        <div class="container signin">
            <p>צור משתמש באתר <a href="register_Shon.aspx">הרשמה</a>.</p>
        </div>
    </form>
</body>
</html>
