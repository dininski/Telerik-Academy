var Slider = function (container) {
    var sliderContainer,
        sliderItemSize,
        maxLeft,
        repeat,
        currentLeft = 0;

    this.init = function () {
        restartMovement();
        addHandlers();

        sliderContainer = $(container);
        sliderItemSize = $('.sliderItem').first().css('width');
        sliderItemSize = +sliderItemSize.substr(0, sliderItemSize.length - 2);
        maxLeft = sliderContainer.children().length * sliderItemSize;

        sliderContainer.css({
            'width': maxLeft + 'px',
            'left': 0
        });
        
    };

    var addHandlers = function () {
        $('#navNext').on('click', function () {
            restartMovement();
            move('left');
        });

        $('#navPrev').on('click', function () {
            restartMovement();
            move('right');
        });
    }

    var move = function (dir) {
        if (dir === "right") {
            if (currentLeft === 0) {
                currentLeft = -maxLeft + sliderItemSize;
            } else {
                currentLeft += sliderItemSize;
            }

            sliderContainer.animate({
                left: currentLeft + 'px'
            }, 1000, function () {
                sliderContainer.css('left', currentLeft);
            });
        } else {
            if (currentLeft === -maxLeft + sliderItemSize) {
                currentLeft = 0;
            } else {
                currentLeft -= sliderItemSize;
            }
            sliderContainer.animate({
                left: currentLeft
            }, 1000, function () { });
        }
    }

    var restartMovement = function () {
        clearInterval(repeat);
        repeat = window.setInterval(function () {
            move('left');
        }, 5000, false);
    }
}