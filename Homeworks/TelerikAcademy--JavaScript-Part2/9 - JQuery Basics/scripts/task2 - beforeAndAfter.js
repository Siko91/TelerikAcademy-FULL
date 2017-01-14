function generateElementBeforeAndAfter() {
    // clean up
    var $resultChildren = $('#the-result-box *');
    $resultChildren.remove();

    // create content
    var $centralElement = $("<div id='central-element'>Center</div>");
    $centralElement.css("margin", "30px");
    $centralElement.css("margin-top", "150px");
    $centralElement.css("display", "inline-block");
    $("#the-result-box").append($centralElement);

    var counter = 0;

    // before
    setInterval(function () {
        var $elementToInsertLeft = $("<span id='left-element'> [left" + counter++ + "] </span>");
        CreateElementBefore($elementToInsertLeft[0], $centralElement[0]);
    }, 2000);


    // after
    setTimeout(function () {
        setInterval(function () {
            var $elementToInsertRight = $("<span id='left-element'> [right" + counter++ + "] </span>");
            CreateElementAfter($elementToInsertRight[0], $centralElement[0]);
        }, 2000);
    }, 1000);
}

function CreateElementBefore(DOMElementToInsert, DOMElement) {
    $(DOMElementToInsert).insertBefore(DOMElement);
}

function CreateElementAfter(DOMElementToInsert, DOMElement) {
    $(DOMElementToInsert).insertAfter(DOMElement);
}