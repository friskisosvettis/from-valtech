/**
* Video Module
*
* @author Veronika Jeppsson
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery');

var videoModule = {

	// Initialize script and bind events
    init: function () {

       $('.media-container__youtube').each(function() {

            var youtube = $(this);
            youtube.on( "click", function() {
                var url = 'https://www.youtube.com/embed/'+ youtube.attr("data-js-youtube") + '?rel=0&showinfo=0&autoplay=1';
                $(this).append('<iframe class="media-container__media" src='+ url + ' width="560" height="315" frameborder="0" allowfullscreen></iframe>');
                $(this).find('.media-container__control').hide();
            } );
       });
    }
}

module.exports = videoModule;