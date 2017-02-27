/**
* Visual Hero
*
* @author bjarke.rasmussen
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery');

// Modules
var gallery = require('./gallery');

var visualHero = {
    init: function () {
        $('.js-visual-hero').on('click', '.js-visual-hero-toggle-primary', function (e) {
            var $this = $(e.currentTarget),
                $hero = $(e.delegateTarget);

            if ($hero.hasClass('js-show-secondary')) {
                $hero.removeClass('js-show-secondary')
            } else {
                // Open gallery
                var images = $this.data('gallery');

                gallery.showGallery(images);
            }
        }.bind(this));

        $('.js-visual-hero').on('click', '.js-visual-hero-toggle-secondary', function (e) {
            var $this = $(e.currentTarget),
                $hero = $(e.delegateTarget);

            if (!$hero.hasClass('js-show-secondary')) {
                $hero.addClass('js-show-secondary')
            } else {
                // Open gallery
                var images = $this.data('gallery');

                gallery.showGallery(images);
            }
        }.bind(this));
    }
}

module.exports = visualHero;