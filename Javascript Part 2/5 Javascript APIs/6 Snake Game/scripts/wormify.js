var wormify = (function () {
    var GAME_CANVAS = document.getElementById('wormGame');
    var BLOCK_SIZE = 10;
    var GAME_WIDTH = GAME_CANVAS.clientWidth;
    var GAME_HEIGHT = GAME_CANVAS.clientHeight;
    var CONTEXT = GAME_CANVAS.getContext('2d');
    var GAME_LOOP_CONTROL;
    var NUMBER_OF_APPLES = 3;
    var PLAYER_SCORE = 0;

    var startGame = function () {
        CONTEXT.clearRect(0, 0, GAME_WIDTH, GAME_HEIGHT);
        var playerWorm = new Worm(5, 50, 20);
        var wormBody = playerWorm.getWormBody();
        keyboardControlWorm(playerWorm);
        var gameElements = [];
        gameElements['worm'] = playerWorm;
        gameElements['apples'] = [];
        for (var i = 0; i < NUMBER_OF_APPLES; i++) {
            gameElements['apples'].push(generateApple());
        }

        GAME_LOOP_CONTROL = setInterval(function () {
            clearBoard();
            drawElements([playerWorm.head],'black');
            drawElements(wormBody,'black');
            drawElements(gameElements['apples'], 'red');
            playerWorm.move();

            detectCollision(gameElements);
            PLAYER_SCORE++;
            updateScore();
        }, 100);
    }

    var endGame = function () {
        clearInterval(GAME_LOOP_CONTROL);
        var playerName = prompt('Dang! You dead, man! Your score is: ' + PLAYER_SCORE + '. Please enter yo name:');
    }

    var clearBoard = function () {
        CONTEXT.clearRect(0, 0, GAME_WIDTH, GAME_HEIGHT);
    }

    var generateApple = function () {
        var appleXPosition = Math.round(Math.random() * GAME_WIDTH / 10) * 10;
        var appleYPosition = Math.round(Math.random() * GAME_HEIGHT / 10) * 10;

        return new gameBlock(appleXPosition, appleYPosition);
    }

    var gameBlock = function (xPosition, yPosition) {
        if (xPosition % BLOCK_SIZE !== 0 || yPosition % BLOCK_SIZE !== 0) {
            throw new Error("The block coordinates must be within the canvas grid!");
        }

        this.xPosition = xPosition;
        this.yPosition = yPosition;
    }

    var Worm = function (startLength, startX, startY) {
        this.head = new gameBlock(startX, startY);
        wormBody = new Array(startLength - 1);
        for (var i = 0; i < startLength - 1; i++) {
            wormBody[i] = new gameBlock(startX - BLOCK_SIZE * (i + 1), startY);
        }

        this.getWormBody = function () {
            return wormBody;
        }

        this.direction = {
            x: 1,
            y: 0
        }

        this.move = function () {
            wormBody.splice(wormBody.length - 1, 1);
            wormBody.unshift(new gameBlock(this.head.xPosition, this.head.yPosition));
            this.head.xPosition += this.direction.x * BLOCK_SIZE;
            this.head.yPosition += this.direction.y * BLOCK_SIZE;
        }
    }

    var drawApple = function (apple) {
        CONTEXT.beginPath();
        CONTEXT.fillStyle = 'red';
        CONTEXT.fillRect(apple.xPosition, apple.yPosition, BLOCK_SIZE, BLOCK_SIZE);
        CONTEXT.fillStyle = 'black';
    }

    var drawElements = function (elements, color) {
        CONTEXT.fillStyle = color;
        for (var i = 0; i < elements.length; i++) {
            CONTEXT.fillRect(elements[i].xPosition, elements[i].yPosition, BLOCK_SIZE, BLOCK_SIZE);
        }
    }

    var detectCollision = function (gameElements) {
        var wormHead = gameElements['worm'].head;
        var wormBody = gameElements['worm'].getWormBody();
        var apples = gameElements['apples'];
        var hitVerticalWall = (wormHead.xPosition < 0 || wormHead.xPosition > GAME_WIDTH);
        var hitHorizontalWall = (wormHead.yPosition < 0 || wormHead.yPosition > GAME_HEIGHT);
        if (hitVerticalWall || hitHorizontalWall) {
            endGame();
            return;
        }

        for (var i = 0; i < wormBody.length; i++) {
            if (wormHead.xPosition === wormBody[i].xPosition && wormHead.yPosition === wormBody[i].yPosition) {
                endGame();
                return;
            }
        }

        for (var i = 0; i < apples.length; i++) {
            if (apples[i].xPosition === wormHead.xPosition && apples[i].yPosition === wormHead.yPosition) {
                var newTailX = wormBody[wormBody.length - 1].xPosition * 2 - wormBody[wormBody.length - 2].xPosition;
                var newTailY = wormBody[wormBody.length - 1].yPosition * 2 - wormBody[wormBody.length - 2].yPosition;
                wormBody.push(new gameBlock(newTailX, newTailY));
                apples.splice(i, 1);
                apples.push(generateApple());
                PLAYER_SCORE += 20;
            }
        }
    }

    var updateScore = function () {
        var scoreElement = document.getElementById('score');
        scoreElement.innerText = 'Current score: ' + PLAYER_SCORE;
    }

    var keyboardControlWorm = function (worm) {
        document.onkeydown = function (event) {
            event = event || window.event;
            //check if move is valid!
            switch (event.keyCode) {
                // left
                case 37:
                    worm.direction.x = -1;
                    worm.direction.y = 0;
                    break;
                    // up
                case 38:
                    worm.direction.x = 0;
                    worm.direction.y = -1;
                    break;
                    // right
                case 39:
                    worm.direction.x = 1;
                    worm.direction.y = 0;
                    break;
                    // down
                case 40:
                    worm.direction.x = 0;
                    worm.direction.y = 1;
                    break;
            }
        }
    }

    return {
        startGame: startGame
    }
})();