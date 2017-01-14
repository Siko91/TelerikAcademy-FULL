var Engine = (function(){

    function getMousePosition(ev) {
        var canvas = $("#result-canvas")[0];

        var hiddenLeftPixels = document.all ? iebody.scrollLeft : pageXOffset;
        var hiddenTopPixels = document.all ? iebody.scrollTop : pageYOffset;

        var mousePositionX = ev.clientX
            - canvas.offsetLeft
            + hiddenLeftPixels;
        var mousePositionY = ev.clientY
            - canvas.offsetTop
            + hiddenTopPixels;

        return {
            x: mousePositionX,
            y: mousePositionY
        };
    }

    function drawLine(){
        var line = new myCanvasDrawer.Line(
            startPositionX,
            startPositionY,
            endPositionX,
            endPositionY
            );
        line.draw($("#result-canvas")[0].getContext('2d'));
    }

    function drawRect(){
        var fromX = Math.min(startPositionX, endPositionX);
        var fromY = Math.min(startPositionY, endPositionY);
        var width = Math.abs(startPositionX - endPositionX);
        var height = Math.abs(startPositionY - endPositionY);

        var rect = new myCanvasDrawer.Rect(
            fromX,
            fromY,
            width,
            height
            );
        rect.draw($("#result-canvas")[0].getContext('2d'));
    }

    function drawCircle(){
        var x = (startPositionX + endPositionX)/2;
        var y = (startPositionY + endPositionY)/2;
        var rad = Math.min(
            Math.abs(startPositionX - endPositionX)/2,
            Math.abs(startPositionY - endPositionY)/2
            )
        var circle = new myCanvasDrawer.Circle(
            x,
            y,
            rad
            );
        circle.draw($("#result-canvas")[0].getContext('2d'));
    }

    function drawSelectedFigure() {
        var select = $("#shape-type")[0]
        var index = select.selectedIndex;
        var figureType = $("#shape-type option")[index].value;
        switch(figureType){
            case "line": drawLine(); break;
            case "rect": drawRect(); break;
            case "circle": drawCircle(); break;
            default: break;
        }
    }

    return {
        getMousePosition: getMousePosition,
        drawSelectedFigure: drawSelectedFigure
    }
})


window.onload = function(){
    var engine = new Engine();
    myCanvasDrawer = new CanvasDrawer();

    startPositionX = 0;
    startPositionY = 0;
    endPositionX = 0;
    endPositionY = 0;

    $("#result-canvas")
        .on('mousedown', function(ev){
            var pos = engine.getMousePosition(ev);
            startPositionX = pos.x;
            startPositionY = pos.y;

            // this is a workaround for a problem that I do not understand. Bear wirh it!
            startPositionX = startPositionX/1.67 | 0;
            startPositionY = startPositionY/2 | 0;

            $("#x-start").val(startPositionX-0);
            $("#y-start").val(startPositionY-0);
        })
        .on('mouseup', function(ev){
            var pos = engine.getMousePosition(ev);
            endPositionX = pos.x;
            endPositionY = pos.y;

            // this is a workaround for a problem that I do not understand. Bear wirh it!
            endPositionX = endPositionX/1.67 | 0;
            endPositionY = endPositionY/2 | 0;

            $("#x-end").val(endPositionX-0);
            $("#y-end").val(endPositionY-0);
        });

    $("#draw-btn")
        .click(engine.drawSelectedFigure);
}