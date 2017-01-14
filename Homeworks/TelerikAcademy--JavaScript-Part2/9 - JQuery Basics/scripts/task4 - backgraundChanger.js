function generateBackgraundChanger() {
    // clean up
    var $resultChildren = $('#the-result-box *');
    $resultChildren.remove();

    var colorChanger = $("<input type='color' />")
        .change(ChangeBackgroundColor)
        .css("margin", "150px")
        .css("width", "150px")
        .css("height", "150px")
        .appendTo("#the-result-box");
}
function ChangeBackgroundColor() {
    $(document.body).css('background', this.value);
}