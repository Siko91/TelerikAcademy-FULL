function generateRandomNumber(min, max) {
    return min + Math.floor(Math.random() * (max - min) + 0.5);
}

function generateRandomColor() {
    var color = ("rgba(" + generateRandomNumber(0, 255) + ", "
        + generateRandomNumber(0, 255) + ", "
        + generateRandomNumber(0, 255) + ", "
        + generateRandomNumber(0, 255) + ")");

    return color;
}

function generateManyDivs() {
    var divCount = prompt("How many divs do you want me to make?", "10000");
    while (true) {
        divCount = parseInt(divCount);
        if (isNaN(divCount)) {
            divCount = prompt("That wasn't a number. Try again. Haw many divs do you want?", "10000");
        }
        else if (divCount < 1) {
            divCount = prompt("That number isn't valid. Try again. Haw many divs do you want?", "10000");
        }
        break;
    }

    var resultDiv = document.getElementById('the-result-box');
    while (resultDiv.firstChild) {
        resultDiv.removeChild(resultDiv.firstChild);
    }

    var listFragment = document.createDocumentFragment();

    for (var i = 0; i < divCount; i++) {
        var div = document.createElement('div');

        //    Random width and height between 20px and 100px
        div.style.width = generateRandomNumber(20, 100) + "px";
        div.style.height = generateRandomNumber(20, 100) + "px";
        //    Random background color
        div.style.background = generateRandomColor();
        //    Random font color
        div.style.color = generateRandomColor();
        //    Random position on the screen (position:absolute)
        div.style.position = "absolute";
        div.style.top = generateRandomNumber(resultDiv.offsetTop, resultDiv.offsetTop + resultDiv.offsetHeight) + "px";
        div.style.left = generateRandomNumber(resultDiv.offsetLeft, resultDiv.offsetLeft + resultDiv.offsetWidth) + "px";
        //    A strong element with text "div" inside the div
        div.appendChild.innerHTML = "<strong>div</strong>";
        //    Random border radius
        var borderRadius = generateRandomNumber(0, 100) + "px";
        div.borderRadius = borderRadius; // standard
        div.MozBorderRadius = borderRadius; // Mozilla
        div.WebkitBorderRadius = borderRadius; // WebKit
        //    Random border color
        div.style.borderColor = generateRandomColor();
        //    Random border width between 1px and 20px
        div.style.borderWidth = generateRandomNumber(0, 20) + "px";

        listFragment.appendChild(div);
    }

    resultDiv.appendChild(listFragment);
}