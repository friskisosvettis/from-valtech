/**
* Load SVG
*
* @author bjarke.rasmussen
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery');

var svg = {
	loadSvg: function () {
        $('[data-svg]').each(function (i, el) {
            var $this = $(el),
                svgPath = $this.data('svg');

            this.getSvg(svgPath, function (data) {
                var svg = $(data).find('svg');
                
                $this.append(svg[0]);
            });
        }.bind(this));
    },

    getSvg: function (svgPath, callback) {
        $.get(svgPath, function (data) {
            callback(data);
        });
    }
}

module.exports = svg;