<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wasePark.aspx.cs" Inherits="wasePark" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        #map {
            height: 100%;
        }
        /* Optional: Makes the sample page fill the window. */
        html, body {
            height: 80%;
            margin: 0;
            padding: 0;
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
    <title></title>

</head>
<body style="background-image: url('imagesDesign/wase.jpg'); background-size: cover; background-repeat: no-repeat">

    <form id="form1" runat="server">
        <div>
            <center><input type="button" onclick="initialize('home')" value="Press to see Directions from Your Home Address!" /><br />
            <br /><br /><br /><input id="Otheradd" />
            <input type="button" style="display:none" id="err" value="זה שדה חובה" />
            </center>
            <br />                  
            <center><input type="button" value="Press to see Directions from Written Address!" onclick="initialize('newAddress')" /></center>
            <br />
            <br />
            <center><input type="button" id="distance_" style="display:none" />
            <input type="button" id="time_" style="display:none" /></center>
        </div>
    </form>

    <div id="map">
    </div>
    <script>  



        function initialize(typeRequest) {

            if (Otheradd.value == '' && typeRequest == 'newAddress') {
                err.style.display = ''; 
            }
            else {
                err.style.display = 'none';

                var directionsService = new google.maps.DirectionsService();
                var directionsRenderer = new google.maps.DirectionsRenderer();

                var map = new google.maps.Map(document.getElementById('map'), {//יצירת מפה
                    zoom: 7,
                    center: { lat: 32.306, lng: 34.908 }//מיקום התחלתי
                });

                directionsRenderer.setMap(map);
                var org = '';
                var dest = '';
                if (typeRequest == 'newAddress')//בודק האם ניווט מכתובת חדשה או מכתובת המגורים של לקוח
                { org = document.getElementById("Otheradd").value; }
                else { org = '<%=Session["userAddress"]%>'; }

            dest = '<%=Session["dest"]%>';//יעד הגעה- כתובת הגינה שמורה באובייקט סשן כאשר הדף נטען
            calculateAndDisplayRoute(directionsService, directionsRenderer, org, dest);//קריאה לפונציה חישוב והצגת דרך
            }
        }
        function calculateAndDisplayRoute(directionsService, directionsRenderer, origin, destination) {
            directionsService.route(//יצירת בקשה לשרת בפרוטוקול http
                {
                    origin: { query: String(origin) },//פרמטרים נדרשים
                    destination: { query: String(destination) },
                    travelMode: 'DRIVING'
                },
                function (response, status) {
                    if (status === 'OK') {//אם הבקשה צלחה 
                        document.getElementById('time_').value = response['routes'][0]['legs'][0]['duration']['text'];//קריאה מקובץ פורמט JSON וחיפוש אחרי מרחק וזמן שחושבו
                        document.getElementById('distance_').value = response['routes'][0]['legs'][0]['distance']['text'];
                        time_.style.display = '';
                        distance_.style.display = '';
                        directionsRenderer.setDirections(response);//הצגת נתונים על המפה

                    } else {
                        document.getElementById('time_').value = "cant find directions.";//לא נמצאו דרכי ניווט


                    }
                });
        }
    </script>


    <script async defer
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCpJlsjlI2aKN4EubuHyf1RxGrwY6JxnZM">
    </script>
    <br />
    <br />
    <center>
         <a href="HomePage.aspx"><input type="button" value="חזרה לדף הבית" /></a>
         <%=returnTO %>
     </center>



</body>
</html>
