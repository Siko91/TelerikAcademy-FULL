function appendNewElement() {
    var parentName = $("#append-parent-input").val();
    var className = $("#append-class-input").val();
    var color = $("#append-color-input").val();

    var element = $('<div/>')
        .addClass(className)
        .css('background', color)
        [0];

    domModule.appendChild(element, parentName);
}

function removeAnElement() {
    var removeSelector = $('#remove-input').val();

    domModule.removeChild("#result-wrapper", removeSelector);
}

function addAnEvent() {
    var selector = $("#event-selector-input").val();
    var index = $("#event-type-select")[0].selectedIndex;
    var eventType = $("#event-type-select option")[index].value;

    domModule.addHandler(selector, eventType, function () { alert(selector + '.' + eventType + ' - activated'); })
}

function addToBuffer() {
    var selector = $("#buffer-parent-input").val();
    var type = $("#buffer-type-input").val();
    var count = parseInt($("#buffer-count-input").val());

    for (var i = 0; i < count; i++) {
        domModule.appendToBuffer(selector, "<" + type + "/>");
    }

}