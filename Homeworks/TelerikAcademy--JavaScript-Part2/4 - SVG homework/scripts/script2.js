
window.onload = function () {
    'use strict';
    var svg, svgNameSpace;
    svgNameSpace = 'http://www.w3.org/2000/svg';
    svg = document.getElementById('task2-svg');

    var stringToWrite = "MEAN";
    var radius = 155 / 2;
    var circles = [];
    var letters = [];

    for (var i = 0; i < 4; i++) {
        circles[i] = createCircle(193, (radius + 10) * (i + 1), radius);
        svg.appendChild(circles[i]);

        letters[i] = createText(stringToWrite[i], 46, (radius + 10) * (i + 1), "Arial Black", 40, 'black'); // y of letter is same as circle y
        svg.appendChild(letters[i]);
    }

    var express = createText("express", 193 - radius + 20, (radius + 15)*2, "Arial", 35, 'white');
    svg.appendChild(express);
    circles[2].setAttribute('fill', 'red');
    letters[2].setAttribute('fill', 'red');
    circles[3].setAttribute('fill', 'yellowgreen');
    letters[3].setAttribute('fill', 'yellowgreen');

    function createCircle(x, y, radius) {
        var circle;
        circle = document.createElementNS(svgNameSpace, 'circle');
        circle.setAttribute('cx', x);
        circle.setAttribute('cy', y);
        circle.setAttribute('r', radius);
        circle.setAttribute('stroke-width', 0);
        circle.setAttribute('fill', 'black');
        return circle;
    }
    function createText(letter, x, y, font, size, fill) {
        var letterElement;
        letterElement = document.createElementNS(svgNameSpace, 'text');
        letterElement.textContent = letter;
        letterElement.setAttribute('x', x);
        letterElement.setAttribute('y', y);
        letterElement.setAttribute('font-size', size);
        letterElement.setAttribute('font-family', font);
        letterElement.setAttribute('fill', fill);
        return letterElement;
    }
};