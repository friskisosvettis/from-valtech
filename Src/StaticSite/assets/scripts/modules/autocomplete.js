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
            // Variables for translations
            var errorMessage = $('.autocomplete--content').attr('data-js-autocomplete-error');
            var categoryTrainingcenter = $('.autocomplete--content').attr('data-js-autocomplete-trainingcenter');
            var categoryArea = $('.autocomplete--content').attr('data-js-autocomplete-area');
            var categoryAssociation = $('.autocomplete--content').attr('data-js-autocomplete-association');
            var categoryTraingcenterOne = $('.autocomplete--content').attr('data-js-autocomplete-trainingcenter-one');
            var categoryTraingcenterMore = $('.autocomplete--content').attr('data-js-autocomplete-trainingcenter-more');
            var categoryShowAll = $('.autocomplete--content').attr('data-js-autocomplete-show-all');
            console.log('error', errorMessage, 'categoryTrainingcenter', categoryTrainingcenter,
                'one', categoryTraingcenterOne, 'more', categoryTraingcenterMore,
            'showall', categoryShowAll, 'area', categoryArea, 'assoc', categoryAssociation);

		    $('.autocomplete__input')
		        .on('click',
		            function() {
		                $('html,body')
		                    .animate({ scrollTop: $(this).offset().top - $('.navigation__container').height() }, 800);
		            });

		    $('*[data-js-autocomplete]').autocomplete({
			    serviceUrl: "/__AutoComplete",
				minChars: 3,
                lookupLimit: 10,
				groupBy: 'sortBy',
                noSuggestionNotice: errorMessage,
                showNoSuggestionNotice: true,
                appendTo: '.autocomplete--content',
                maxHeight: 1400,
		        triggerSelectOnValidInput: false,
				onSelect: function (suggestion) {
                    window.location = suggestion.data.url;
                },
				lookupFilter: function (suggestion, query, queryLowerCase) {
					var result;

					// All gyms that exists (in an assoc. that match the search query) with a name that does not neccesary match the search query
					if ((suggestion.data.category == "Förening") && (suggestion.data.sortBy.toLowerCase().indexOf(queryLowerCase) >= 0)) {
						result = result + suggestion.value;
					}
					// All associations that match the search query in an are (if they exist)
					if ((suggestion.data.category == "Område") && (suggestion.data.sortBy.toLowerCase().indexOf(queryLowerCase) >= 0)) {
						result = result + suggestion.value;
					}

					// All training centers that match the searched query
					if ((suggestion.data.category == "Träningscenter") && (suggestion.data.sortBy.toLowerCase().indexOf(queryLowerCase) >= 0)) {
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
                                $(suggestion).closest('*[data-autocomplete-category]').find('.autocomplete-suggestion-results').append( '<li class="autocomplete-suggestion-show-all"><a href='+ suggestions[0].data.url +'>Visa alla (' + centers.length + ')'+ '</a></li>');
                            }
                        }

                        //------ AREA ------//
                        // If it's an area add the associations
                        if ($(suggestion).closest('.autocomplete-container').data('autocomplete-category') == "Område") {
                            var associations = suggestions[i].data.associations;
                            $(suggestion)
                                .closest('.autocomplete-container')
                                .append('<ul class="autocomplete-suggestion-results"></ul>');
                            $(suggestion).closest('.autocomplete-suggestion').prepend('Område ')

                            for (var j = 0; j < associations.length; j++) {
                                $(suggestion)
                                    .closest('*[data-autocomplete-category]')
                                    .find('.autocomplete-suggestion-results')
                                    .append('<li><a href=' + associations[j].url + '>' + associations[j].name + '</a></li>')
                            }
                            // Find data attribute and remove data index.
                            $('*[data-autocomplete-category="Område"]')
                                .find('.autocomplete-suggestion')
                                .attr('data-index', '');
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