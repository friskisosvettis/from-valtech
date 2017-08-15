/**
* Navigation Module
*
* @author Veronika Jeppsson
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery');

// The navigation item
var _navigation = $('*[data-js-menu]');
var _navigationContent = $('*[data-js-menu-content]');
var _navigationContentClose = $('*[data-js-menu-close]');
var _navigationContainer = $('*[data-js-menu-container]');
var _more = $('*[data-js-menu-more]');
var _moreContent =  $('*[data-js-menu-more-content]');
var _navigationTop = $('.navigation--top');
var _totalMenuHeight =  _navigationContainer.outerHeight() + _navigationTop.outerHeight();
var _scroll = $('.hero').outerHeight() - _totalMenuHeight;

// The navigation module is for expanding/navigating the navigation
var navigationModule = {

	// Initialize script and bind events
    init: function () {
        $(_navigationContentClose).on('click', function () {
            $(_navigationContent).toggle();
            $(_navigationContentClose).toggle();

            // Close more option if open
            if($(_more).hasClass('open')) {
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
            $(_navigationContainer).toggleClass('open');
            $('.navigation__item').not($(_more).parent('.navigation__item')).toggleClass('hide');
        }.bind(this));

        var lastScrollTop = 0;
        $(window).on('scroll', function() {
            $(_navigationContainer).toggleClass('animation', $(document).scrollTop() > _scroll/2);
            $(_navigationContainer).toggleClass('scroll',$(document).scrollTop() >= _scroll);

            var st = $(this).scrollTop();
            if (st < lastScrollTop || st <= 0){
                // show nav when scrolling up
                _navigationTop.removeClass('hide');
            } else {
                // hide nav when scrolling down
                _navigationTop.addClass('hide');
            }
            lastScrollTop = st;

        });

    }
}

module.exports = navigationModule;