    window.requestAnimFrame = (function(){
        return  window.requestAnimationFrame       ||
                window.webkitRequestAnimationFrame ||
                window.mozRequestAnimationFrame    ||
                window.oRequestAnimationFrame      ||
                window.msRequestAnimationFrame     ||
                function( callback ){
                  window.setTimeout(callback, 1000 / 60);
                };
    })();

    function loadCanvas() {
        canvas = document.getElementById("the-canvas");
        ctx = canvas.getContext("2d");
        resize();
    }
    function loaded() {
        imageReady = true;
        setTimeout( update, 1000 / 60 );
    }
    function resize() {
        //canvas.width = canvas.parentNode.clientWidth;
        //canvas.height = canvas.parentNode.clientHeight;
        redraw();
    }
    function redraw() {
        ctx.fillStyle = '#000000';
        ctx.fillRect(0, 0, canvas.width, canvas.height);
        if (imageReady)
            ctx.drawImage(img, frame*55, 0, 55, 68,
                          canvas.width/2 - 68, canvas.height/2 - 55, 55, 55);
    }
    var frame = 0;

    function update() {
        requestAnimFrame(update);

        var delta = Date.now() - lastUpdateTime;
        if (acDelta > msPerFrame)
        {
            acDelta = 0;
            redraw();
            frame++;
            if (frame >= 6) frame = 0;
        } else
        {
            acDelta += delta;
        }

        lastUpdateTime = Date.now();
    }