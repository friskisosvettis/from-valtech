/**
* Fold Expand
*
* @author bjarke.rasmussen
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery');

var foldExpand = {
	init: function () {
        $('.js-fold-expand').on('click', '.js-fold-expand-toggle', function (e) {
            var $btn = $(e.currentTarget),
                $container = $(e.delegateTarget),
                $foldExpand = $container.find('.fold-expand');

            if (!$container.hasClass('js-expanded')) {
                // Is folded
                $container.addClass('js-expanded');

                $foldExpand.css({
                    'maxHeight': $container.find('.fold-expand')[0].scrollHeight
                });
                
                $foldExpand.one('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', function () {
                    // Animation expanding
                    $(this).css('maxHeight', 'none');
                });
            } else {
                // Is open
                $container.removeClass('js-expanded');

                $foldExpand.css({
                    'maxHeight': $container.find('.fold-expand')[0].scrollHeight
                })

                setTimeout(function () {
                    $foldExpand.css('maxHeight', '');
                }, 100);
            }
        });
    }
}

module.exports = foldExpand;