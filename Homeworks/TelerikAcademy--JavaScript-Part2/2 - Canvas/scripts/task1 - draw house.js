
function drawHouse() {
    var canvas = document.getElementById("the-canvas"),
		ctx = canvas.getContext("2d"),
        centerX = canvas.height / 2,
        centerY = canvas.width / 2;

    // cleanup
    ctx.fillStyle = "white";
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    // styles
    ctx.lineWidth = 2;
    ctx.fillStyle = "#975B5B";
    ctx.strokeStyle = "#000000";

    // conture
    ctx.fillRect(centerX - 75, centerY - 50, 150, 150);
    ctx.strokeRect(centerX - 75, centerY - 50, 150, 150);

    // roof
    ctx.beginPath();
    ctx.moveTo(centerX - 75, centerY - 50);
    ctx.lineTo(centerX, centerY - 125);
    ctx.lineTo(centerX + 75, centerY - 50);
    ctx.closePath();
    ctx.fill();
    ctx.stroke();

    // chimney
    ctx.beginPath();
    ctx.fillRect(centerX + 30, centerY - 130, 15, 60);
    ctx.moveTo(centerX + 30, centerY - 70);
    ctx.lineTo(centerX + 30, centerY - 130);
    ctx.moveTo(centerX + 45, centerY - 70);
    ctx.lineTo(centerX + 45, centerY - 130);
    ctx.stroke();
    strokeEllipse(ctx, centerX + 37, centerY - 128, 20, 5);

    // windows
    ctx.save();
    ctx.fillStyle = "#000000";
    drawWindow(ctx, centerX - 60, centerY - 25, 30, 20);
    drawWindow(ctx, centerX + 10, centerY - 25, 30, 20);
    drawWindow(ctx, centerX + 10, centerY + 40, 30, 20);
    ctx.restore();

    // door
    ctx.lineWidth = 1;
    strokeEllipse(ctx, centerX - 35, centerY + 50, 54, 20);
    ctx.beginPath();
    ctx.moveTo(centerX - 55, centerY + 100);
    ctx.lineTo(centerX - 55, centerY + 50);
    ctx.lineTo(centerX - 15, centerY + 50);
    ctx.lineTo(centerX - 15, centerY + 100);
    ctx.closePath;
    ctx.stroke();
    ctx.fill()
    fillEllipse(ctx, centerX - 35, centerY + 50, 53, 20);

    ctx.beginPath();
    ctx.moveTo(centerX - 35, centerY + 40);
    ctx.lineTo(centerX - 35, centerY + 100);
    ctx.stroke();

    strokeEllipse(ctx, centerX - 30, centerY + 80, 5, 5);
    strokeEllipse(ctx, centerX - 40, centerY + 80, 5, 5);

};

function drawWindow(ctx, x, y) {
    var height = 16,
        width = 24;

    ctx.fillRect(x, y, width, height);
    ctx.fillRect(x, y + height+1, width, height);
    ctx.fillRect(x + width + 1, y, width, height);
    ctx.fillRect(x + width + 1, y + height + 1, width, height);
}