define(["jquery"], function($) {
        var btnsDiv = $("#btns")
            .css("width", "600px")
            .css("height", "30px")
            .css("border", "1px solid black");
        for (var i = 1; i <= 7; i++) {
            $("<button/>")
                .attr("id", "task" + i + "btn")
                .append("Task " + i)
                .appendTo(btnsDiv);
        }

        $("#result")
            .css("width", "600px")
            .css("height", "400px")
            .css("border", "1px solid black")
            .css("overflow", "auto");
});