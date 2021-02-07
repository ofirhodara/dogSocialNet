<%@ Page Title="" Language="C#" MasterPageFile="~/MasterShon.master" AutoEventWireup="true" CodeFile="Profile_Dog.aspx.cs" Inherits="Profile_Dog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Inconsolata">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto'>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        body, html {
            height: 30%;
            font-family: "Inconsolata", sans-serif;
        }

        h1, h2, h3, h4, h5, h6 {
            font-family: "Inconsolata", sans-serif;
        }

        .mybtnstyle {
            border: 1px solid Red;
            background-color: Red;
            border-style: groove;
            border-top: 5px;
            outline-style: dotted;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <br />
    <br />
    <br />
    <br />
    <br />


    <div class="w3-content w3-margin-top" style="max-width: 1400px;">
        <br />
    <br />
    <br />
        <!-- The Grid -->
        <div class="w3-row-padding">

            <!-- Left Column -->
            <div class="w3-third">

                <div class="w3-white w3-text-grey w3-card-4">
                    <div class="w3-display-container">
                        <asp:Image ID="Image1" runat="server" Style="width: 100%" alt="Avatar" />

                        <div class="w3-display-bottomleft w3-container w3-text-black">
                            <h2><%=dogi.GetName() %></h2>
                        </div>
                    </div>
                    <div class="w3-container">
                        <h3>שם בעל הכלב <%=clientDog.GetFname()+" "+clientDog.GetLname()  %> </h3>
                        <p><i class="fa fa-home fa-fw w3-margin-right w3-large w3-text-teal"></i><%=clientDog.GetAddress() %></p>
                        <p><i class="fa fa-envelope fa-fw w3-margin-right w3-large w3-text-teal"></i><%=clientDog.GetEmail() %></p>
                        <p><i class="fa fa-phone fa-fw w3-margin-right w3-large w3-text-teal"></i><%=clientDog.GetPhoneNumber() %></p>


                        <hr>
                    </div>

                </div>
                <!-- End Left Column -->
            </div>

            <!-- Right Column -->
            <div class="w3-twothird">

                <div class="w3-container w3-card w3-white w3-margin-bottom">

                    <h2 class="w3-text-grey w3-padding-16">פרטי הכלב        
                    </h2>

                    <div class="w3-container">
                        <h5 class="w3-opacity"><b>הצבע שלי</b></h5>
                        <div class="w3-light-grey w3-round-xlarge w3-small">
                            <h5><%=dogi.GetColor().ToString() %></h5>
                        </div>
                    </div>

                    <div class="w3-container">
                        <h5 class="w3-opacity"><b>הגודל שלי:</b></h5>
                        <div class="w3-light-grey w3-round-xlarge w3-small">
                            <h5><%=dogi.GetSize().ToString() %></h5>
                        </div>
                    </div>
                     <div class="w3-container">
                        <h5 class="w3-opacity"><b>גזע</b></h5>
                        <div class="w3-light-grey w3-round-xlarge w3-small">
                            <h5><%=breedHelper.GetNameBreedByID(dogi.GetDog_breedID()) %></h5>
                        </div>
                    </div>

                    <div class="w3-container">
                        <h5 class="w3-opacity"><b>מין:</b></h5>
                        <div class="w3-light-grey w3-round-xlarge w3-small">
                            <h5><%=dogi.GetGender().ToString() %></h5>
                        </div>
                    </div>

                    <div class="w3-container">
                        <h5 class="w3-opacity"><b>מין מועדף למשחק:</b></h5>
                        <div class="w3-light-grey w3-round-xlarge w3-small">
                            <h5><%=prferSex %></h5>
                        </div>
                    </div>


                    <div class="w3-container">
                        <h5 class="w3-opacity"><b>גיל מועדף למשחק:</b></h5>
                        <div class="w3-light-grey w3-round-xlarge w3-small">
                            <h5><%=preferAge%></h5>
                        </div>
                    </div>

                    <div class="w3-container">
                        <h5 class="w3-opacity"><b>גודל מועדף למשחק:</b></h5>
                        <div class="w3-light-grey w3-round-xlarge w3-small">
                            <h5><%=preferSize%></h5>
                        </div>
                    </div>
                </div>

                <%if (mine == false)
                    { %>
                <center><div class="w3-container w3-card w3-white">
                    <h2 class="w3-text-grey w3-padding-16"></i>שלח לי מייל</h2>          
                    <asp:TextBox ID="TextBox1" runat="server" Width="680px" Height="133px"></asp:TextBox>
                    <br /><br />
                    <asp:Button ID="Button1" runat="server" Text="שלח" class="mybtn" Width="339px" OnClick="Button1_Click" />
                    <asp:RequiredFieldValidator ForeColor="red" runat="server" ID="RequiredFieldValidator23232" ControlToValidate="TextBox1" ErrorMessage="שדה חובה" />
                </div></center>
                <%} %>
                <br /><br /><br />

                <!-- End Right Column -->
            </div>

            <!-- End Grid -->
        </div>

        <!-- End Page Container -->
    </div>
</asp:Content>

