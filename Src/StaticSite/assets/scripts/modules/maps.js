/**
* Maps Module
*
* @author Veronika Jeppsson
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery');

// maps object contains the public variable/functions that is exported (module.export = maps)
var maps = {

	// Initialize script and bind events
    init: function () {
        var map;
        //Constructor creates a map - only center and zoom is required
        map = new google.maps.Map(document.getElementById('map'), {
            center: {lat: 59.3361193,lng: 18.0341168},
            zoom: 12,
            maxZoom: 18,
            minZoom: 2
        })

        // Create an empty array for our markers
        var markers = [];

        // Example with more than one marker should come from the database
        var locations = [
            {title: 'Friskis & Svettis Kungsholmen', address: "Sankt Eriksgatan 54, Stockholm",  url: "www.google.com", location: {lat: 59.3361193,lng: 18.0341168}},
            {title: 'Friskis & Svettis Gärdet', address: "Furusundsagatan 21, Stockholm",  url: "www.valtech.com", location: {lat: 59.347710,lng: 18.108242}},
            {title: 'Friskis & Svettis Ringen', address: "Ringvägen 32, Stockholm",  url: "www.valtech.se", location: {lat: 59.307722,lng: 18.074342}},
            {title: 'Friskis & Svettis Sveavägen', address: "Sveavägen 2, Stockholm", url: "www.instagram.com",  location: {lat: 59.341158,lng: 18.057744}}
        ];

        var largeInfowindow = new google.maps.InfoWindow();
        var bounds = new google.maps.LatLngBounds();
        // var southCenterBound =  new google.maps.LatLng(bounds.getSouthWest().lat(),bounds.getCenter().lng());
        // var northEastBound =  bounds.getNorthEast();
        // var centerThis = new google.maps.LatLng(southCenterBound,northEastBound); //with centerThis lite bättre centrerings


        // The following group uses the location array to create an array of markers on initialize.
        for (var i = 0; i < locations.length; i++) {
            // Get the position from the location array.
            var position = locations[i].location;
            var title = locations[i].title;
            var address = locations[i].address;
            var url = locations[i].url;

            // Create a marker per location, and put into markers array.
            var marker = new google.maps.Marker({
                map: map,
                position: position,
                title: title,
                address: address,
                url: url,
                animation: google.maps.Animation.DROP,
                id: i
            });
            // Push the marker to our array of markers.
            markers.push(marker);
            // Create an onclick event to open an infowindow at each marker.
            marker.addListener('click', function() {
                populateInfoWindow(this, largeInfowindow);
            });
            bounds.extend(markers[i].position);
        }
        // Extend the boundaries of the map for each marker
        map.fitBounds(bounds);

        // This function populates the infowindow when the marker is clicked. We'll only allow
        // one infowindow which will open at the marker that is clicked, and populate based
        // on that markers position.
        function populateInfoWindow(marker, infowindow) {
            // Check to make sure the infowindow is not already opened on this marker.
            if (infowindow.marker != marker) {
                infowindow.marker = marker;
                infowindow.setContent('<div><a href="'+ marker.url + '">' + marker.title + '</a></div><div>' + marker.address + '</div>');
                infowindow.open(map, marker);
                // Make sure the marker property is cleared if the infowindow is closed.
                infowindow.addListener('closeclick',function(){
                    infowindow.setMarker = null;
                });
            }
        }

        $('button.map__list--show').on('click', function () {
            var index = $(this).closest('li').attr('data-i');
            google.maps.event.trigger(markers[index], 'click');
        });

        $('.map__btn').on('click', function () {
            $(this).closest('.map__list').find('li:gt(3)').toggleClass('hidden');
        });
    }
}

module.exports = maps;