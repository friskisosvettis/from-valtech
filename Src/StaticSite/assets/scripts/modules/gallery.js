/**
* Gallery
*
* @author bjarke.rasmussen
*/
/*jslint plusplus: true, vars: true, browser: true, white:true*/
/*global define: true*/

'use strict';

// Require dependencies for this module
var $ = require('jquery');

var gallery = {
    init: function () {
        $('[data-gallery]').on('click', function (e) {
            var $this = $(e.currentTarget),
                images = this.collectGalleryItems($this.data('gallery'));

            this.showGallery(images);
        }.bind(this));
    },

    showGallery: function (images) {
        var $gallery = $('<div class="data-gallery" data-gallery-index="1"><div class="data-gallery__container"></div></div>');

        // Create and append gallery images
        $gallery.find('.data-gallery__container').append(this.buildGallery(images));

        // Close gallery
        $gallery.find('.data-gallery__container').append('<a href="#" class="js-close-gallery data-gallery__close"></a>');

        // Append dot navigation
        if (images.length > 1) {
            var $dots = $('<ul class="data-gallery__dots"></ul>');
            $.each(images, function (i, v) {
                if (i == 0) {
                    // add active class on first item
                    $dots.append('<li class="data-gallery__dots__item js-gallery-dot is-active" data-gallery-dot="' + (i + 1) + '"></li>');
                } else {
                    $dots.append('<li class="data-gallery__dots__item js-gallery-dot" data-gallery-dot="' + (i + 1) + '"></li>');
                }
            });
            $gallery.find('.data-gallery__container').append($dots);
        }

        // Prev/Next navigation
        $gallery.find('.data-gallery__container').append('<nav class="data-gallery__nav"><a href="#" class="js-gallery-prev data-gallery__nav__prev"></a><a href="#" class="js-gallery-next data-gallery__nav__next"></a></nav>');

        // Append gallery to body and prevent scroll on body
        $('body').css('overflow', 'hidden').append($gallery);

        // Bind click events for navigation
        this.galleryClickEvents($gallery);

        // Show gallery
        $gallery.fadeIn();
    },

    galleryClickEvents: function ($gallery) {
        $gallery.on('click', '.js-close-gallery', function (e) {
            e.preventDefault();

            $gallery.fadeOut(function () {
                $(this).remove();
                $('body').css('overflow', '');
            });
        });

        $gallery.on('click', '.js-gallery-prev', function (e) {
            e.preventDefault();

            var index = $gallery.data('gallery-index');

            if (index == 1) {
                var index = $gallery.find('.data-gallery__list__item').length;
            } else {
                --index;
            }
            
            this.goToSlide(index, $gallery, 'left');
        }.bind(this));

        $gallery.on('click', '.js-gallery-next', function (e) {
            e.preventDefault();
            
            var index = $gallery.data('gallery-index');

            if (index == $gallery.find('.data-gallery__list__item').length) {
                var index = 1;
            } else {
                ++index;
            }
            
            this.goToSlide(index, $gallery, 'right');
        }.bind(this));

        $gallery.on('click', '.js-gallery-dot', function (e) {
            e.preventDefault();

            this.goToSlide($(e.currentTarget).data('gallery-dot'), $gallery);
        }.bind(this));

        $(document).on('keydown', function (e) {
            if (e.which == 27) {
                $gallery.fadeOut(function () {
                    $(this).remove();
                    $('body').css('overflow', '');
                });
            }
        });
    },

    goToSlide: function (index, $gallery, direction) {
        // Don't do anything of index is the same as active index
        if (index == $gallery.data('gallery-index')) {
            return false;
        }

        // Transition direction
        if (!direction) {
            // Calculate direction from indexes
            if (index > $gallery.data('gallery-index')) {
                var direction = 'right';
            } else {
                var direction = 'left';
            }
        }

        // Update current dot
        $gallery.find('.js-gallery-dot').removeClass('is-active');
        $gallery.find('.js-gallery-dot:nth-child(' + index + ')').addClass('is-active');

        // Animate gallery
        $gallery.find('.data-gallery__list').animate({
            'marginLeft': 0 - ((index - 1) * 100) + '%'
        });

        // Update gallery data-gallery-index
        $gallery.data('gallery-index', index);
    },

    buildGallery: function (images) {
        var $galleryList = $('<ul class="data-gallery__list"></ul>');

        $.each(images, function (i, v) {
            if (i == 0) {
                // Set first to display block
                $galleryList.append('<li class="data-gallery__list__item" style="opacity: 1;"><h2 class="data-gallery__list__item__headline">' + this.title + '</h2><img src="' + this.img + '" class="data-gallery__list__item__image"></li>');
            } else {
                $galleryList.append('<li class="data-gallery__list__item"><h2 class="data-gallery__list__item__headline">' + this.title + '</h2><img src="' + this.img + '" class="data-gallery__list__item__image"></li>');
            }
        });

        return $galleryList;
    },

    collectGalleryItems: function (id) {
        var $items = $('[data-gallery="' + id + '"]'),
            images = [];

        $items.each(function () {
            images.push($(this).data('gallery-src'));
        });

        return images;
    }
}

module.exports = gallery;