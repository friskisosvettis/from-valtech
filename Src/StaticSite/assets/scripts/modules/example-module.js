/**
* Example Module
*
* @author bjarke.rasmussen
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery');

// This variable is private as it isn't exposed to the module exported (module.export)
var _counter = 0;

// exampleModule object contains the public variable/functions that is exported (module.export = exampleModule)
var exampleModule = {
	// Functions that returns _counter incremented or decremented
	increment: function () { return _counter++; },
	decrement: function () { return _counter--; },

	// Initialize script and bind events
    init: function () {
    	// Bind click event and bind this (exampleModule object) to the event to pass the functions/variables from the exampleModule object
    	$('.increment-button').on('click', function () {
    		console.log(this.increment());
    	}.bind(this));

    	$('.decrement-button').on('click', function () {
    		console.log(this.decrement());
    	}.bind(this));
    }
}

module.exports = exampleModule;