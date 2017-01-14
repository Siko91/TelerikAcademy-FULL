window.onload = function () {
    var resultDiv = $("#result-wrapper")[0];

    myMovingShapesMaker = new movingShapes(resultDiv);

    myMovingShapesMaker.setCenter(
    resultDiv.offsetLeft + resultDiv.offsetWidth / 2,
    resultDiv.offsetTop + resultDiv.offsetHeight / 2);
}

function addMovingShape() {
    var elementType = $('#element-type-input').val();
    var index = $('#movement-type-input')[0].selectedIndex;
    var movementType = $('#movement-type-input option')[index].value;
    var movementSpeed = parseInt($('#movement-speed-input').val());

    myMovingShapesMaker.add(movementType, elementType, 100, movementSpeed);
}