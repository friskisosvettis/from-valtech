///**
//* Maps Module
//*
//* @author Veronika Jeppsson
//*/
///*jslint plusplus: true, vars: true, browser: true, white:true*/
///*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery');

var _mediumBreakpoint = 769;
var _initialized = false;
var _mapObject = $('#map');
// maps object contains the public variable/functions that is exported (module.export = maps)
var maps = {

	// Initialize script and bind events
    init: function () {
		if(_mapObject.length > 0) {
			
			// Get all centers that should be shown on map
			var mapList = $('.map__list ul > li');
			var mapListLength = mapList.length;
			if (mapListLength > 3) {
			    $('.map__list').append('<button class="map__btn" data-alt-text="Visa färre">Visa mer</button>');
			}

			// Hide all elements except the threee first
			$('.map__list').find('li:gt(2)').addClass('hidden');

			if ($(window).width() > _mediumBreakpoint) {
				loadGoogleMaps();
			} 
		}

		function loadScripts(showThisPin) {
			$.getScript(
				'https://maps.googleapis.com/maps/api/js?' +
				'key=AIzaSyD3Fzwhnxu8K80A--t1OTriXGNhU5o6dkE'
			).done(function( script, textStatus ) {
				initializeMap(showThisPin);
			});
		}

		function loadGoogleMaps(showThisPin) {
			if(_initialized){
				return;
			} else {
				loadScripts(showThisPin);
			}
		}

		// Create an empty array for our markers
		var markers = [];
		var locations = [];

		function initializeMap(showThisPin) {
			var styles = [
				{
					"featureType": "administrative",
					"elementType": "labels.text.fill",
					"stylers": [
						{
							"color": "#ada6a0"
						}
					]
				},
				{
					"featureType": "administrative.country",
					"elementType": "labels.text.fill",
					"stylers": [
						{
							"color": "#483729"
						}
					]
				},
				{
					"featureType": "administrative.province",
					"elementType": "labels.text.fill",
					"stylers": [
						{
							"color": "#483729"
						}
					]
				},
				{
					"featureType": "administrative.locality",
					"elementType": "labels.text.fill",
					"stylers": [
						{
							"color": "#483729"
						}
					]
				},
				{
					"featureType": "administrative.neighborhood",
					"elementType": "geometry.fill",
					"stylers": [
						{
							"color": "#483729"
						}
					]
				},
				{
					"featureType": "administrative.land_parcel",
					"elementType": "geometry.fill",
					"stylers": [
						{
							"color": "#483729"
						}
					]
				},
				{
					"featureType": "landscape",
					"elementType": "all",
					"stylers": [
						{
							"visibility": "simplified"
						}
					]
				},
				{
					"featureType": "landscape",
					"elementType": "labels.text.fill",
					"stylers": [
						{
							"visibility": "on"
						},
						{
							"color": "#ada6a0"
						}
					]
				},
				{
					"featureType": "landscape.man_made",
					"elementType": "geometry.fill",
					"stylers": [
						{
							"visibility": "on"
						},
						{
							"saturation": "-100"
						},
						{
							"weight": "1.39"
						},
						{
							"hue": "#ff9500"
						},
						{
							"lightness": "45"
						}
					]
				},
				{
					"featureType": "landscape.natural",
					"elementType": "geometry.fill",
					"stylers": [
						{
							"color": "#f2f2f2"
						}
					]
				},
				{
					"featureType": "landscape.natural.landcover",
					"elementType": "geometry.fill",
					"stylers": [
						{
							"color": "#fcfcfc"
						}
					]
				},
				{
					"featureType": "poi",
					"elementType": "all",
					"stylers": [
						{
							"visibility": "simplified"
						}
					]
				},
				{
					"featureType": "poi",
					"elementType": "geometry.fill",
					"stylers": [
						{
							"color": "#e4e4e2"
						}
					]
				},
				{
					"featureType": "poi",
					"elementType": "labels.text.fill",
					"stylers": [
						{
							"color": "#483729"
						}
					]
				},
				{
					"featureType": "poi",
					"elementType": "labels.icon",
					"stylers": [
						{
							"visibility": "off"
						}
					]
				},
				{
					"featureType": "poi.park",
					"elementType": "geometry.fill",
					"stylers": [
						{
							"color": "#dbe9ce"
						}
					]
				},
				{
					"featureType": "road",
					"elementType": "labels",
					"stylers": [
						{
							"visibility": "simplified"
						}
					]
				},
				{
					"featureType": "road",
					"elementType": "labels.icon",
					"stylers": [
						{
							"visibility": "off"
						}
					]
				},
				{
					"featureType": "road.highway",
					"elementType": "all",
					"stylers": [
						{
							"visibility": "off"
						},
						{
							"color": "#ad9b8d"
						}
					]
				},
				{
					"featureType": "road.highway",
					"elementType": "geometry",
					"stylers": [
						{
							"visibility": "on"
						}
					]
				},
				{
					"featureType": "road.highway",
					"elementType": "geometry.fill",
					"stylers": [
						{
							"color": "#c7c3be"
						}
					]
				},
				{
					"featureType": "road.highway",
					"elementType": "geometry.stroke",
					"stylers": [
						{
							"visibility": "on"
						},
						{
							"color": "#bab4ad"
						}
					]
				},
				{
					"featureType": "road.arterial",
					"elementType": "geometry.stroke",
					"stylers": [
						{
							"visibility": "off"
						}
					]
				},
				{
					"featureType": "road.local",
					"elementType": "all",
					"stylers": [
						{
							"visibility": "on"
						}
					]
				},
				{
					"featureType": "road.local",
					"elementType": "geometry.fill",
					"stylers": [
						{
							"color": "#ffffff"
						}
					]
				},
				{
					"featureType": "road.local",
					"elementType": "geometry.stroke",
					"stylers": [
						{
							"visibility": "off"
						}
					]
				},
				{
					"featureType": "road.local",
					"elementType": "labels.text.fill",
					"stylers": [
						{
							"color": "#555555"
						}
					]
				},
				{
					"featureType": "transit",
					"elementType": "all",
					"stylers": [
						{
							"visibility": "simplified"
						}
					]
				},
				{
					"featureType": "transit",
					"elementType": "geometry.fill",
					"stylers": [
						{
							"color": "#d2d0cd"
						}
					]
				},
				{
					"featureType": "transit",
					"elementType": "labels.text.fill",
					"stylers": [
						{
							"color": "#aba6a1"
						}
					]
				},
				{
					"featureType": "transit",
					"elementType": "labels.icon",
					"stylers": [
						{
							"visibility": "off"
						}
					]
				},
				{
					"featureType": "transit.station",
					"elementType": "labels.icon",
					"stylers": [
						{
							"visibility": "off"
						}
					]
				},
				{
					"featureType": "water",
					"elementType": "all",
					"stylers": [
						{
							"visibility": "simplified"
						},
						{
							"color": "#abbaa4"
						}
					]
				},
				{
					"featureType": "water",
					"elementType": "geometry.fill",
					"stylers": [
						{
							"saturation": "-100"
						},
						{
							"lightness": "52"
						},
						{
							"color": "#d4dddd"
						}
					]
				}
			];

			var map;
			//Constructor creates a map - only center and zoom is required
		    map = new google.maps.Map(document.getElementById('map'), {
		        //center: { lat: 59.3361193, lng: 18.0341168 }, //TODO LOOK AT THIS! WHY CENTRT
		        zoom: 12,
		        maxZoom: 18,
		        minZoom: 2,
		        styles: styles
		    });

			createMarkers(mapList, mapListLength);

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
					icon: '/assets/images/map_pin.png',
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

			if ($(window).width() > 769) {
				var width = ($(window).width() / 2);
				map.panBy(-width, 0);
				google.maps.event.addListenerOnce(map, 'bounds_changed', function(event) {
					if (this.getZoom()){
						this.setZoom(this.getZoom() -1);
					}
				});
			}
			_initialized = true;

			// This function populates the infowindow when the marker is clicked. We'll only allow
			// one infowindow which will open at the marker that is clicked, and populate based
			// on that markers position.
			function populateInfoWindow(marker, infowindow) {
				// Check to make sure the infowindow is not already opened on this marker.
				if (infowindow.marker != marker) {
					infowindow.marker = marker;
					infowindow.setContent('<div class="map__infowindow"><a href="'+ marker.url + '">' + marker.title + '</a><p>' + marker.address + '</p></div>');
					infowindow.open(map, marker);
					// Make sure the marker property is cleared if the infowindow is closed.
					infowindow.addListener('closeclick',function(){
						infowindow.setMarker = null;
					});
				}
			}

			function createMarkers(mapList, mapListLength) {
				// Each item in locations array
				for (var i = 0; i < mapListLength; i ++) {
					var mapTitle = $(mapList[i]).attr('data-map-title');
					var mapAddress = $(mapList[i]).attr('data-map-address');
					var mapUrl = $(mapList[i]).attr('data-map-url');
					var mapLat = parseFloat($(mapList[i]).attr('data-map-lat'));
					var mapLng = parseFloat($(mapList[i]).attr('data-map-lng'));
					locations.push({title: mapTitle, address: mapAddress, url: mapUrl, location: {lat: mapLat, lng: mapLng}});
				}
			};

			// //If the user have clicked on a list item and want that pin showed 
			if(showThisPin) {
				showPin(showThisPin);
			}
		}
		function showPin(index) {
			$('#map-tab').trigger('click');
			google.maps.event.trigger(markers[index], 'click');
		}

		// When user clicks on "Map" tab
		$('#map-tab').on('click', function () {
			if(!_initialized) {
				loadGoogleMaps();
			} else {
				google.maps.event.trigger(map, "resize");	
			}
		});


		$('button.map__list--show').on('click', function (e) {
			e.preventDefault();
			var index = $(this).closest('li').attr('data-i');			
			if(!_initialized) {
				loadGoogleMaps(index);
			} else {
				//TODO: Look into why it not works to click on two list items on mobile
			    showPin(index);
			}

			// google.maps.event.trigger(map, "resize");
			// if ($(window).width() < 769) {
			// 	// Smaller than medium:
			// 	console.log('step1');
			// 	// Trigger click on map and resize map to fit screen
			// 	$(this).closest('.map__container').find('#panel2').trigger('click');
			// 	google.maps.event.trigger(map, "resize");
			// }	
		});

		$('.map__btn').on('click', function () {
			// Show more options in list
			$(this).closest('.map__list').find('li:gt(2)').toggleClass('hidden');

			if ($(window).width() > 769) {
				// Larger than medium:
				// Update the height of the container and map in order to show/hide list elements
				var newHeight = $(this).closest('.map__container').find('.map__list').outerHeight();
				$(this).closest('.map__container').css('height', newHeight);
				$(this).closest('.map__container').find('#map').css('height', newHeight);
				google.maps.event.trigger(map, "resize");
			}				
		});
		$('*[data-alt-text]').on('click', function () {
			// Get new and old text for button
			var oldText = $(this).text();
			var newText = $(this).attr('data-alt-text');

			// Update with the new text & save the old
 			$(this).text(newText);
 			$(this).attr('data-alt-text', oldText);
		});
    }
}

module.exports = maps;