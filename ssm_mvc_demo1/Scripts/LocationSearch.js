var geocoder = new google.maps.Geocoder();

// ===== INITIALIZE THE MAP BLOCK =====

google.maps.event.addDomListener(window, 'load', initialize);

// ===== END OF INITIALIZING THE MAP BLOCK =====

function initialize() {

    var latLng = new google.maps.LatLng(24.727755, 46.664246);

    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 13,
        center: latLng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    var marker = new google.maps.Marker({
        position: latLng,
        title: 'Football field location',
        map: map,
        draggable: true
    });

    google.maps.event.addListener(marker, 'drag', function () {
        updateMarkerPosition(marker.getPosition());
    });

}

function ShowLocation() {
    alert($('#hiddenValue').val().toString().slice(0, 9) + ", " + $('#hiddenValue1').val().toString().slice(0, 9));
}


function updateMarkerPosition(latLng) {

    $("#hiddenValue").val(latLng.lat);
    $("#hiddenValue1").val(latLng.lng);
}

