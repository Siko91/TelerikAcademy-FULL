function getDistanceBetwenn2DPoints(x1, y1, x2, y2) {
    // [ c2 = a2 + b2 ] return c
    return Math.sqrt(Math.pow(x1 - x2, 2) + Math.pow(y1 - y2, 2));
}

function generateSpiningDivs() {
    var resultDiv = document.getElementById('the-result-box');
    while (resultDiv.firstChild) {
        resultDiv.removeChild(resultDiv.firstChild);
    }

    // center
    var centerX = resultDiv.offsetLeft + resultDiv.offsetWidth / 2;
    var centerY = resultDiv.offsetTop + resultDiv.offsetHeight / 2;

    var theSun = document.createElement("div");
    theSun.style.width = "20px";
    theSun.style.height = "20px";
    theSun.style.borderRadius = "200px";
    theSun.style.border = "3px solid red";
    theSun.style.position = "absolute";
    theSun.style.left = centerX + "px";
    theSun.style.top = centerY + "px";
    theSun.style.background = "yellow";

    resultDiv.appendChild(theSun);

    var planetes = [];
    var planetesCount = 5;

    for (var i = 0; i < planetesCount; i++) {
        var angleStep = (planetesCount - i) * 0.03;
        if (i % 2 === 0) {
            angleStep = -angleStep;  
        }

        var newPlanet = new planet(
            (i+1)*10,
            360 / planetesCount * i, 
            (i+1)*50,
            centerX,
            centerY,
            angleStep);

        resultDiv.appendChild(newPlanet.element);

        planetes.push(newPlanet);
    }
    setInterval(function () { movePlanetes(planetes); }, 100);
}

function movePlanetes(planetes) {
    for (var i = 0; i < planetes.length; i++) {
        planetes[i].moveInOrbit();
    }
}

function planet(radius, angle, distance, sunX, sunY, angleStep) {
    this.radius = radius;
    this.angle = angle;
    this.distance = distance;
    this.element = generateDiv(radius, 0, 0);
    this.sunX = sunX;
    this.sunY = sunY;
    this.rotationStep = angleStep;

    this.moveInOrbit = function() {
        this.angle += this.rotationStep;
        if (this.angle > 360) {
            this.angle -= 360;
        }
        else if (this.angle < 0) {
            this.angle += 360;
        }
        this.element.style.left = this.sunX + this.distance * Math.cos(this.angle) + 'px';
        this.element.style.top = this.sunY + this.distance * Math.sin(this.angle) + 'px';
    };
}

function generateDiv(radius, x, y) {
    var div = document.createElement("div");
    div.style.width = radius * 2 + "px";
    div.style.height = radius * 2 + "px";
    div.style.borderRadius = "200px";
    div.style.border = "none";
    div.style.position = "absolute";
    div.style.top = y + "px";
    div.style.left = y + "px";
    div.style.background = generateRandomColor();

    return div;
}