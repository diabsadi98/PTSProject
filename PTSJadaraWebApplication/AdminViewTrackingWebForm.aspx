<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminViewTrackingWebForm.aspx.cs" Inherits="PTSJadaraWebApplication.AdminViewTrackingWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div id="Refresh" style="width: 100px; min-height: 25px">
        </div>
        <div id="map" style="width: 100%; min-height: 500px">
        </div>
    <script type="text/javascript">

        var locationPoints = false

        if (locationPoints) {

            var lat = parseFloat(locationPoints.split(';')[0]);
            var lng = parseFloat(locationPoints.split(';')[1]);

            if (lat && lng) {
                globalLat = lat;
                globalLng = lng;

                setTimeout(function () {
                    document.getElementById('map').style.height = screen.height - 250 + "px";
                }, 500);

                initMap();
            }

        }

        var contentString = '<div id="content" style="color:black"></div>';

        function initMap() {
            var targetPosition = { lat: 31, lng: 32 };
            var map = new window.google.maps.Map(document.getElementById('map'), {
                zoom: 16,
                center: targetPosition
            });

            var infowindow = new google.maps.InfoWindow({
                content: contentString
            });
            var marker = new google.maps.Marker({
                animation: google.maps.Animation.DROP,
                position: targetPosition,
                map: map,
                title: '',
                url: ''
            });

            marker.addListener('click', function () {
                window.location = marker.url;
            });
        }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBMrMbrDlorv3dfhJ6HUUkEnFbLshWvUzk&callback=initMap" type="text/javascript"></script>
</asp:Content>
