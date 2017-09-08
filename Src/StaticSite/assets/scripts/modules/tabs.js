/**
* Tabs Module
*
* @author veronika jeppsson
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery');

var tabs = {
    init: function () {
        $(document).ready(function(){
            $('.tabs__title > a').on('click', function (e) {
                e.preventDefault();
                if(!$(this).parent('li').hasClass('active')) {
                    var tab = $(this).closest('ul');
                    $(tab).find($('li')).removeClass('active');
                    $(this).parent('li').addClass('active');
                    var tabsFor = $(tab).data('js-tabs');
                    $('*[data-js-tabs-'+tabsFor+']').toggleClass('visible-medium-up--block');
                }
            });
        });
    }
}

module.exports = tabs;