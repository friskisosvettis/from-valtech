/**
* Carousel Module
*
* @author Veronika Jeppsson
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery'),
    slick = require('slick-browserify-js');

var slickSlider = {

	// Initialize script
    init: function () {
        $(document).ready(function() {
            $('*[data-js-slider]').slick({
                arrows: true,
                dots: true,
                autoplay: true,
                draggable: false,
                fade: true,
                speed: 1000,
                autoplaySpeed: 5000,
                prevArrow: '<div class="carousel__btn carousel__btn--prev"><button type="button" class="slick-prev">Previous</button></div>',
                nextArrow: '<div class="carousel__btn carousel__btn--next"><button type="button" class="slick-next">Next</button></div>',
            });
        });
    }
}

module.exports = slickSlider;