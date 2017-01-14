var canvas = document.getElementById("the-canvas"),
    ctx = canvas.getContext("2d"),
    snakeLength = 3,
    snake = [],
    elementSize = 10;

var direction = makeElement(elementSize * 2, 0); // right
var food = {};

document.addEventListener("keydown", checkInput, true);

function checkInput(event) {
    if (event.keyCode === 37) { // left
        if (direction.x == 0) { // if the snake is moving verticaly
            direction.x = -elementSize * 2;
            direction.y = 0;
            return;
        }
    }
    else if (event.keyCode === 38) { // up
        if (direction.y == 0) { // if the snake is moving horizontaly
            direction.x = 0;
            direction.y = -elementSize * 2;
            return;
        }
    }
    else if (event.keyCode === 39) { // right
        if (direction.x == 0) { // if the snake is moving verticaly
            direction.x = elementSize * 2;
            direction.y = 0;
            return;
        }
    }
    else if (event.keyCode === 40) { // down
        if (direction.y == 0) { // if the snake is moving horizontaly
            direction.x = 0;
            direction.y = elementSize * 2;
            return;
        }
    }
}

function moveSnakeHead(direction) {
    snake[0].x += direction.x;
    snake[0].y += direction.y;
};

function makeElement(px, py) {
    return {
        x: px,
        y: py
    };
};

function generateNewFood() {
    var x = Math.random() * canvas.width,
        y = Math.random() * canvas.height;
    if (x < 20) {
        x += 20;
    }
    if (x > canvas.width - 20) {
        x -= 20;
    }
    if (y < 20) {
        x += 20;
    }
    if (y > canvas.height - 20) {
        x -= 20;
    }

    x = Math.floor(x / elementSize / 2) * elementSize * 2;
    y = Math.floor(y / elementSize / 2) * elementSize * 2;

    return makeElement(x, y);
};

function gameStep() {
    // move snake
    for (var i = snake.length - 1; i > 0; i--) {
        snake[i].x = snake[i - 1].x;
        snake[i].y = snake[i - 1].y;
    };
    moveSnakeHead(direction);

    // check if food eaten
    if (Math.abs(snake[0].x - food.x) < 5
        && Math.abs(snake[0].y - food.y) < 5) {

        food = generateNewFood();
        snake.push(makeElement(NaN, NaN));
    }

    //check collisions
    if (0 > snake[0].x 
        || snake[0].x > canvas.width
        || 0 > snake[0].y
        || snake[0].y > canvas.height
    ) {
        alert("Game Over")
        drawSnake()
    }
    else {
        for (var i = snake.length-1; i > 1; i--) {
            if (snake[0].x === snake[i].x
                && snake[0].y === snake[i].y) {

                alert("Game Over")
                drawSnake()
            }
        }
    }

    // clean up
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    // draw snake
    ctx.fillStyle = "#998877";
    for (var i = snake.length - 1; i > 0; i--) {
        ctx.beginPath();
        ctx.arc(snake[i].x, snake[i].y, elementSize - 1, 0, 2 * Math.PI);
        ctx.fill();
    };
    ctx.strokeStyle = "red";
    ctx.beginPath();
    ctx.arc(snake[0].x, snake[0].y, elementSize - 1, 0, 2 * Math.PI);
    ctx.stroke();

    // draw food
    ctx.fillStyle = "green";
    ctx.beginPath();
    ctx.arc(food.x, food.y, elementSize - 5, 0, 2 * Math.PI);
    ctx.fill();
};

function drawSnake() {
    alert("Warning!\nThe game is buggy. :D")

    // clean up
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    // styles
    ctx.lineWidth = 2;

    food = generateNewFood();
    snake = [];
    for (var i = 0; i < snakeLength; i++) {
        snake.push(makeElement(canvas.width / 2 - i * elementSize * 2, canvas.height / 2));
    }

    // the loop
    setInterval(gameStep, 350);
};