/*
 * NAMING CONVENTIONS:
 * -------------------
 * Singleton-literals and prototype objects:  PascalCase
 *
 * Functions and public variables:            camelCase
 *
 * Global variables and constants:            UPPERCASE
 *
 * Private variables:                         _underscorePrefix
 */

/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global require: true*/

'use strict';

// Vendors
var $ = require('jquery'),
	_ = require('_');

// Modules
var devbridgeAutocomplete = require('./modules/autocomplete'),
    fitImages = require('./modules/object-fit-images'),
	slickSlider = require('./modules/carousel'),
	maps = require('./modules/maps'),
	mapsApiLoader = require('./modules/mapsApiLoader'),
	openingHours = require('./modules/opening-hours'),
	tabs = require('./modules/tabs'),
	navigation = require('./modules/navigation'),
	video = require('./modules/video'),
	accordion = require('./modules/accordion');

$(function () {
	fitImages.init();
	slickSlider.init();
	maps.init();
    openingHours.init();
	tabs.init();
	navigation.init();
	devbridgeAutocomplete.init();
	video.init();
	accordion.init();

	$('a[href*="#"]:not([href="#"])').click(function() {
		if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
			var target = $(this.hash);
			target = target.length ? target : $('[name=' + this.hash.slice(1) +']');
			if (target.length) {
				$('html, body').animate({
					scrollTop: target.offset().top
				}, 1000);
				return false;
			}
		}
	});
});
