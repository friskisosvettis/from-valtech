/**
* Autocomplete Module
*
* @author Veronika Jeppsson
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery'),
    devbridgeAutocomplete = require('devbridge-autocomplete');

// autocompleteModule object for autocomplete functionality for find association/training centre
var autocompleteModule = {

	// Initialize script and bind events
    init: function () {

		$(document).ready(function() {
			var _trainingCenters = [
				// TRAINING CENTERS - GROUP BY ASSOCIATION
				{ value: 'Kungsholmen', data: { sortBy: 'F&S Stockholm' , category: 'Förening' , association: 'F&S Stockholm', url: 'associationpage.html'} },
				{ value: 'Ringen', data: { sortBy:  'F&S Stockholm' , category: 'Förening' , association: 'F&S Stockholm', url: 'associationpage.html' } },
				{ value: 'Skrapan', data: { sortBy:  'F&S Stockholm' , category: 'Förening' , association: 'F&S Stockholm', url: 'associationpage.html' } },
				{ value: 'City', data: { sortBy:  'F&S Stockholm' , category: 'Förening' , association: 'F&S Stockholm',  url: 'associationpage.html' } },
				{ value: 'Skanstull', data: { sortBy:  'F&S Stockholm', category: 'Förening'  , association: 'F&S Stockholm', url: 'associationpage.html' } },
				{ value: 'Kungsholmen', data: { sortBy: 'F&S Stockholm' , category: 'Förening' , association: 'F&S Stockholm', url: 'associationpage.html'} },
				{ value: 'Skrapan', data: { sortBy:  'F&S Stockholm' , category: 'Förening' , association: 'F&S Stockholm', url: 'associationpage.html' } },
				{ value: 'City', data: { sortBy:  'F&S Stockholm' , category: 'Förening' , association: 'F&S Stockholm',  url: 'associationpage.html' } },
				{ value: 'Skanstull', data: { sortBy:  'F&S Stockholm', category: 'Förening'  , association: 'F&S Stockholm', url: 'associationpage.html' } },
				{ value: 'Kungsholmen', data: { sortBy: 'F&S Stockholm' , category: 'Förening' , association: 'F&S Stockholm', url: 'associationpage.html'} },
				{ value: 'Ringen', data: { sortBy:  'F&S Stockholm' , category: 'Förening' , association: 'F&S Stockholm', url: 'associationpage.html' } },
				{ value: 'Skrapan', data: { sortBy:  'F&S Stockholm' , category: 'Förening' , association: 'F&S Stockholm', url: 'associationpage.html' } },
				{ value: 'City', data: { sortBy:  'F&S Stockholm' , category: 'Förening' , association: 'F&S Stockholm',  url: 'associationpage.html' } },
				{ value: 'Skanstull', data: { sortBy:  'F&S Stockholm', category: 'Förening'  , association: 'F&S Stockholm', url: 'associationpage.html' } },
				{ value: 'Storcentret', data: { sortBy: 'F&S Göteborg', category: 'Förening'  , association:  'F&S Göteborg', url: 'associationpage.html' } },
				{ value: 'Storumans träningscenter', data: { sortBy: 'F&S Storuman', category: 'Förening'  , association:  'F&S Storuman', url: 'associationpage.html' } },
				{ value: 'Stocksunds gympasal', data: { sortBy: 'F&S Danderyd', category: 'Förening'  , association: 'F&S Danderyd', url: 'associationpage.html' } },
				
				// ASSOCIATIONS - GROUP BY AREA
				{ value: 'F&S Stockholm', data: { sortBy:  'Stockholm', category:  'Område' , association: 'F&S Stockholm', area: 'stockholm', url: 'associationpage.html' } },
				{ value: 'F&S Huddinge', data: { sortBy: 'Stockholm', category:  'Område' , association:  'F&S Huddinge', area: 'stockholm', url: 'associationpage.html' } },
				{ value: 'F&S Lidingö', data: { sortBy:  'Stockholm', category:  'Område'  , association: 'F&S Lindigö', area: 'stockholm', url: 'associationpage.html' } },		

				// TRAINING CENTERS - NO GROUPING
				{ value: 'Kungsholmen', data: { sortBy: 'Träningscenter' , category: 'Träningscenter' ,  address: 'Ringvägen 11, 112 45 Stockholm', association: 'F&S Stockholm', url: 'associationpage.html'} },
				{ value: 'Ringen', data: { sortBy:  'Träningscenter' , category: 'Träningscenter',  address: 'Ringvägen 11, 112 45 Stockholm' , association: 'F&S Stockholm', url: 'associationpage.html' } },
				{ value: 'Skrapan', data: { sortBy:  'Träningscenter', category: 'Träningscenter' ,  address: 'Ringvägen 11, 112 45 Stockholm' , association: 'F&S Stockholm', url: 'associationpage.html' } },
				{ value: 'City', data: { sortBy:  'Träningscenter', category: 'Träningscenter' ,  address: 'Ringvägen 11, 112 45 Stockholm' , association: 'F&S Stockholm',  url: 'associationpage.html' } },
				{ value: 'Skanstull', data: { sortBy:  'Träningscenter', category: 'Träningscenter' ,  address: 'Ringvägen 11, 112 45 Stockholm' , association: 'F&S Stockholm', url: 'associationpage.html' } },
				{ value: 'City', data: { sortBy:  'Träningscenter' , category: 'Träningscenter' ,  address: 'Ringvägen 11, 112 45 Stockholm', association: 'F&S Göteborg', url: 'associationpage.html' } },
				{ value: 'Storcentret', data: { sortBy: 'Träningscenter' , category: 'Träningscenter' ,  address: 'Ringvägen 11, 112 45 Stockholm', association:  'F&S Göteborg', url: 'associationpage.html' } },
				{ value: 'Storumans träningscenter', data: { sortBy: 'Träningscenter' , category: 'Träningscenter' ,  address: 'Ringvägen 11, 112 45 Stockholm', association:  'F&S Storuman', url: 'associationpage.html' } },
				{ value: 'Stocksunds gympasal', data: { sortBy: 'Träningscenter', category: 'Träningscenter',  address: 'Ringvägen 11, 112 45 Stockholm', association: 'F&S Danderyd', url: 'associationpage.html' } },
			];
			
			$('*[data-js-autocomplete]').autocomplete({
				lookup: _trainingCenters,
				minChars: 3,
				groupBy: 'sortBy',
                appendTo: '.autocomplete--content',
                maxHeight: 1400,
				onSelect: function (suggestion) {
					// direct user to the selected association or training center page
					window.location = suggestion.data.url;
				},
				lookupFilter: function (suggestion, query, queryLowerCase) {
					var result;

					// All gyms that exists (in an assoc. that match the search query) with a name that does not neccesary match the search query
					if((suggestion.data.category == "Förening") && (suggestion.data.sortBy.toLowerCase().indexOf(queryLowerCase) >= 0)) {
						result = result + suggestion.value;
					}
					// All associations that match the search query in an are (if they exist)
					if((suggestion.data.category == "Område") && (suggestion.data.sortBy.toLowerCase().indexOf(queryLowerCase) >= 0)) {
						result = result + suggestion.value;
					}

					// All training centers that match the searched query
					if((suggestion.data.sortBy == "Träningscenter") && (suggestion.value.toLowerCase().indexOf(queryLowerCase) >= 0)) {
						result = result + suggestion.value;
					}
					// Return result of search
					return result;
				},
				beforeRender: function (container, suggestions) {
					// Add extra container around group of search result in order to style it properly
					container.find('.autocomplete-group').each(function(i, suggestion){
						$(suggestion).nextUntil('.autocomplete-group', 'div').andSelf().wrapAll('<div class="autocomplete-container"></div>');
						$(suggestion).nextUntil('.autocomplete-group', 'div').wrapAll('<div class="autocomplete-suggestion-container"></div>');
					})

                    // Add extra container around group of search result in order to style it properly
                    container.find('.autocomplete-suggestion').each(function(i, suggestion) {
                        if(!($(suggestion).closest('.autocomplete-container').attr('data-autocomplete-category'))){
                            $(suggestion).closest('.autocomplete-container').attr('data-autocomplete-category', suggestions[i].data.category)
                        }
                        // If it's a training center add the adress
                        if($(suggestion).closest('.autocomplete-container').data('autocomplete-category') == "Träningscenter"){
                            $(suggestion).wrapInner('<div class="autocomplete-suggestion__name"></div>');
                            $(suggestion).append('<div class="autocomplete-suggestion__address"><address>'+ suggestions[i].data.address + '<span class="visible-medium-up">|</span></address><span class="autocomplete-suggestion__association">'+ suggestions[i].data.association  +'</span> </div>')
                        }
                    });
				},
			});
		});
    }
}

module.exports = autocompleteModule;