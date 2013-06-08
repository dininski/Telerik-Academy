var SliderControl = {
    imageWidth: null,
    carousel: null,
    maxWidth: null,
    right: null,
    init: function(container, imageSize) {
        imageWidth = imageSize;
        carouselWrapper = document.querySelector(container);
        carousel = carouselWrapper.childNodes[1];
        carouselImagesCount = carousel.childElementCount;
        maxWidth = carouselImagesCount * imageWidth
        carousel.style.width = maxWidth ;
        right = 0;
        this.addHandlers();
    },
    nextImage: function () {
        if (right + imageWidth < maxWidth) {
            right += imageWidth;
        } else {
            right = 0;
        }
        
        carousel.style.right = right + 'px';
    },
    previousImage: function () {
        if (right - imageWidth >= 0) {
            right -= imageWidth;
        } else {
            right = maxWidth - imageWidth;
        }

        carousel.style.right = right + 'px';
    },
    addHandlers: function() {
        var that = this;
        var buttonNext = document.querySelector('#next_img');
        buttonNext.addEventListener('click', function() {
            that.nextImage();
        }, false);

        var buttonPrev = document.querySelector('#prev_img');
        buttonPrev.addEventListener('click', function() {
            that.previousImage();
        }, false);

        var thumbs = document.querySelectorAll('.thumb');

        for (var i = 0; i < thumbs.length; i++) {
            thumbs[i].addEventListener('click', function(ev) {
                ev.stopPropagation();
                var currentIndex = 0;
                var thumbContainer = ev.target.parentElement;
                console.log(thumbContainer);
                var thumbContainerSiblings = thumbContainer.parentElement.children;

                for (var i = 0; i < thumbContainerSiblings.length; i++) {
                    if (thumbContainerSiblings[i] === thumbContainer) {
                        currentIndex = i;
                    }
                };

                right = imageWidth * currentIndex;
                console.log(right);
                console.log(carousel);
                carousel.style.right = right + 'px';
            }, false)
    };
    }
}