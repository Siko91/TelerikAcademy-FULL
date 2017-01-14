canvas = null;
img = null;
ctx = null;
hero = null;
imageReady = false;
frame = 0;
lastUpdateTime = 0;
acDelta = 0;
msPerFrame = 100;
svg = document.getElementById("the-svg");

window.onload = function () {
    makeBackground(svg);

    hero = new character("Mario", 260, 260);
    img = new Image();
    img.src = hero.getImageURL();
    img.onload = loaded();

    document.addEventListener("keydown", checkInput, false);
    loadCanvas();
}

function makeBackground(svg) {
    var svgLink = 'http://www.w3.org/2000/svg';

    var background = document.createElementNS(svgLink, 'image');
    background.setAttributeNS(svgLink, 'id', 'testimg2');
    background.setAttributeNS('http://www.w3.org/1999/xlink', 'href', 'svg/the-background.svg');
    background.setAttributeNS(svgLink, 'x', '0');
    background.setAttributeNS(svgLink, 'y', '0');

    svg.appendChild(background);
}

function checkInput(event) {
    if (event.keyCode === 37) { // left
        hero.run();
        img = new Image();
        img.src = hero.getImageURL();
        img.onload = loaded();
    }
    else if (event.keyCode === 38) { // up
        hero.jump();
        img = new Image();
        img.src = hero.getImageURL();
        img.onload = loaded();
    }
    else if (event.keyCode === 39) { // right
        hero.run();
        img = new Image();
        img.src = hero.getImageURL();
        img.onload = loaded();
    }
    else if (event.keyCode === 40) { // down
        hero.goIdle();
        img = new Image();
        img.src = hero.getImageURL();
        img.onload = loaded();
    }
    else if (event.keyCode === 0) { // space
        alert("space pressed")
    }
}
