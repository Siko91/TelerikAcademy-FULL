var movingShapes = function movingShapes(container) {

    this.container = container;

    this.centerX,
    this.centerY,

    this.setCenter = function (x, y) {
        this.centerX = x;
        this.centerY = y;
    },

    this.getRandomColor = function () {
        function rnd255() {
            return Math.floor(Math.random() * 255);
        }
        return "rgb(" + rnd255() + "," + rnd255() + "," + rnd255() + ")";
    }

    this.add = function add(movementType, elementType, radius, speed) {
        speed = speed || 10;
        elementType = elementType || 'div';
        radius = radius || 150;

        var $element = $("<" + elementType + "/>");

        $element
            .css('min-width', '50px')
            .css('min-height', '50px')
            .css('background-color', this.getRandomColor())
            .css('border', "1px solid " + this.getRandomColor())
            .css('position', 'absolute')
            .css('left', this.centerX)
            .css('top', this.centerY - radius)
            .appendTo(container);

        switch (movementType) {
            case "rect": this.addRectMovement($element[0], radius, speed); break;
            case "ellipse": this.addCircleMovement($element[0], radius, speed); break;
            default: alert('unknown type');
        }
    }

    this.addRectMovement = function addRectMovement(element, radius, speed) {
        var movingObj = {
            radius: radius,
            element: element,
            x: this.centerX,
            y: this.centerY - radius,
            cX: this.centerX,
            cY: this.centerY,
            speed: speed,
            direction: 'left'
        }
        this.moveOnRect(movingObj);
    },

    this.moveOnRect = function moveOnRect(movingObj) {
        if (movingObj.direction === 'left') {
            if (movingObj.x > movingObj.cX - movingObj.radius) {
                movingObj.x -= movingObj.speed;
                $(movingObj.element).css('left', movingObj.x + "px");
            }
            else {
                movingObj.direction = 'down'
            }
        }


        if (movingObj.direction === 'down') {
            if (movingObj.y < movingObj.cY + movingObj.radius) {
                movingObj.y += movingObj.speed;
                $(movingObj.element).css('top', movingObj.y + "px");
            }
            else {
                movingObj.direction = 'right'
            }
        }

        if (movingObj.direction === 'right') {
            if (movingObj.x < movingObj.cX + movingObj.radius) {
                movingObj.x += movingObj.speed;
                $(movingObj.element).css('left', movingObj.x + "px");
            }
            else {
                movingObj.direction = 'up'
            }
        }

        if (movingObj.direction === 'up') {
            if (movingObj.y > movingObj.cY - movingObj.radius) {
                movingObj.y -= movingObj.speed;
                $(movingObj.element).css('top', movingObj.y + "px");
            }
            else {
                movingObj.direction = 'left'
            }
        }
        setTimeout(function () { moveOnRect(movingObj); }, 100);
    },

    this.addCircleMovement = function addCircleMovement(element, radius, speed) {
        var movingObj = {
            radius: radius,
            element: element,
            cX: this.centerX,
            cY: this.centerY,
            angle: 90,
            speed: speed,
            direction: 'left'
        }
        this.moveOnCircle(movingObj);
    },

    this.moveOnCircle = function moveOnCircle(movingObj) {

        movingObj.angle += movingObj.speed / 100;

        if (movingObj.angle > 360) {
            movingObj.angle -= 360;
        }
        else if (movingObj.angle < 0) {
            movingObj.angle += 360;
        }

        var sin = Math.sin(movingObj.angle);
        var cos = Math.cos(movingObj.angle);

        var sinStep = movingObj.radius * sin;
        var cosStep = movingObj.radius * cos;

        $(movingObj.element)
            .css('left', movingObj.cX + sinStep + 'px');

        $(movingObj.element)
            .css('top', movingObj.cY + cosStep + 'px');

        setTimeout(function () { moveOnCircle(movingObj); }, 100);
    }
}