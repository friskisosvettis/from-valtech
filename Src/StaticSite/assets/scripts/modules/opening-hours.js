/**
* opening-hours Module
*
* @author villads.ruby
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery');
var _mapsApi = require('../modules/mapsApiLoader');
var _openingHoursObject = $('.maps-api-opening-hours');
var _serviceHelper = $('#opening-hours-service-helper');

var openingHoursModule = { 
    init: function() {
        
        if (_openingHoursObject.length <= 0)
            return;

        var module = this;
        //only inits maps api when _openingHoursObject present
        $(document).on("mapsApiLoader:events:loaded", function () {
            module.getOpeningHours();
        });
        _mapsApi.init();
    },
    getOpeningHours: function() {

        var service = new google.maps.places.PlacesService(_serviceHelper.get(0));

        var dayOfWeek = _openingHoursObject.data("day-of-week"); 
        var placeId = _openingHoursObject.data("google-place-id");

        service.getDetails({ placeId: placeId },
            function(place, status) {
                if (status === google.maps.places.PlacesServiceStatus.OK) {

                    var dayOfWeekInt = dayOfWeek - 1; 
                    var today = document.getElementById('opening_hours_today');
                    var todayOpeningHours = place.opening_hours.weekday_text[dayOfWeekInt];
                    var todayTime = todayOpeningHours.substring(todayOpeningHours.indexOf(':') + 2,
                        todayOpeningHours.length + 1);
                    today.innerHTML = "&Ouml;ppet idag: <strong>" + todayTime + "</strong>";

                    //Get entire week
                    for (var i = 0; i < place.opening_hours.weekday_text.length; ++i) {
                        var openHoursString = place.opening_hours.weekday_text[i];
                        var tr = document.createElement("tr");
                        var tdDay = document.createElement("td");
                        tdDay.innerHTML = openHoursString.substring(0, openHoursString.indexOf(':'));
                        var tdTime = document.createElement("td");
                        tdTime.innerHTML = openHoursString
                            .substring(openHoursString.indexOf(':') + 2, openHoursString.length + 1);
                        tr.appendChild(tdDay);
                        tr.appendChild(tdTime);
                        document.getElementById('opening_hours_week').appendChild(tr);
                    }
                }
            });
    }
}

module.exports = openingHoursModule;