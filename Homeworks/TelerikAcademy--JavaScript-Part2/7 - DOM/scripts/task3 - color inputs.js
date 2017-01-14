function generateColorChangers() {
    var resultDiv = document.getElementById('the-result-box');
    while (resultDiv.firstChild) {
        resultDiv.removeChild(resultDiv.firstChild);
    }

    var listFragment = document.createDocumentFragment();

    var fontColorLabel = document.createElement('label');
    fontColorLabel.setAttribute('for', "fontColorImput");
    fontColorLabel.innerHTML = "fontColorImput: ";
    fontColorLabel.style.margin = "15px ";
    var fontColorImput = document.createElement('input');
    fontColorImput.id = "fontColorImput";
    fontColorImput.type = "color";

    listFragment.appendChild(fontColorLabel);
    listFragment.appendChild(fontColorImput);

    var backgroundColorLabel = document.createElement('label');
    backgroundColorLabel.setAttribute('for', "backgroundColorImput");
    backgroundColorLabel.innerHTML = "backgroundColorImput: ";
    backgroundColorLabel.style.margin = "15px ";
    var backgroundColorImput = document.createElement('input');
    backgroundColorImput.id = "backgroundColorImput";
    backgroundColorImput.type = "color";

    listFragment.appendChild(backgroundColorLabel);
    listFragment.appendChild(backgroundColorImput);

    var paragraph = document.createElement("p");
    paragraph.id = "theParagraph"

    var text = "This is some normal text. <strong>This is a strong element.</strong> ";
    for (var i = 0; i < 5; i++) {
        text += text;
    }
    paragraph.innerHTML = text;

    listFragment.appendChild(paragraph);

    resultDiv.appendChild(listFragment);
    resultDiv.style.padding = "30px";

    fontColorImput.addEventListener(
        'change',
        function () { setFontColorByTagName(paragraph, 'strong', fontColorImput.value); },
        false
        );
    backgroundColorImput.addEventListener(
        'change',
        function () { setBackgroundByTagName(paragraph, 'strong', backgroundColorImput.value); },
        false
        );

    fontColorImput.value = "#000000";
    backgroundColorImput.value = "#ffffff";
}

function setFontColorByTagName(parent, tagName, color) {
    var elements = parent.getElementsByTagName(tagName);
    for (var i = 0; i < elements.length; i++) {
        elements[i].style.color = color;
    }
}

function setBackgroundByTagName(parent, tagName, color) {
    var elements = parent.getElementsByTagName(tagName);
    for (var i = 0; i < elements.length; i++) {
        elements[i].style.backgroundColor = color;
    }
}