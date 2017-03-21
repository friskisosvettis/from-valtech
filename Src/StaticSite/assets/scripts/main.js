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
var fixedRibbon = require('./modules/fixed-ribbon'),
	visualHero = require('./modules/visual-hero'),
	foldExpand = require('./modules/fold-expand'),
	loadSvg = require('./modules/load-svg'),
    fitImages = require('./modules/object-fit-images');

$(function () {
	fixedRibbon.init();
	foldExpand.init();
	loadSvg.loadSvg();
	visualHero.init();
	fitImages.init();

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
