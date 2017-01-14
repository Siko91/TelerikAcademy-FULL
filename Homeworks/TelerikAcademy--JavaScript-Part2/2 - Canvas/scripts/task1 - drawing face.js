function strokeEllipse(ctx, centerX, centerY, width, height) {
    ctx.beginPath();

    ctx.moveTo(centerX, centerY - height / 2);

    ctx.bezierCurveTo(
    centerX + width / 2, centerY - height / 2,
    centerX + width / 2, centerY + height / 2,
    centerX, centerY + height / 2);

    ctx.bezierCurveTo(
    centerX - width / 2, centerY + height / 2,
    centerX - width / 2, centerY - height / 2,
    centerX, centerY - height / 2);

    ctx.stroke();
};

function fillEllipse(ctx, centerX, centerY, width, height) {
    ctx.beginPath();

    ctx.moveTo(centerX, centerY - height / 2);

    ctx.bezierCurveTo(
    centerX + width / 2, centerY - height / 2,
    centerX + width / 2, centerY + height / 2,
    centerX, centerY + height / 2);

    ctx.bezierCurveTo(
    centerX - width / 2, centerY + height / 2,
    centerX - width / 2, centerY - height / 2,
    centerX, centerY - height / 2);

    ctx.fill();
};

function drawHead() {
    var canvas = document.getElementById("the-canvas"),
		ctx = canvas.getContext("2d"),
        centerX = canvas.height / 2,
        centerY = canvas.width / 2;

    // cleanup
    ctx.fillStyle = "white";
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    // draw head
    ctx.beginPath();
    ctx.lineWidth = 1;
    ctx.fillStyle = "#90CAD7";
    ctx.strokeStyle = "#21535E";
    ctx.arc(centerX, centerY, 50, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();
    
    // draw eyes
    ctx.fillStyle = "#21535E";
    fillEllipse(ctx, centerX-25, centerY-15, 6, 10);
    strokeEllipse(ctx, centerX-23, centerY-15, 20, 10);
    fillEllipse(ctx, centerX+5, centerY-15, 6, 10);
    strokeEllipse(ctx, centerX+8, centerY-15, 20, 10);

    // draw nose
    ctx.beginPath();
    ctx.moveTo(centerX-5, centerY-15);
    ctx.lineTo(centerX-15, centerY+10);
    ctx.lineTo(centerX, centerY+10);
    ctx.stroke();

    // draw mouth
    ctx.beginPath();
    ctx.rotate(5*Math.PI/180);
    strokeEllipse(ctx, centerX+15, centerY+10, 40, 12);
    ctx.rotate(-5*Math.PI/180);

    // draw hat
    ctx.lineWidth = 2;
    ctx.fillStyle = "#396693";
    ctx.strokeStyle = "#000000";
    ctx.beginPath();
    fillEllipse(ctx, centerX, centerY-40, 150, 30);
    strokeEllipse(ctx, centerX, centerY-40, 150, 30);

    
    strokeEllipse(ctx, centerX, centerY-50, 70, 20);

    ctx.fillRect(centerX-25, centerY-100, 50, 50);
    ctx.strokeRect(centerX-25, centerY-100, 50, 50);

    fillEllipse(ctx, centerX, centerY-50, 70, 20);

    fillEllipse(ctx, centerX, centerY-100, 70, 20);
    strokeEllipse(ctx, centerX, centerY-100, 70, 20);
};
