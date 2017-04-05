/**
* Example Module
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
			$('.tab__title > a').on('click', function (e) {
				e.preventDefault();
				if(!$(this).parent('li').hasClass('active')) {
					var tabs = $(this).closest('ul');
					$(tabs).find($('.tab__title')).removeClass('active');
					$(this).parent('li').addClass('active');
					var tabsFor = $(tabs).data('tab');
					$('*[data-tab-'+tabsFor+']').toggleClass('hidden-small--block');
				}
			});
		});
    }
}

module.exports = tabs;