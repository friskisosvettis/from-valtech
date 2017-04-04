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
        // Bind click event and bind this (exampleModule object) to the event to pass the functions/variables from the exampleModule object
        $(_navigationContentClose).on('click', function () {
            $(_navigationContent).toggle();
            $(_navigationContentClose).toggle();
            $('.navigation--overlay').toggle();

            // Close more option if open
             if($(_moreContent).hasClass('open')) {
                $('.navigation__item').removeClass('hide');
                $(_moreContent).removeClass('open');
                $(_moreContent).hide();
            }
        }.bind(this));

        $(_navigation).on('click', function () {
            $(_navigationContent).toggle();
            $(_navigationContentClose).toggle();
            $('.navigation--overlay').toggle();
        }.bind(this));

        $(_more).on('click', function () {
            $(_moreContent).toggle().toggleClass('open');
            $(_more).toggleClass('open');
            $('.navigation__item').not($(_more).parent('.navigation__item')).toggleClass('hide');
            if($('.navigation--overlay').length < 1) {
                $('.navigation--overlay').toggle();
            }
        }.bind(this));

    }
}

module.exports = navigationModule;