/**
* mapsApiLoader Module
*
* @author villads.ruby
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery');

var mapsApiLoader = {
    //Only call init function from within a module that actually requires the google api in order to limit requests (i.e. license cost)
    init: function () {
        
        if (window.mapsApiLoaderIsLoaded || window.mapsApiLoaderIsLoading) {
            return;
        }

        window.mapsApiLoaderIsLoading = true;
        $(document).bind("mapsApiLoader:events:loaded");
        
        $.getScript(
            'https://maps.googleapis.com/maps/api/js?' +
            'key=AIzaSyD3Fzwhnxu8K80A--t1OTriXGNhU5o6dkE' +
            '&libraries=places'
        ).done(function () {
            window.mapsApiLoaderIsLoaded = true;
            $(document).trigger("mapsApiLoader:events:loaded");
        });
    }
}
module.exports = mapsApiLoader;
