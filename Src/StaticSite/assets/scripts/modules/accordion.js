/**
* Accordion Module
*
* @author veronika jeppsson
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery');

var accordionModule = {

	// Initialize script and bind events
    init: function () {

        //When initalized hide expandable section
        $('.accordion button').removeClass('active');
        $('.accordion div').removeClass('open');

        //Toggle visability on click
        $('.accordion button').on('click', function () {
            $(this).toggleClass('active');
            $(this).parent('.accordion').children('div').toggleClass('open');
        });
    }
}

module.exports = accordionModule;