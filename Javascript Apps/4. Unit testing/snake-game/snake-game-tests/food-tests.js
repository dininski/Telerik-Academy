module("Food.init");

test("When food is initialized, should set the correct values", function () {
    var foodPosition = {
        x: 150,
        y: 150
    };

    var foodSize = 10;
    var defaultFoodFillColor = "#0000ff";
    var defaultFoodStrokeColor = "#00ff00";

    var food = new snakeGame.Food(foodPosition, foodSize);
    
    equal(foodPosition.x, food.position.x, "Food x position is set");
    equal(foodPosition.y, food.position.y, "Food y position is set");
    equal(foodSize, food.size, "Size is set");
    equal(defaultFoodFillColor, food.fcolor, "Food fill color is correctly set");
    equal(defaultFoodStrokeColor, food.scolor, "Food stroke color is correctly set");
});