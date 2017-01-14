CanvasDrawer = (function() {
    function Shape(x,y){
        this._x = x;
        this._y = y;
    };

    function Line(x, y, toX, toY){
        Shape.call(this, x, y);
        this._toX = toX;
        this._toY = toY;
    };
    Line.prototype = new Shape();
    Line.prototype.draw = function(canvasContext){
        canvasContext.beginPath();
        canvasContext.moveTo(this._x, this._y);
        canvasContext.lineTo(this._toX, this._toY);
        canvasContext.stroke();
        canvasContext.closePath();
    };

    function Rect(x, y, width, height){
        Shape.call(this, x, y);
        this._width = width;
        this._height = height;
    };
    Rect.prototype = new Shape();
    Rect.prototype.draw = function(canvasContext){
        canvasContext.beginPath();
        canvasContext.strokeRect(
            this._x,
            this._y,
            this._width,
            this._height);
        canvasContext.stroke();
        canvasContext.closePath();
    };

    function Circle(x, y, radius){
        Shape.call(this, x, y);
        this._radius = radius;
    };
    Circle.prototype = new Shape();
    Circle.prototype.draw = function(canvasContext){
        canvasContext.beginPath();
        canvasContext.arc(
            this._x,
            this._y,
            this._radius,
            0,
            2 * Math.PI);
        canvasContext.stroke();
        canvasContext.closePath();
    };


    var result = {
        Line: Line,
        Rect: Rect,
        Circle: Circle
    };
    return result;
})