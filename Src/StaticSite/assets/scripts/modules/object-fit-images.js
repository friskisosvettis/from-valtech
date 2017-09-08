/**
* Fit images Module
*
* @author Veronika Jeppsson
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery'),
    objectFitImages = require('object-fit-images');


var fitImages = {
    // Uses objectFitImages in order to Polyfill object-fit that does not work in IE yet (https://www.npmjs.com/package/object-fit-images)
    // Makes image as a background image in non supported browsers
    init: function () {
        $(function () { objectFitImages() });
    }
}

module.exports = fitImages;