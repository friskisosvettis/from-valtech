/**
* Fit videos Module
*
* @author Fredrik Höjdegård
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery'),
    objectFitVideos = require('object-fit-videos');


var fitVideos = {
    // Uses objectFitvideos in order to Polyfill object-fit that does not work in IE yet (https://www.npmjs.com/package/object-fit-videos)
    // Makes image as a background video in non supported browsers
    init: function () {
        $(function () { objectFitVideos() });
    }
}

module.exports = fitVideos;