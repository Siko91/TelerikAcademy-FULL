function character(name, positionX, positionY) {
    this.name = name;
    this.direction = 'right';
    this.state = 'idle';
    this.positionX = positionX;
    this.positionY = positionY;
    this.frameOfSprite = 0;

    this.canBeControlled = function () {
        return this.state === 'idle';
    };

    this.goIdle = function () {
        this.speed = 0;
        this.state = 'idle';
        this.frameOfSprite = 0;
    };
    this.run = function () {
        this.speed = 20;
        this.state = 'run';
    };
    this.jump = function () {
        this.speed = 20;
        this.state = 'jump';
    };
    this.attack = function () {
            this.speed = 10;
            this.state = 'attack';
    };

    this.getImageURL = function () {
        if (this.state !== 'idle') {
            return this.name + "\\" + this.state + "-" + this.direction + ".bmp"
        };
        else {
            goIdle();
            return this.name + "\\run-" + this.direction + ".bmp"
        }
    };
}