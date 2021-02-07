<%@ Page Title="" Language="C#" MasterPageFile="~/MasterShon.master" AutoEventWireup="true" CodeFile="Park_View.aspx.cs" Inherits="Park_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <style>
        body {
            font-family: "Times New Roman", Georgia, Serif;
        }

        h1, h2, h3, h4, h6 {
            font-family: "Playfair Display";
            letter-spacing: 5px;
        }

        h5 {
            font-family: Aharoni;
            letter-spacing: 3px;
        }


        .auto-style1 {
            max-width: 100%;
            height: 331px;
        }

        .centerBikoret {
            margin: auto;
            width: 50%;
            border: 3px solid green;
            padding: 10px;
            background-color: gainsboro;
        }

        .auto-style2 {
            height: 463px;
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




    <header class="w3-display-container w3-content w3-wide" style="max-width: 1600px; min-width: 500px" id="home">
        <img runat="server" id="mainImg" class="auto-style1" width="1600" />

        <div class="w3-display-bottomleft w3-padding-large w3-opacity">
            <h1 class="w3-xxlarge"><%=park.GetparkName().ToString() %></h1>
        </div>
    </header>
    <asp:Table runat="server" ID="tableImages" CellPadding="10"
        GridLines="Both"
        HorizontalAlign="Center" align="center">
        <asp:TableRow>

            <asp:TableCell>
             <img src="img_parks/mitkanIluf.jpg" style="height:120px;width:150px" />
            </asp:TableCell>

            <asp:TableCell>
               <img  src="" runat="server" id="ilufImg" style="height:120px;width:150px"/>
            </asp:TableCell>

            <asp:TableCell>
             <img src="img_parks/safsal.jpg" style="height:120px;width:150px" />
            </asp:TableCell>

            <asp:TableCell>
             <img src="" runat="server" id="SEATImg" style="height:120px;width:150px" />
            </asp:TableCell>

            <asp:TableCell>
             <img src="img_parks/waterDog.jpg" style="height:120px;width:150px" />
            </asp:TableCell>

            <asp:TableCell>
             <img src="" runat="server" id="WaterImg" style="height:120px;width:150px" />
            </asp:TableCell>
             <asp:TableCell>
             <img src="img_parks/zel.jpg" style="height:120px;width:150px" />
            </asp:TableCell>
              <asp:TableCell>
             <img src="" runat="server" id="ShadowImg" style="height:120px;width:150px" />
            </asp:TableCell>

        </asp:TableRow>

    </asp:Table>
    <%--חלק עליון של תמונה--%>
    <!-- Page content -->
    <div class="w3-content" style="max-width: 1100px">
        <!-- About Section -->
        <div class="w3-row w3-padding-64" id="detailsPark">
            <div class="w3-col m6 w3-padding-large w3-hide-small">
                <img src="" runat="server" id="SmallImg" class="auto-style2" width="650" />
            </div>

            <div class="w3-col m6 w3-padding-large">
                <h1 class="w3-center">פרטים על הגינה</h1>
                <br>
                <h5 class="w3-center">כתובת</h5>
                <br>
                <h5 class="w3-center"><%=park.GetparkAddress().ToString() %></h5>
                <br>
                <h5 class="w3-center">שעות פעילות:</h5>
                <br>
                <h5 class="w3-center">שעות פתיחה <%=park.GetOpenTime().ToString() %></h5>
                <h5 class="w3-center">שעות פתיחה <%=park.GetCloseTime().ToString() %></h5>
            </div>
        </div>
    </div>
    <br />
    <center><%=toNavigate %></center>
    <br />
    <div class="centerBikoret" id="menu">
        <h1 class="w3-center">ביקורת הלקוחות שלנו על פארק זה</h1>
        <br>
        <%=comments %>
        <%--<h4>ביקורת 1</h4>
            <p class="w3-text-grey">היה מעולה, ממליץ לכולם</p>
            <br>
            <h4>ביקורת 2</h4>
            <p class="w3-text-grey">לא אהבתי את הפארק</p>
            <br>

            <h4>ביקורת 3</h4>
            <p class="w3-text-grey">הייתי שם עם הכלב שלי שון. הוא נהנה ורצה לחזור כמובן.</p>
            <p class="w3-text-grey">&nbsp;</p>--%>
    </div>
    <center><asp:TextBox ID="TextBox1" runat="server" Height="60px" Width="797px"></asp:TextBox> <asp:Button ID="Button1" runat="server" Text="הוסף ביקורת" Height="63px" OnClick="Button1_Click" /></center>
   <br /><br /><br />

</asp:Content>

