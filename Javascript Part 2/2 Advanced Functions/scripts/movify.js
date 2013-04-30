var movify = (function () {
    var ELEMENT_WIDTH = 100;
    var ELEMENT_HEIGHT = 100;
    var BORDER_SIZE = 4;
    var BORDER_STYLE = 'solid';
    var STARTING_TOP_RECT = 200;
    var STARTING_LEFT_RECT = 200;
    var STARTING_TOP_CIRCULAR = 200;
    var STARTING_LEFT_CIRCULAR = 200;
    var RECTANGLE_SIZE = 200;
    var CIRCLE_RADIUS = 100;

    var createNewDiv = function () {
        var div = document.createElement('div');

        div.style.width = ELEMENT_WIDTH + 'px';
        div.style.height = ELEMENT_HEIGHT + 'px';

        div.style.backgroundColor = randomColor();
        div.style.borderColor = randomColor();
        div.style.borderWidth = BORDER_SIZE;
        div.style.borderStyle = BORDER_STYLE;

        div.style.position = 'absolute';
        div.style.top = STARTING_TOP_RECT + 'px';
        div.style.left = STARTING_LEFT_RECT + 'px';

        document.body.appendChild(div);

        return div;
    }

    var randomColor = function () {
        var color = '#';

        var hexValues = '1234567890ABCDEF'.split('');

        for (var i = 0; i < 6; i++) {
            color += hexValues[Math.round(Math.random() * 15)];
        }

        return color;
    }

    var add = function (movementType) {
        if (movementType == 'rect') {
            startRectMovement();
        }

        if (movementType == 'ellipse') {
            startCircularMovement();
        }
    }

    var startRectMovement = function () {
        var divToMove = createNewDiv();

        var currentDivTopPosition = STARTING_TOP_RECT;
        var currentDivLeftPosition = STARTING_LEFT_RECT;

        setInterval(function () {
            if (currentDivTopPosition < STARTING_TOP_RECT + RECTANGLE_SIZE && currentDivLeftPosition == STARTING_LEFT_RECT) {
                currentDivTopPosition++;
            } else if (currentDivTopPosition == STARTING_TOP_RECT + RECTANGLE_SIZE && currentDivLeftPosition < STARTING_LEFT_RECT + RECTANGLE_SIZE) {
                currentDivLeftPosition++;
            } else if (currentDivTopPosition > STARTING_TOP_RECT && currentDivLeftPosition == STARTING_LEFT_RECT + RECTANGLE_SIZE) {
                currentDivTopPosition--;
            } else if (currentDivTopPosition == STARTING_TOP_RECT && currentDivLeftPosition > STARTING_LEFT_RECT) {
                currentDivLeftPosition--;
            }

            divToMove.style.top = currentDivTopPosition;
            divToMove.style.left = currentDivLeftPosition;
        });
    }

    var startCircularMovement = function () {
        var divToMove = createNewDiv();

        divToMove.setAttribute('data-degrees', 0);
        var currentDivTopPosition = STARTING_TOP_CIRCULAR;
        var currentDivLeftPosition = STARTING_TOP_CIRCULAR;

        setInterval(function () {
            var currentDegree = parseFloat(divToMove.getAttribute('data-degrees'));
            currentDegree = (currentDegree + 1) % 360;
            divToMove.setAttribute('data-degrees', currentDegree);
            console.log(currentDegree);
            currentDivTopPosition = STARTING_TOP_CIRCULAR * 2 + (Math.cos(currentDegree) * CIRCLE_RADIUS) + 'px';
            currentDivLeftPosition = STARTING_TOP_CIRCULAR * 2 + (Math.sin(currentDegree) * CIRCLE_RADIUS) + 'px';

            divToMove.style.top = currentDivTopPosition;
            divToMove.style.left = currentDivLeftPosition;
        }, 100);
    }

    return {
        add: add
    };
})();