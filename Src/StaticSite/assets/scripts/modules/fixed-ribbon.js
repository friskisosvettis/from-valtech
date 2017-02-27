/**
* Fixed Ribbon
*
* @author bjarke.rasmussen
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery'),
    _ = require('_');

var fixedRibbon = {
    init: function () {
        $(window).on('scroll', function (e) {
            var win = $(e.currentTarget),
                winOffset = win.scrollTop();

            $('.js-ribbon-fixed').each(function (i, el) {
                if ($(el).offset().top <= winOffset) {
                    $(el).css('height', $(el).outerHeight());
                    $(el).addClass('js-is-fixed');
                } else {
                    $(el).removeClass('js-is-fixed');
                }
            }.bind(this));
        }.bind(this));

        $(window).on('resize', _.debounce(function () {
            $('.js-ribbon-fixed.js-is-fixed').each(function (i, el) {
                $(el).css('height', $(el).outerHeight());
            });
        }, 150));
    }
}

module.exports = fixedRibbon;