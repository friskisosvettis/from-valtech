/**
* Autocomplete Module
*
* @author Veronika Jeppsson
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery');
var autocomplete = require('autocomplete');
// autocompleteModule object for autocomplete functionality for find association/training centre
var autocompleteModule = {

	// Initialize script and bind events
    init: function () {

		$(document).ready(function() {

            $('.autocomplete__input').on('click', function() {
                $('html,body').animate({scrollTop: $(this).offset().top - $('.navigation__container').height()}, 800);
            });

            var _trainingCenters = [
                //TRAINING CENTER - SEARCH BY ASSOCIATION
                { value: 'Stockholm', data: { sortBy: 'Stockholm' , category: 'Förening' , url: 'associationpage.html', centers: 
                [{ name: 'Gärdet', url: 'associationpage.html/#kungsholmen', address: 'Ringvägen 111', city: 'Stockholm'},
                { name: 'Ringen', url: 'associationpage.html/#ringen', address: 'Ringvägen 111', city: 'Stockholm'},
                { name: 'City', url: 'associationpage.html/#city', address: 'Ringvägen 111', city: 'Stockholm'},
                { name: 'Kungsholmen', url: 'associationpage.html/#kungsholmen', address: 'Ringvägen 111', city: 'Stockholm'},
                { name: 'Södermalm', url: 'associationpage.html/#ringen', address: 'Ringvägen 111', city: 'Stockholm'},
                { name: 'Annan', url: 'associationpage.html/#city', address: 'Ringvägen 111', city: 'Stockholm'},
                { name: 'Aktivitetshuset Skjortan', url: 'associationpage.html/#kungsholmen', address: 'Ringvägen 111', city: 'Stockholm'},
                { name: 'Hornstull', url: 'associationpage.html/#ringen', address: 'Ringvägen 111', city: 'Stockholm'},
                { name: 'Odenplan', url: 'associationpage.html/#city', address: 'Ringvägen 111', city: 'Stockholm'},
                { name: 'St. Eriksbron', url: 'associationpage.html/#kungsholmen', address: 'Ringvägen 111', city: 'Stockholm'},
                { name: 'Fridhemsplan', url: 'associationpage.html/#ringen', address: 'Ringvägen 111', city: 'Stockholm'},
                { name: 'City', url: 'associationpage.html/#city', address: 'Ringvägen 111', city: 'Stockholm'},
                { name: 'Vällingby', url: 'associationpage.html/#kungsholmen', address: 'Ringvägen 111', city: 'Stockholm'},
                { name: 'Hötorget', url: 'associationpage.html/#ringen', address: 'Ringvägen 111', city: 'Stockholm'},
                { name: 'Sundbyberg', url: 'associationpage.html/#city', address: 'Ringvägen 111', city: 'Stockholm'},
                { name: 'Älvsjä', url: 'associationpage.html/#kungsholmen', address: 'Ringvägen 111', city: 'Stockholm'},
                { name: 'Rinöen', url: 'associationpage.html/#ringen', address: 'Ringvägen 111', city: 'Stockholm'},
                { name: 'Mariatorget', url: 'associationpage.html/#city', address: 'Ringvägen 111', city: 'Stockholm'}
                ]} },
				{ value: 'Storuman', data: { sortBy:  'Storuman' , category: 'Förening' , centers: [{ name: 'Storumans', url: 'associationpage.html/#storuman', address: 'Ringvägen 111', city: 'Stockholm'}], url: 'associationpage.html#storuman' , address: 'Ringvägen 111', city: 'Stockholm'} },
				{ value: 'Huddinge', data: { sortBy:  'Huddinge' , category: 'Förening' , centers: [{ name: 'Huddinge Centrum', url: 'associationpage.html/#centrum', address: 'Ringvägen 111', city: 'Stockholm'},{ name: 'Huddinges gymnastikhall', url: 'associationpage.html/#huddinge', address: 'Ringvägen 111', city: 'Stockholm'}], url: 'associationpage.html' } },

                // ASSOCIATIONS - SEARCH BY AREA
				{ value: 'Stockholm', data: { sortBy:  'StockholmArea', category:  'Område' , associations:[{name:'F&S Stockholm', url: '#stockholm'}, {name:'F&S Huddinge', url: '#hudding',},{name:'F&S Lidingö', url: '#lidingo'},{name:'F&S Stockholm', url: '#stockholm'}, {name:'F&S Huddinge', url: '#hudding'},{name:'F&S Lidingö', url: '#lidingo'},{name:'F&S Stockholm', url: '#stockholm'}, {name:'F&S Huddinge', url: '#hudding'}] } },

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
                noSuggestionNotice: 'Vi kan inte hitta det du letar efter tyvärr!',
                showNoSuggestionNotice: true,
                appendTo: '.autocomplete--content',
                maxHeight: 1400,
				onSelect: function (suggestion) {
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

                        //------ ASSOCIATION ------//
                        // If it's an association add the training centers
                        if($(suggestion).closest('.autocomplete-container').data('autocomplete-category') == "Förening"){
                            var centers = suggestions[i].data.centers;
                            $(suggestion).closest('.autocomplete-container').append('<ul class="autocomplete-suggestion-results"></ul>');
                            $(suggestion).closest('.autocomplete-suggestion').append('<p>'+ centers.length +' träningcenter</p>')
                            // Add the first five centers into a list
                            var limit = (centers.length > 5) ? 5 : centers.length;

                            for (var j=0; j < limit ; j++) {
                                $(suggestion).closest('*[data-autocomplete-category]').find('.autocomplete-suggestion-results').append( '<li><a href='+centers[j].url +'><strong>' + centers[j].name + '</strong>, ' + centers[j].address + ' ' + centers[j].city + '</a></li>')
                            }
                            if(limit >= 5) {
                                $(suggestion).closest('*[data-autocomplete-category]').find('.autocomplete-suggestion-results').append( '<li class="autocomplete-suggestion-show-all"><a href='+ suggestions.url +'>Visa alla (' + centers.length + ')'+ '</a></li>');
                            }
                        }

                        //------ AREA ------//
                        // If it's an area add the associations
                        if($(suggestion).closest('.autocomplete-container').data('autocomplete-category') == "Område"){
                            var associations = suggestions[i].data.associations;
                            $(suggestion).closest('.autocomplete-container').append('<ul class="autocomplete-suggestion-results"></ul>');
                            $(suggestion).closest('.autocomplete-suggestion').prepend('Område ')

                            for (var j=0; j < associations.length; j++) {
                                $(suggestion).closest('*[data-autocomplete-category]').find('.autocomplete-suggestion-results').append( '<li><a href='+associations[j].url +'>' + associations[j].name + '</a></li>')
                            }
                            // Find data attribute and remove data index.
                            $('*[data-autocomplete-category="Område"]').find('.autocomplete-suggestion').attr('data-index','');
                        }

                        //------ TRAINING CENTER ------//
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