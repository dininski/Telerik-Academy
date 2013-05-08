var carouselify = (function () {
    'use strict';

    var imageWidth = 500;
    var carouselWrapper = document.querySelector('#carouselWrapper');
    var carousel = carouselWrapper.childNodes[1];
    var carouselImagesCount = carousel.childElementCount;
    var maxWidth = carouselImagesCount * imageWidth
    carousel.style.width = maxWidth ;
    var right = 0;

    var nextImage = function () {
    	if (right + imageWidth < maxWidth) {
    		right += imageWidth;
    	} else {
    		right = 0;
    	}
		
		carousel.style.right = right + 'px';
    }

    var previousImage = function () {
        if (right - imageWidth >= 0) {
            right -= imageWidth;
        } else {
            right = maxWidth - imageWidth;
        }

        carousel.style.right = right + 'px';
    }

    return {
    	nextImage: nextImage,
    	previousImage: previousImage
    }
})();