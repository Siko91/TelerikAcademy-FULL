var canvas = document.getElementById("the-canvas"),
    ctx = canvas.getContext("2d");

var position = {
    x: canvas.height / 2,
    y: canvas.width / 2,
    accelerate: function (acceleration) {
        position.x += acceleration.x;
        position.y += acceleration.y;
    }
};

var acceleration = {
    x: 10,
    y: 13
};

function animate() {
    // clean up
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    // draw old ball (it's smaller)
    ctx.beginPath();
    ctx.arc(position.x, position.y, 5, 0, 2 * Math.PI);
    ctx.stroke();

    // move the ball and check for collisions
    position.accelerate(acceleration);
    if (position.x < 0 || position.x > canvas.width) {
        acceleration.x = -acceleration.x;
    }
    if (position.y < 0 || position.y > canvas.height) {
        acceleration.y = -acceleration.y;
    }

    // draw new ball (it's bigger)
    ctx.beginPath();
    ctx.arc(position.x, position.y, 10, 0, 2 * Math.PI);
    ctx.stroke();
};

function drawAnimation() {
    // clean up
    ctx.fillStyle = "white";
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    // styles
    ctx.lineWidth = 2;

    // the loop
    setInterval(animate, 40);
};