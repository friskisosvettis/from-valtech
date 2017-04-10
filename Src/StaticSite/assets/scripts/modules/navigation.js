/**
* Example Module
*
* @author Veronika Jeppsson
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery');

// The navigation item
var _navigation = $('*[data-menu]');
var _navigationContent = $('*[data-menu-content]');
var _navigationContentClose =  $('*[data-menu-close]');
var _more = $('*[data-menu-more]');
var _moreContent =  $('*[data-menu-more-content]');

// The navigation module is for expanding/navigating the navigation
var navigationModule = {

	// Initialize script and bind events
    init: function () {
        $(_navigationContentClose).on('click', function () {
            $(_navigationContent).toggle();
            $(_navigationContentClose).toggle();

            // Close more option if open
             if($(_moreContent).hasClass('open')) {
                $('.navigation__item').removeClass('hide');
                $(_more).trigger('click');
            }
        }.bind(this));

        $(_navigation).on('click', function () {
            $(_navigationContent).toggle();
            $(_navigationContentClose).toggle();
        }.bind(this));

        $(_more).on('click', function () {
            $(_moreContent).toggle().toggleClass('open');
            $(_more).toggleClass('open');
            $('.navigation__container').toggleClass('open');
            $('.navigation__item').not($(_more).parent('.navigation__item')).toggleClass('hide');
        }.bind(this));

        $(window).on('scroll', function() {
            if($('.navigation__container').length) {
                $('.navigation__container').addClass('scroll');
            }
        }.bind(this));

    }
}

module.exports = navigationModule;