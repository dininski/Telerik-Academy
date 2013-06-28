module("MovingGameObject.init");
test("When a moving game object is initialized, should set the correct values", function () {
    var position = {
        x: 150,
        y: 150
    };
    var size = 10;
    var fcolor = "#BB0000";
    var scolor = "#00BB00";
    var speed = 15;
    var direction = 0;
    var gameObj = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    equal(position, gameObj.position, "Position is set");
    equal(size, gameObj.size, "Size is set");
    equal(fcolor, gameObj.fcolor, "Fill color is set");
    equal(scolor, gameObj.scolor, "Stroke color is set");
    equal(speed, gameObj.speed, "Speed is set");
    equal(direction, gameObj.direction, "Direction is set");
});

module("MovingGameObject.move");
test("Game object should move left when direction is set to 0", function () {
    var position = {
        x: 150,
        y: 150
    };
    var expectedPosition = {
        x: 150,
        y: 150
    }
    var size = 10;
    var fcolor = "#BB0000";
    var scolor = "#00BB00";
    var speed = 15;
    var direction = 0;
    var gameObj = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
    gameObj.move();

    equal(gameObj.position.x, expectedPosition.x - speed, "Moves correctly to the left");
    equal(gameObj.position.y, expectedPosition.y, "Is not moved vertically");
});

test("Game object should move up when direction is set to 1", function () {
    var position = {
        x: 150,
        y: 150
    };
    var expectedPosition = {
        x: 150,
        y: 150
    }
    var size = 10;
    var fcolor = "#BB0000";
    var scolor = "#00BB00";
    var speed = 15;
    var direction = 1;
    var gameObj = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
    gameObj.move();

    equal(gameObj.position.x, expectedPosition.x, "Is not moved horizontally");
    equal(gameObj.position.y, expectedPosition.y - speed, "Moves up correctly");
});

test("Game object should move right when direction is set to 2", function () {
    var position = {
        x: 150,
        y: 150
    };
    var expectedPosition = {
        x: 150,
        y: 150
    }
    var size = 10;
    var fcolor = "#BB0000";
    var scolor = "#00BB00";
    var speed = 15;
    var direction = 2;
    var gameObj = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
    gameObj.move();

    equal(gameObj.position.x, expectedPosition.x + speed, "Moves right correctly");
    equal(gameObj.position.y, expectedPosition.y, "Is not moved vertically");
});

test("Game object should move down when direction is set to 3", function () {
    var position = {
        x: 150,
        y: 150
    };
    var expectedPosition = {
        x: 150,
        y: 150
    }
    var size = 10;
    var fcolor = "#BB0000";
    var scolor = "#00BB00";
    var speed = 15;
    var direction = 3;
    var gameObj = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
    gameObj.move();

    equal(gameObj.position.x, expectedPosition.x, "Is not moved horizontally");
    equal(gameObj.position.y, expectedPosition.y + speed, "Moves down correctly");
});