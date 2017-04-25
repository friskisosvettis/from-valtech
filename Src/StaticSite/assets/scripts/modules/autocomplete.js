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
                //TRAINING CENTER - SEARCH BY ASSOCIATION
                { value: 'F&S Stockholm', data: { sortBy: 'F&S Stockholm' , category: 'Förening' , centers: [{ name: 'Gärdet', url: 'associationpage.html/#kungsholmen'},{ name: 'Ringen', url: 'associationpage.html/#ringen'},{ name: 'City', url: 'associationpage.html/#city'},{ name: 'Kungsholmen', url: 'associationpage.html/#kungsholmen'},{ name: 'Södermalm', url: 'associationpage.html/#ringen'},{ name: 'Annan', url: 'associationpage.html/#city'},{ name: 'Aktivitetshuset Skjortan', url: 'associationpage.html/#kungsholmen'},{ name: 'Hornstull', url: 'associationpage.html/#ringen'},{ name: 'Odenplan', url: 'associationpage.html/#city'},{ name: 'St. Eriksbron', url: 'associationpage.html/#kungsholmen'},{ name: 'Fridhemsplan', url: 'associationpage.html/#ringen'},{ name: 'City', url: 'associationpage.html/#city'},{ name: 'Vällingby', url: 'associationpage.html/#kungsholmen'},{ name: 'Hötorget', url: 'associationpage.html/#ringen'},{ name: 'Sundbyberg', url: 'associationpage.html/#city'},{ name: 'Älvsjä', url: 'associationpage.html/#kungsholmen'},{ name: 'Rinöen', url: 'associationpage.html/#ringen'},{ name: 'Mariatorget', url: 'associationpage.html/#city'}], url: 'associationpage.html'} },
				{ value: 'F&S Storuman', data: { sortBy:  'F&S Storuman' , category: 'Förening' , centers: [{ name: 'Storumans', url: 'associationpage.html/#storuman'}], url: 'associationpage.html#storuman' } },
				{ value: 'F&S Huddinge', data: { sortBy:  'F&S Huddinge' , category: 'Förening' , centers: [{ name: 'Huddinge Centrum', url: 'associationpage.html/#centrum'},{ name: 'Huddinges gymnastikhall', url: 'associationpage.html/#huddinge'}], url: 'associationpage.html' } },

                // ASSOCIATIONS - SEARCH BY AREA
				{ value: 'Stockholm', data: { sortBy:  'Stockholm', category:  'Område' , associations:[{name:'F&S Stockholm', url: '#stockholm'}, {name:'F&S Huddinge', url: '#hudding'},{name:'F&S Lidingö', url: '#lidingo'},{name:'F&S Stockholm', url: '#stockholm'}, {name:'F&S Huddinge', url: '#hudding'},{name:'F&S Lidingö', url: '#lidingo'},{name:'F&S Stockholm', url: '#stockholm'}, {name:'F&S Huddinge', url: '#hudding'},{name:'F&S Lidingö', url: '#lidingo'},{name:'F&S Stockholm', url: '#stockholm'}, {name:'F&S Huddinge', url: '#hudding'},{name:'F&S Lidingö', url: '#lidingo'},{name:'F&S Stockholm', url: '#stockholm'}, {name:'F&S Huddinge', url: '#hudding'},{name:'F&S Lidingö', url: '#lidingo'}], area: 'stockholm', url: 'associationpage.html' } },

				// TRAINING CENTERS - SEARH BY TRAINING CENTER
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
                lookupLimit: 10,
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

                        // If it's an association add the training centers
                        if($(suggestion).closest('.autocomplete-container').data('autocomplete-category') == "Förening"){
                            var centers = suggestions[i].data.centers;
                            $(suggestion).closest('.autocomplete-container').append('<div class="autocomplete-suggestion-results"></div>');
                            $(suggestion).closest('.autocomplete-suggestion-container').append('<div class="autocomplete-suggestion__btn"><a class="btn btn__link" href="' + suggestions[i].data.url + '">Gå till sidor</a></div>');

                            for (var j=0; j < centers.length; j++) {
                                $(suggestion).closest('*[data-autocomplete-category]').find('.autocomplete-suggestion-results').append( '<a href='+centers[j].url +'>' + centers[j].name + '</a>')
                            }
                        }

                        // If it's an area add the associations
                        if($(suggestion).closest('.autocomplete-container').data('autocomplete-category') == "Område"){
                            var associations = suggestions[i].data.associations;
                            $(suggestion).closest('.autocomplete-container').append('<div class="autocomplete-suggestion-results"></div>');

                            for (var j=0; j < associations.length; j++) {
                                $(suggestion).closest('*[data-autocomplete-category]').find('.autocomplete-suggestion-results').append( '<a href='+associations[j].url +'>' + associations[j].name + '</a>')
                            }
                        }

                        // If it's a training center add the adress
                        if($(suggestion).closest('.autocomplete-container').data('autocomplete-category') == "Träningscenter"){
                            $(suggestion).wrapInner('<div class="autocomplete-suggestion__name"></div>');
                            $(suggestion).append('<div class="autocomplete-suggestion__address"></address>'+ suggestions[i].data.address + '<span class="visible-medium-up">|</span></address><span class="autocomplete-suggestion__association">'+ suggestions[i].data.association  +'</span> </div>')
                        }
                    });
				},
			});
		});
    }
}

module.exports = autocompleteModule;