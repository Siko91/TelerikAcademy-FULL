window.onload = function () {
    'use strict';
    var sizeOfSmallRect = 65;
    var gap = 4;
    var sizeofSmallRectAndGap = sizeOfSmallRect + gap;
    var topPadding = 92;

    var svg, svgNameSpace;
    svgNameSpace = 'http://www.w3.org/2000/svg';
    svg = document.getElementById('task1-svg');

    var background = createRect(0, 0, 712, 448);
    background.style.fill = "#001940";
    svg.appendChild(background);

    var smallRects = [];
    var bigRects = [];

    for (var i = 0; i < 13; i++) {
        smallRects[i] = createRect(sizeofSmallRectAndGap + i * sizeofSmallRectAndGap, topPadding, sizeOfSmallRect, sizeOfSmallRect, true);
        svg.appendChild(smallRects[i]);
    }
    smallRects[4].setAttribute('y', 230);
    smallRects[5].setAttribute('y', 230);
    for (var i = 0; i < 2; i++) {
        smallRects[2 + i].setAttribute('x', sizeofSmallRectAndGap + i * sizeofSmallRectAndGap);
        smallRects[2 + i].setAttribute('y', topPadding + sizeofSmallRectAndGap);

        smallRects[6 + i].setAttribute('x', sizeofSmallRectAndGap + (4 + i) * sizeofSmallRectAndGap);
        smallRects[6 + i].setAttribute('y', 299);

        smallRects[11 + i].setAttribute('x', 656);
        smallRects[11 + i].setAttribute('y', topPadding + i * sizeofSmallRectAndGap);
    }

    for (var i = 0; i < 3; i++) {
        smallRects[8 + i].setAttribute('x', 518 + (i * sizeofSmallRectAndGap));
        smallRects[8 + i].setAttribute('y', 230);
    }

    smallRects[0].setAttribute('fill', "#2D86EA");
    smallRects[3].setAttribute('fill', "#2D86EA");
    smallRects[5].setAttribute('fill', "#2D86EA");
    smallRects[10].setAttribute('fill', "#2D86EA");

    smallRects[4].setAttribute('fill', "#000000");

    smallRects[2].setAttribute('fill', "#5F3BB7");

    smallRects[1].setAttribute('fill', "#62A718");
    smallRects[7].setAttribute('fill', "#62A718");

    smallRects[6].setAttribute('fill', "#BB1C49");

    smallRects[8].setAttribute('fill', "#DD5127");

    smallRects[9].setAttribute('fill', "#002B6B");

    smallRects[11].setAttribute('fill', "#E8E9EA");

    smallRects[12].setAttribute('fill', "#006DB0");

    for (var i = 0; i < 11; i++) {
        bigRects[i] = createRect(0, 0, sizeOfSmallRect + sizeofSmallRectAndGap, sizeOfSmallRect, true, i);
        svg.appendChild(bigRects[i]);
    }
    for (var i = 0; i < 2; i++) {
        bigRects[i].setAttribute('y', topPadding);
        bigRects[i].setAttribute('x', 3 * sizeofSmallRectAndGap + i * 2 * sizeofSmallRectAndGap);

        bigRects[3 + i].setAttribute('y', topPadding + sizeofSmallRectAndGap);
        bigRects[3 + i].setAttribute('x', 3 * sizeofSmallRectAndGap + i * 2 * sizeofSmallRectAndGap);

        bigRects[2 + i * 3].setAttribute('y', topPadding + i * sizeofSmallRectAndGap);
        bigRects[2 + i * 3].setAttribute('x', 518);

        bigRects[6 + i].setAttribute('y', 230);
        bigRects[6 + i].setAttribute('x', sizeofSmallRectAndGap + i * 2 * sizeofSmallRectAndGap);

        bigRects[8 + i].setAttribute('y', 230 + sizeofSmallRectAndGap);
        bigRects[8 + i].setAttribute('x', sizeofSmallRectAndGap + i * 2 * sizeofSmallRectAndGap);
    }

    bigRects[10].setAttribute('x', 518);
    bigRects[10].setAttribute('y', 230 + sizeofSmallRectAndGap);

    bigRects[0].setAttribute('fill', "#BD1F49");
    bigRects[1].setAttribute('fill', "#01921B");
    bigRects[2].setAttribute('fill', "#613DBB");
    bigRects[3].setAttribute('fill', "#613DBB");
    bigRects[4].setAttribute('fill', "#DB562D");
    bigRects[5].setAttribute('fill', "#00A11B");
    bigRects[6].setAttribute('fill', "#D9542B");
    bigRects[7].setAttribute('fill', "#00A21C");
    bigRects[8].setAttribute('fill', "#277D87");
    bigRects[9].setAttribute('fill', "#2D85EF");
    bigRects[10].setAttribute('fill', "#FCF5F4");

    var image = document.createElementNS(svgNameSpace, 'image');
    image.setAttribute('xlink', "images\Task1-edited.png");
    image.setAttribute('x', 0);
    image.setAttribute('y', 0);
    image.setAttribute('width', 712);
    image.setAttribute('height', 448);
    svg.appendChild(image);

    function createRect(x, y, width, height, hasMouseEffects) {
        var rect;
        rect = document.createElementNS(svgNameSpace, 'rect');
        rect.setAttribute('x', x);
        rect.setAttribute('y', y);
        rect.setAttribute('width', width);
        rect.setAttribute('height', height);
        rect.setAttribute('opacity', 1);

        if (hasMouseEffects) {
            rect.addEventListener("mouseover", function () { rect.setAttribute("opacity", "0.4"); }, false);
            rect.addEventListener("click", function () { rect.setAttribute("opacity", "0.1"); }, false);
            rect.addEventListener("mouseout", function () { rect.setAttribute("opacity", "1"); }, false);
        }

        return rect;
    }
};