function drawBike() {
    var canvas = document.getElementById("the-canvas"),
		ctx = canvas.getContext("2d"),
        centerX = canvas.height / 2,
        centerY = canvas.width / 2;

    // cleanup
    ctx.fillStyle = "white";
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    ctx.lineWidth = 3;
    ctx.fillStyle = "#90CAD7";
    ctx.strokeStyle = "#337D8F";

    // draw tires
    fillEllipse(ctx, centerX - 80, centerY, 100, 100);
    fillEllipse(ctx, centerX + 80, centerY, 100, 100);
    strokeEllipse(ctx, centerX - 80, centerY, 100, 100);
    strokeEllipse(ctx, centerX + 80, centerY, 100, 100);

    ctx.beginPath()
    ctx.moveTo(centerX - 80, centerY);
    ctx.lineTo(centerX - 10, centerY - 50);
    ctx.lineTo(centerX + 10, centerY + 10);
    ctx.closePath();
    ctx.moveTo(centerX + 10, centerY + 10);
    ctx.lineTo(centerX + 60, centerY - 60);
    ctx.lineTo(centerX - 10, centerY - 50);
    ctx.moveTo(centerX + 80, centerY);
    ctx.lineTo(centerX + 50, centerY - 80);
    ctx.lineTo(centerX + 30, centerY - 70);
    ctx.lineTo(centerX + 50, centerY - 80);
    ctx.lineTo(centerX + 70, centerY - 90);

    // seat
    ctx.moveTo(centerX - 10, centerY - 50);
    ctx.lineTo(centerX - 15, centerY - 70);
    ctx.moveTo(centerX + 5, centerY - 70);
    ctx.lineTo(centerX - 35, centerY - 70);

    // draw pedals
    ctx.moveTo(centerX + 20, centerY + 20);
    ctx.lineTo(centerX + 30, centerY + 30);
    ctx.moveTo(centerX, centerY);
    ctx.lineTo(centerX - 10, centerY - 10);

    // stroke all at once
    ctx.stroke();

    // draw pedals (part 2)
    strokeEllipse(ctx, centerX + 10, centerY + 10, 30, 30);
};