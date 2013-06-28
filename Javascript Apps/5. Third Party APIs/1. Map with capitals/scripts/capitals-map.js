/// <reference path="class.js"/>
/// <reference path="jquery-2.0.2.min.js" />
/// <reference path="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false" />

$.ajaxSetup({ "async": false });

var capitalsArray = [];
var infoWindows = [];

var Capital = function (name, latitude, longitude, country) {
    this.name = name;
    this.lat = latitude;
    this.long = longitude;
    this.country = country;
    this.contentString = '<div id="content">' +
        'Country: ' + this.country + ', Capital: ' +
        this.name +
        '</div>';
}

var currentCapitalIndex;

var sofia = new Capital("Sofia", 42.702623, 23.31552, "Bulgaria");
capitalsArray.push(sofia);
var london = new Capital("London", 51.51, -0.13, "England");
capitalsArray.push(london);
var taipei = new Capital("Taipei", 25.04, 121.53, "Taiwan");
capitalsArray.push(taipei);
var stockholm = new Capital("Stockholm", 59.33, 18.06, "Sweden");
capitalsArray.push(stockholm);
var skopjie = new Capital("Skopje", 42.00, 21.43, "Macedonia");
capitalsArray.push(skopjie);
var budapest = new Capital("Budapest", 47.50, 19.08, "Hungary");
capitalsArray.push(budapest);
var sofia = new Capital("Sofia", 42.702623, 23.31552);
capitalsArray.push();
var sofia = new Capital("Sofia", 42.702623, 23.31552);
capitalsArray.push();
var sofia = new Capital("Sofia", 42.702623, 23.31552);
capitalsArray.push();
var sofia = new Capital("Sofia", 42.702623, 23.31552);
capitalsArray.push();
var sofia = new Capital("Sofia", 42.702623, 23.31552);
capitalsArray.push();

var defaultLatLng = new google.maps.LatLng(capitalsArray[0].lat, capitalsArray[0].long)
currentCapitalIndex = 0;

var map;
function initialize() {
    var mapOptions = {
        zoom: 7,
        center: defaultLatLng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    map = new google.maps.Map(document.getElementById('map-canvas'),
        mapOptions);

    var markers = [];

    for (var i = 0; i < capitalsArray.length; i++) {
        var currentCountry = capitalsArray[i];
        var currentCountryLatLng =
            new google.maps.LatLng(currentCountry.lat, currentCountry.long);

        var marker = new google.maps.Marker({
            position: currentCountryLatLng,
            map: map,
            title: currentCountry.name
        });

        infoWindows.push(new google.maps.InfoWindow({
            content: currentCountry.contentString
        }));

        markers.push(marker);
    }

    for (var i = 0; i < markers.length - 1; i++) {

        google.maps.event.addListener(markers[i], 'click', function (ev) {
            infowindow = new google.maps.InfoWindow();
            infowindow.content = markers[i].contentString;
            infowindow.open(map, markers[i]);
        });
    }
}

google.maps.event.addDomListener(window, 'load', initialize);


var html = '<ul id="capitals-list">';
for (var i = 0; i < capitalsArray.length; i++) {
    html += '<li class="capital-list-item" data-capitals-index=' + i +
        '><a href="#">' + capitalsArray[i].name + '</a></li>'
}
html += '</ul>';

$('#capitals-list-container').html(html);

$('#capitals-list').on('click', 'li', function () {
    currentCapitalIndex = $(this).data('capitals-index');
    var currentCapital = capitalsArray[currentCapitalIndex];
    var newLatLng = new google.maps.LatLng(currentCapital.lat, currentCapital.long);
    map.panTo(newLatLng);
});

$('#previous-capital-btn').on('click', function () {
    currentCapitalIndex--;

    if (currentCapitalIndex === -1) {
        currentCapitalIndex = capitalsArray.length - 1;
    }
    var prevCapital = capitalsArray[currentCapitalIndex];
    var prevLatLng = new google.maps.LatLng(prevCapital.lat, prevCapital.long);
    map.panTo(prevLatLng);
});

$('#next-capital-btn').on('click', function () {
    currentCapitalIndex++;

    if (currentCapitalIndex === capitalsArray.length) {
        currentCapitalIndex = 0;
    }
    var prevCapital = capitalsArray[currentCapitalIndex];
    var prevLatLng = new google.maps.LatLng(prevCapital.lat, prevCapital.long);
    map.panTo(prevLatLng);
});