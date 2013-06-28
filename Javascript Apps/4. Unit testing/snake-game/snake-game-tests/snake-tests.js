module("Snake.init");

test("When snake is initialized, should set the correct values", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 15;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    equal(position, snake.position, "Position is set");
    equal(speed, snake.speed, "Speed is set");
    equal(direction, snake.direction, "Direction is set");
});

test("When snake is initialized, should contain 5 SnakePieces", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 15;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    ok(snake.pieces, "SnakePieces are created");
    equal(snake.pieces.length, 5, "Five SnakePieces are created");
    ok(snake.head, "HeadSnakePiece is created");
});


module("Snake.Consume");
test("When object is Food, should grow", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);
    var size = snake.size;
    snake.consume(new snakeGame.Food());
    var actual = snake.size;
    var expected = size + 1;
    equal(actual, expected);
});

test("When object is SnakePiece, should die", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var isDead = false;

    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.consume(new snakeGame.SnakePiece());
    ok(isDead, "The snake is dead");
});

test("When object is Obstacle, should die", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var isDead = false;

    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.consume(new snakeGame.Obstacle());
    ok(isDead, "The snake is dead");
});

module("Snake.move");
test("Snake moves correctly to the left", function () {
    var position = { x: 100, y: 100 };
    var expectedPosition = { x: 100, y: 100 };
    var speed = 10;
    var direction = 0;

    var snake = new snakeGame.Snake(position, speed, direction);
    snake.move();
    equal(snake.head.position.x, expectedPosition.x - speed, "Snake head moved correctly to left");
    equal(snake.head.position.y, expectedPosition.y, "Snake head not moved vertically");

    for (var i = 1; i < snake.pieces.length; i++) {
        equal(snake.pieces[i].position.y, expectedPosition.y,
            "Snake body element number " + i + " with correct y position");
        equal(snake.pieces[i].position.x, expectedPosition.x + speed * (i - 1),
            "Snake body element number " + i + " with correct x position");
    }
});

test("Snake moves correctly to the top", function () {
    var position = { x: 100, y: 100 };
    var expectedPosition = { x: 100, y: 100 };
    var speed = 10;
    var direction = 1;

    var snake = new snakeGame.Snake(position, speed, direction);
    snake.move();
    equal(snake.head.position.x, expectedPosition.x, "Snake head not moved horizontally");
    equal(snake.head.position.y, expectedPosition.y - speed, "Snake head moved correctly to the top");

    for (var i = 1; i < snake.pieces.length; i++) {
        equal(snake.pieces[i].position.y, expectedPosition.y + speed * (i - 1),
            "Snake body element number " + i + " with correct y position");
        equal(snake.pieces[i].position.x, expectedPosition.x,
            "Snake body element number " + i + " with correct x position");
    }
});

test("Snake moves correctly to the right", function () {
    var position = { x: 100, y: 100 };
    var expectedPosition = { x: 100, y: 100 };
    var speed = 10;
    var direction = 2;

    var snake = new snakeGame.Snake(position, speed, direction);
    snake.move();
    equal(snake.head.position.x, expectedPosition.x + speed, "Snake head moved correctly to the right");
    equal(snake.head.position.y, expectedPosition.y, "Snake head not moved vertically");

    for (var i = 1; i < snake.pieces.length; i++) {
        equal(snake.pieces[i].position.y, expectedPosition.y,
            "Snake body element number " + i + " with correct y position");
        equal(snake.pieces[i].position.x, expectedPosition.x - speed * (i - 1),
            "Snake body element number " + i + " with correct x position");
    }
});

test("Snake moves correctly to the bottom", function () {
    var position = { x: 100, y: 100 };
    var expectedPosition = { x: 100, y: 100 };
    var speed = 10;
    var direction = 3;

    var snake = new snakeGame.Snake(position, speed, direction);
    snake.move();
    equal(snake.head.position.x, expectedPosition.x, "Snake head moved not moved horizontally");
    equal(snake.head.position.y, expectedPosition.y + speed, "Snake head moved to the bottom");

    for (var i = 1; i < snake.pieces.length; i++) {
        equal(snake.pieces[i].position.y, expectedPosition.y - speed * (i - 1),
            "Snake body element number " + i + " with correct y position");
        equal(snake.pieces[i].position.x, expectedPosition.x,
            "Snake body element number " + i + " with correct x position");
    }
});

module("Snake.grow");
test("Snake increases the size correctly", function () {
    var position = { x: 100, y: 100 };
    var speed = 10;
    var direction = 0;

    var snake = new snakeGame.Snake(position, speed, direction);
    snake.grow();

    equal(snake.size, 6, "The snake size is correctly increased");
})

module("Snake.die");
test("Snake death handler works correctly with default size", function () {
    var position = { x: 100, y: 100 };
    var speed = 10;
    var direction = 0;
    var score;

    var snake = new snakeGame.Snake(position, speed, direction);
    snake.addDieHandler(function (result) {
        score = result.score;
    });

    snake.die();
    equal(score, snake.size, "Correctly calculating score when snake has default size and dies");
})

test("Snake death handler works correctly when snake has grown", function () {
    var position = { x: 100, y: 100 };
    var speed = 10;
    var direction = 0;
    var score;

    var snake = new snakeGame.Snake(position, speed, direction);
    snake.addDieHandler(function (result) {
        score = result.score;
    });

    snake.grow();
    snake.grow();
    snake.grow();
    snake.die();

    equal(score, snake.size, "Correctly calculating score when snake grows");
})

test("Check if snake eats itself", function () {
    var position = { x: 100, y: 100 };
    var speed = 10;
    var direction = 0;
    
    var snake = new snakeGame.Snake(position, speed, direction);
    var isDead = false;
    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.checkIfCanibal();
    ok(!isDead, "The snake is still alive upon creation");

    snake.pieces[0].position.x = snake.pieces[2].position.x;
    snake.pieces[0].position.y = snake.pieces[2].position.y;

    snake.checkIfCanibal();

    ok(isDead, "The snake eats itself when the head concides with a snake piece");
});